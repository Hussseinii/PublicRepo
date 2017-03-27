using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TolkesentralenLH.Models;
using TolkesentralenLH.ViewModels;

namespace TolkesentralenLH.Models
{
    public class DbPerson
    {
       // DbNetcont db = new DbNetcont();


        // List alle kunder. Enten godkjente (1) eller til godkjenning (0)
        public List<Kunde_VM> ListeAlleKunder(int godkjent)
        {
            var db = new DbNetcont();
            List<Kunde> alleKunder = db.Personer.OfType<Kunde>().ToList();
            try
            {
                List<Kunde_VM> vm_liste = new List<Kunde_VM>();
                foreach (var row in alleKunder)
                {
                    if(row.godkjent == godkjent)
                    {
                        var kunde = new Kunde_VM()
                        {
                            firma = row.firma,
                            fornavn = row.fornavn,
                            etternavn = row.etternavn,
                            tlf = row.tlf,
                            telefax = row.telefax,
                            fakturaadresse = row.fakturaAddress,
                            postnr = row.poststed.postNr,
                            poststed = row.poststed.postSted,
                            email = row.email
                        };
                        vm_liste.Add(kunde);
                    }
                }
                return vm_liste;
            }
            catch (Exception)
            {
                return null;
            }
        }


        // NB: Denne er under produksjon..
        public bool OppdaterTilGodkjentKunde(string email)
        {
            try
            {
                var db1 = new DbNetcont();
                var eksistererPostnr = db1.Personer.Find(email);
                var db = new DbNetcont();
                {
                    Person kunde;
                    foreach (var row in db.Personer.OfType<Kunde>())
                    {
                        if (row.email != null)
                        {
                            if (row.email.Equals(email))
                            {
                                kunde = row;
                                break;
                            }
                        }
                    }
                    //kunde.godkjent = 1;
                    db.SaveChanges();
                    return true;

                }
               // return false;
            }
            catch (Exception feil)
            {
                Debug.WriteLine("Exception Message: " + feil.Message);
                return false;
            }
        }

        
        public bool settInnKunde(Kunde_VM innkunde)
        {
            var db = new DbNetcont();
           
            string salt = lagSalt();
            var passordOgSalt = innkunde.passord + salt;
            byte[] dbPassword = lagHash(passordOgSalt);

            var nykunde = new Kunde()
            {

                fornavn = innkunde.fornavn,
                etternavn = innkunde.etternavn,
                tlf = innkunde.tlf,
                email = innkunde.epost,
                adresse = innkunde.adresse,
                regDato = DateTime.Now,
                godkjent = 0,
                password = dbPassword,
                Salt = salt,
                firma = innkunde.firma,
                kontaktperson = innkunde.kontaktperson,
                telefax = innkunde.telefax,
                fakturaAddress = innkunde.fakturaadresse

            };
        
        //her finner vi et poststed ved hjelp av en postnr
        Poststed eksistererPoststed = db.Poststeder.Find(innkunde.postnr);

            if (eksistererPoststed == null)
            {
                var nyttpoststed = new Poststed()
                {
                    postNr = innkunde.postnr,
                    postSted = innkunde.poststed

                };
               // db.Poststeder.Add(nyttpoststed);
                nykunde.poststed = nyttpoststed;
                   
            }else
            {
                nykunde.poststed = eksistererPoststed;
            }
                

            db.Personer.Add(nykunde);
            db.SaveChanges();
            return true;
               
        }

        public Get_Login_VM AutoriserOgReturnerBruker(string brukernavn, string passord)
        {
            using (var db = new DbNetcont())
            {
                // Finner første machende rad til brukernavn
                Person dbData = db.Personer.FirstOrDefault(b => b.email == brukernavn);

                if (dbData == null) return null;

                // Sjekker om passord#hash macher brukeren
                byte[] passordForTest = lagHash(passord + dbData.Salt);
                bool riktigBruker = dbData.password.SequenceEqual(passordForTest);
                
                if (!riktigBruker) return null;

                var bruker = new Get_Login_VM();
                bruker.brukernavn = dbData.email;
                bruker.id = dbData.persId;
                bruker.rolle = dbData.GetType().BaseType.Name.ToLower();
                return bruker;
            }
        }


        /*
        /// <summary>
        /// Method to check that the persons details are correct 
        /// with the inputs at the frontend and the backend  
        /// hence the database.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="passord"></param>
        /// <returns></returns>

        public Login_vm reggisteret_i_db(Login_vm ny)
        {
            using (var db = new DbNetcont())
            {

                List<Kunde> alleKunder = db.Personer.OfType<Kunde>().ToList();
                byte[] dbPaasord;
                foreach (var k in alleKunder)
                {
                    dbPaasord = lagHash(ny.passord + k.Salt);

                    if(k.password.SequenceEqual(dbPaasord))
                    {
                        Login_vm retur = new Login_vm();
                        retur.email = k.email;
                        retur.id = k.persId;
                        retur.role = 1;
                        return retur;
                    }
                }

                return null;
            }
        }
        */

            
        /// <summary>
        /// this method lists all the tolks
        /// </summary>
        /// <returns>
        /// and returns the list of all the tolkes
        /// </returns>
        public List<Tolk> ListeAlleTolk()
        {
            var db = new DbNetcont();
            List<Tolk> alleTolker = db.Personer.OfType<Tolk>().ToList();
            return alleTolker;

        }

