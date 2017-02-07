using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{
    public class DbPerson
    {
        DbNetcont db = new DbNetcont();


        public List<Person> hentKunde()
        {
            var db = new DbNetcont();
            List<Person> alleKunder = db.Personer.ToList();

            return alleKunder;
          
        }
        /// <summary>
        /// SettInn en kunde
        /// </summary>
        /// <param name="innkunde"></param>
        /// <returns></returns>
        public bool settInnKunde(Kunde innkunde)
        {
            var nykunde = new Kunde()
            {
                persId = innkunde.persId,
                fornavn = innkunde.fornavn,
                etternavn = innkunde.etternavn,
                email = innkunde.email,
                adresse = innkunde.adresse,
                regDato = innkunde.regDato,
                password = innkunde.password,

            };
            var db = new DbNetcont();
            try
            {
                var eksistererPostnr = db.Poststeder.Find(innkunde.poststed.postNr);

                if (eksistererPostnr == null)
                {
                    var nyttpoststed = new Poststed()
                    {
                        postNr = innkunde.poststed.postNr,
                        postSted = innkunde.poststed.postSted

                    };
                    nykunde.poststed = nyttpoststed;

                }
                db.Personer.Add(nykunde);
                db.SaveChanges();

                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        /// <summary>
        /// SettInn en Tolk
        /// </summary>
        /// <param name="inntolk"></param>
        /// <returns></returns>
        public bool settinnTolk(Tolk inntolk)
        {

            var nyTolk = new Tolk()
            {
                persId = inntolk.persId,
                fornavn = inntolk.fornavn,
                etternavn = inntolk.etternavn,
                email = inntolk.email,
                adresse = inntolk.adresse,
                regDato = inntolk.regDato,
                password = inntolk.password,

            };
            var db = new DbNetcont();
            try
            {
                var eksistererPostnr = db.Poststeder.Find(inntolk.poststed.postNr);

                if (eksistererPostnr == null)
                {
                    var nyttpoststed = new Poststed()
                    {
                        postNr = inntolk.poststed.postNr,
                        postSted = inntolk.poststed.postSted

                    };
                    nyTolk.poststed = nyttpoststed;

                }
                db.Personer.Add (nyTolk);
                db.SaveChanges();

                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        /// <summary>
        /// Setter inn en Amdministrator
        /// </summary>
        /// <param name="innAdmin"></param>
        /// <returns></returns>
        public bool settinnAdmin(Admin innAdmin)
        {

            var nyTolk = new Admin()
            {
                persId = innAdmin.persId,
                fornavn = innAdmin.fornavn,
                etternavn = innAdmin.etternavn,
                email = innAdmin.email,
                adresse = innAdmin.adresse,
                regDato = innAdmin.regDato,
                password = innAdmin.password,

            };
            var db = new DbNetcont();
            try
            {
                var eksistererPostnr = db.Poststeder.Find(innAdmin.poststed.postNr);

                if (eksistererPostnr == null)
                {
                    var nyttpoststed = new Poststed()
                    {
                        postNr = innAdmin.poststed.postNr,
                        postSted = innAdmin.poststed.postSted

                    };
                    nyTolk.poststed = nyttpoststed;

                }
                db.Personer.Add(nyTolk);
                db.SaveChanges();

                return true;
            }
            catch (Exception feil)
            {
                return false;
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
}