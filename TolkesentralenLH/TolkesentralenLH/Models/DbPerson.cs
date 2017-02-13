using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{
    public class DbPerson
    {
       // DbNetcont db = new DbNetcont();


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
        /// <returns></returns>
        public bool settInnKunde(FKunde innkunde)
        {
            var db = new DbNetcont();
            var nykunde = new Kunde()
            {
               
                fornavn = innkunde.fornavn,
                etternavn = innkunde.etternavn,
                email = innkunde.email,
                adresse = innkunde.adresse,
                regDato = DateTime.Now,
                kundeNr = "29292992",
                password = innkunde.password

            };
         
            Poststed eksistererPostnr = db.Poststeder.Find(innkunde.postNr);

            if (eksistererPostnr == null)
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
                nykunde.poststed = eksistererPostnr;
            }
                

            db.Personer.Add(nykunde);
            db.SaveChanges();
            return true;
               
        }

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
                //postNr = innAdmin.postNr,
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


    }


    //public bool endreKunde(int persId, Person innPerson)
    //{
    //    var db = new DbNetcont();

    //    try
    //    {
    //        Person endreKunde = db.Personer.Find(persId);
    //        endreKunde.fornavn = innPerson.fornavn;
    //        endreKunde.etternavn = innPerson.etternavn;
    //        endreKunde.email = innPerson.email;
    //        endreKunde.adresse = innPerson.adresse;
    //        endreKunde.regDato = innPerson.regDato;
    //        endreKunde.password = innPerson.password;

    //        Poststed eksisterendePostdted = db.Poststeder.Find(innPerson.poststed.postNr);
    //        if(eksisterendePostdted == null)
    //        {
    //            var nyttPoststed = new Poststed()
    //            {

    //            };
    //        }
    //    }
    //}

}