        /// <summary>
        /// SettInn en Tolk
        /// </summary>
        /// <param name="inntolk"></param>
        /// <returns></returns>
        //public bool settinnTolk(Kunde inntolk)
        //{

        //    var nyTolk = new Tolk()
        //    {
        //        fornavn = inntolk.fornavn,
        //        etternavn = inntolk.etternavn,
        //        email = inntolk.email,
        //        adresse = inntolk.adresse,
        //        regDato = DateTime.Now,
        //       // tolkNr = "29292992",
        //        password = lagHash(inntolk.password)

        //    };
        //    var db = new DbNetcont();
        //    try
        //    {
        //        var eksistererPostnr = db.Poststeder.Find(inntolk.postNr);

        //        if (eksistererPostnr == null)
        //        {
        //            var nyttpoststed = new Poststed()
        //            {
        //                postNr = inntolk.postNr,
        //                postSted = inntolk.postSted

        //            };
        //            nyTolk.poststed = nyttpoststed;

        //        }
        //        else
        //        {
        //            nyTolk.poststed = eksistererPostnr;
        //        }
        //        db.Personer.Add(nyTolk);
        //        db.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception feil)
        //    {
        //        Debug.WriteLine("Exception Message: " + feil.Message);
        //        return false;
        //    }

        //}
        /// <summary>
        /// lists all the Administrators that the company has
        /// </summary>
        /// <returns>
        /// returns the liste 
        /// </returns>
        public List<Admin> ListeAlleAdmin()
        {
            var db = new DbNetcont();
            List<Admin> alleAdmin = db.Personer.OfType<Admin>().ToList();
            return alleAdmin;

        }

        ///// <summary>
        ///// Setter inn en Amdministrator
        ///// </summary>
        ///// <param name="innAdmin"></param>
        ///// <returns></returns>
        //public bool settinnAdmin(FKunde innAdmin)
        //{

        //    var nyAdmin = new Admin()
        //    {

        //        fornavn = innAdmin.fornavn,
        //        etternavn = innAdmin.etternavn,
        //        email = innAdmin.email,
        //        adresse = innAdmin.adresse,
        //        regDato = DateTime.Now,
        //        adminNr = "019901999",
        //        password = lagHash (innAdmin.password),

        //    };
        //    var db = new DbNetcont();
        //    try
        //    {
        //        var eksistererPostnr = db.Poststeder.Find(innAdmin.postNr);

        //        if (eksistererPostnr == null)
        //        {
        //            var nyttpoststed = new Poststed()
        //            {
        //                postNr = innAdmin.postNr,
        //                postSted = innAdmin.postSted

        //            };
        //            nyAdmin.poststed = nyttpoststed;

        //        }
        //        else
        //        {
        //            nyAdmin.poststed = eksistererPostnr;
        //        }
        //        db.Personer.Add(nyAdmin);
        //        db.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception feil)
        //    {
        //        Debug.WriteLine("Exception Message: " + feil.Message);
        //        return false;
        //    }
        //}


   

        /// <summary>
        /// this will find and re turn a person
        /// with the help of the id as a key from the database
        /// </summary>
        /// <param name="persId"></param>
        /// <param name="innkunde"></param>
        /// <returns></returns>
        public bool endreKunde(int persId, Kunde innkunde)
        {
            var db = new DbNetcont();

            try
            {
                Person endreKunde = db.Personer.Find(innkunde.persId);
                endreKunde.fornavn = innkunde.fornavn;
                endreKunde.etternavn = innkunde.etternavn;
                endreKunde.email = innkunde.email;
                endreKunde.adresse = innkunde.adresse;
                endreKunde.regDato = innkunde.regDato;
                endreKunde.password = innkunde.password;

                if (endreKunde.poststed.postNr!=innkunde.poststed.postNr)
                { 
                        Poststed eksisterendePostdted = db.Poststeder.Find(innkunde.poststed.postNr);
                        if (eksisterendePostdted == null)
                        {
                            var nyttPoststed = new Poststed()
                            {
                               postNr = innkunde.poststed.postNr,
                               postSted = innkunde.poststed.postSted
                            };
                            db.Poststeder.Add(nyttPoststed);
                        }
                        else
                        {
                            endreKunde.poststed.postNr = innkunde.poststed.postNr;
                        }
                };
                db.SaveChanges();
                return true;
            }
            catch(Exception feil)
            {
                Debug.WriteLine("Exception Message: " + feil.Message);
                    return false;
            }
        
        }

