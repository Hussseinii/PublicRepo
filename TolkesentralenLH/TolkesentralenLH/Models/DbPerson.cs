using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TolkesentralenLH.Models;

namespace TolkesentralenLH.Models
{
    public class DbPerson
    {
       // DbNetcont db = new DbNetcont();


        /// <summary>
        /// /Liste all the registered members
        /// </summary>
        /// <returns></returns>
        public List<Kunde> ListeAlleKunder()
        {
            var db = new DbNetcont();
            List<Kunde> alleKunder = db.Personer.OfType<Kunde>().ToList();
            return alleKunder;
          
        }
        /// <summary>
        /// SettInn en kunde
        /// </summary>
        /// <param name="innkunde"></param>
        /// <returns>
        /// this puts a person or registeres a person to the database
        /// </returns>
        public bool settInnKunde(FKunde innkunde)
        {
            var db = new DbNetcont();
            var nykunde = new Kunde()
            {

                fornavn = innkunde.fornavn,
                etternavn = innkunde.etternavn,
                tlf = innkunde.tlf,
                email = innkunde.email,
                adresse = innkunde.adresse,
                regDato = DateTime.Now,
                password = innkunde.password,

                firma = innkunde.firma,
                kontaktperson = innkunde.kontaktperson,
                telefax = innkunde.telefax,
                fakturaAddress = innkunde.fakturaAddress

            };
        
        //her finner vi et poststed ved hjelp av en postnr
        Poststed eksistererPoststed = db.Poststeder.Find(innkunde.postNr);

            if (eksistererPoststed == null)
            {
                var nyttpoststed = new Poststed()
                {
                    postNr = innkunde.postNr,
                    postSted = innkunde.postSted

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
        public bool settinnTolk(FKunde inntolk)
        {

            var nyTolk = new Tolk()
            {
                fornavn = inntolk.fornavn,
                etternavn = inntolk.etternavn,
                email = inntolk.email,
                adresse = inntolk.adresse,
                regDato = DateTime.Now,
                tolkNr = "29292992",
                password = inntolk.password

            };
            var db = new DbNetcont();
            try
            {
                var eksistererPostnr = db.Poststeder.Find(inntolk.postNr);

                if (eksistererPostnr == null)
                {
                    var nyttpoststed = new Poststed()
                    {
                        postNr = inntolk.postNr,
                        postSted = inntolk.postSted

                    };
                    nyTolk.poststed = nyttpoststed;

                }
                else
                {
                    nyTolk.poststed = eksistererPostnr;
                }
                db.Personer.Add(nyTolk);
                db.SaveChanges();

                return true;
            }
            catch (Exception feil)
            {
                Debug.WriteLine("Exception Message: " + feil.Message);
                return false;
            }

        }
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
        public bool settinnAdmin(FKunde innAdmin)
        {

            var nyAdmin = new Admin()
            {

                fornavn = innAdmin.fornavn,
                etternavn = innAdmin.etternavn,
                email = innAdmin.email,
                adresse = innAdmin.adresse,
                regDato = DateTime.Now,
                adminNr = "019901999",
                password = innAdmin.password,

            };
            var db = new DbNetcont();
            try
            {
                var eksistererPostnr = db.Poststeder.Find(innAdmin.postNr);

                if (eksistererPostnr == null)
                {
                    var nyttpoststed = new Poststed()
                    {
                        postNr = innAdmin.postNr,
                        postSted = innAdmin.postSted

                    };
                    nyAdmin.poststed = nyttpoststed;

                }
                else
                {
                    nyAdmin.poststed = eksistererPostnr;
                }
                db.Personer.Add(nyAdmin);
                db.SaveChanges();

                return true;
            }
            catch (Exception feil)
            {
                Debug.WriteLine("Exception Message: " + feil.Message);
                return false;
            }
        }


   

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
        public bool endreOppdrag (int oppdragID, Oppdrag innOppdrag)
        {
            var db = new DbNetcont();
            try
            {
                Oppdrag endreoppdrag = db.Oppdrag.Find(oppdragID);
                endreoppdrag.oppdragsgiver = innOppdrag.oppdragsgiver;
                endreoppdrag.oppdragType = innOppdrag.oppdragType;
                endreoppdrag.språkFra = innOppdrag.språkFra;
                endreoppdrag.språkTil = innOppdrag.språkTil;
                endreoppdrag.kunde.oppdrag = endreoppdrag.kunde.oppdrag;
                
                db.SaveChanges();
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
        public List<Fremmaate> ListeAllefremmaate()
        {
            var db = new DbNetcont();

            List<Fremmaate> allefremmaate = db.Oppdrag.OfType<Fremmaate>().ToList();

            return allefremmaate;
           // List<Kunde> alleKunder = db.Personer.OfType<Kunde>().ToList();
        }
    }
}