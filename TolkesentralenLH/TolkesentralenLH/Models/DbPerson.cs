using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
<<<<<<< HEAD

namespace TolkesentralenLH.Models
{
    public class DbPerson
    {

=======
using TolkesentralenLH.Models;

namespace TolkesentralenLH.Models
{


    public class DbPerson
    {
        DbNetcont db = new DbNetcont();

        public bool settInnKunde(Kunde innkunde)
        {



            var nykunde = new Kunder()
            {
                persId = innkunde.persId,
                fornavn = innkunde.fornavn,
                etternavn = innkunde.etternavn,
                email = innkunde.email,
                adresse = innkunde.adresse,
                regdDato = innkunde.regdDato,
                password = innkunde.password,
                
            };
            var db = new DbNetcont();
            try
            {
                var eksistererPostnr = db.Poststeder.Find(innkunde.postNr);

                if(eksistererPostnr == null)
                {
                    var nyttpoststed = new Poststed()
                    {
                      postNr = innkunde.postNr,
                      postSted = innkunde.postSted
                
                    };
                    nykunde.poststed = nyttpoststed;

                }
                db.Personer.Add(nykunde);
                db.SaveChanges();

                return true;
            }
            catch(Exception feil)
            {
                return false;
            }
        }
>>>>>>> 9d0adea6b90b66221f9d9af0e81334c1fb95081a
    }
}