        public bool slettKunde(int slettId)
        {
            var db = new DbNetcont();
            try
            {
                Person slettkunde = db.Personer.Find(slettId);
                db.Personer.Remove(slettkunde);
                db.SaveChanges();
                return true;
            }catch(Exception feil)
            {
                Debug.WriteLine("Exception Message: " + feil.Message);
                return false;
            }
        }
        /// <summary>
        /// Helping method to find a person 
        /// </summary>
        /// <param name="persnId"></param>
        /// <returns>
        /// returns a id
        /// </returns>
        public Person finnKunde(int persnId)
        {
            var db = new DbNetcont();
            var fankkunde = db.Personer.FirstOrDefault(k => k.persId == persnId);
            if(fankkunde == null)
            {
                return null;
            }
            return fankkunde;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oppdragsID"></param>
        /// <returns>
        /// </returns>
        public Oppdrag HentOppdrag(int oppdragsID)
        {
            var db = new DbNetcont();
            var enoppdrag = db.Oppdrag.Find(oppdragsID);
            if(enoppdrag == null)
            {
                return null;
            }
            return enoppdrag;
        }
        /// <summary>
        /// Delete a "Oppdrag" first by getting the id  
        /// </summary>
        /// <param name="oppdragsID"></param>
        /// <returns>
        /// return a "Oppdrag" after find an id
        /// </returns>
        public bool slettOppdrag (int oppdragsID)
        {
            var db = new DbNetcont();
            Oppdrag slettenOppdrag = db.Oppdrag.Find(oppdragsID);
            db.Oppdrag.Remove(slettenOppdrag);
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oppdragID"></param>
        /// <param name="innOppdrag"></param>
        /// <returns>
        /// </returns>
        //public bool endreOppdrag (int oppdragID, Oppdrag innOppdrag)
        //{
        //    var db = new DbNetcont();
        //    try
        //    {
        //        Oppdrag endreoppdrag = db.Oppdrag.Find(oppdragID);
        //        endreoppdrag.oppdragsgiver = innOppdrag.oppdragsgiver;
        //        endreoppdrag.oppdragType = innOppdrag.oppdragType;
        //        endreoppdrag.språkFra = innOppdrag.språkFra;
        //        endreoppdrag.språkTil = innOppdrag.språkTil;
        //        endreoppdrag.kunde.oppdrag = endreoppdrag.kunde.oppdrag;
                
        //        db.SaveChanges();
        //    }
        //    catch(Exception feil)
        //    {
        //        Debug.WriteLine("Exception Message: " + feil.Message);
        //        return false;
        //    }
        //    return true;
        //}

        public bool endreOppdrag (int oppdragID, Oppdrag innOppdrag)
        {
            var db = new DbNetcont();
            try
            {
                //Oppdrag endreoppdrag = db.Oppdrag.Find(oppdragID);
                //endreoppdrag.oppdragsgiver = innOppdrag.oppdragsgiver;
                //endreoppdrag.oppdragType = innOppdrag.oppdragType;
                //endreoppdrag.språkFra = innOppdrag.språkFra;
                //endreoppdrag.språkTil = innOppdrag.språkTil;
                //endreoppdrag.kunde.oppdrag = endreoppdrag.kunde.oppdrag;
                
                //db.SaveChanges();
            }
            catch(Exception feil)
            {
                Debug.WriteLine("Exception Message: " + feil.Message);
                return false;
            }
            return true;
        }


        public List<Oppdrag> ListeAlleOppdrag()
        {
            var db = new DbNetcont();
            return db.Oppdrag.ToList();
        }
        /// <summary>
        /// this i a list of files that have been 
        /// </summary>
        /// <returns></returns>
        public List<Fil> ListeAlleFil()
        {
            var db = new DbNetcont();

            return db.Filer.ToList();
        }
        /// <summary>
        /// Find the id by contacting the database and makes sure its the right id
        /// </summary>
        /// <param name="oppdragsID"></param>
        /// <returns>
        /// returns an id of oppdrag
        /// </returns>
        public Oppdrag visOppdrag(int oppdragsID)
        {
            var db = new DbNetcont();
            return db.Oppdrag.FirstOrDefault(Oppd => Oppd.oppdragsID == oppdragsID);
        }
        /// <summary>
        /// Method that lists frammaate
        /// </summary>
        /// <return>
        /// It returns the values in foem of a list 
        /// </returns>
        public List<Tolking> ListeAllefremmaate()
        {
            var db = new DbNetcont();

            List<Tolking> allefremmaate = db.Oppdrag.OfType<Tolking>().ToList();

            return allefremmaate;
           // List<Kunde> alleKunder = db.Personer.OfType<Kunde>().ToList();
        }


        /********************** Sikkerhets hjelp ***********************/

        public byte[] lagHash(string innStreng)
        {
            byte[] innData, utData;

            var algoritme = SHA512.Create();
            innData = Encoding.UTF8.GetBytes(innStreng);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        public string lagSalt()
        {
            byte[] randomArray = new byte[10];
            string randomString;

            var strg = new RNGCryptoServiceProvider();
            strg.GetBytes(randomArray);
            randomString = Convert.ToBase64String(randomArray);
            return randomString;
        }
    }
}