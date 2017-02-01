using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TolkesentralenHL.Models;
using System.Web.Mvc;


namespace TolkesentralenHL
{
    public class DbTolksentralen
    {

        public List<Kunde> hentAlle()
        {
            var db = new DbNetcontext();

            List<Kunde> alleKunder = db.kunder.Select(k => new Kunde()
                            {
                               kundeNrID = k.kundeNrID,
                               Fornavn = k.Fornavn,
                               Etternavn = k.Etternavn,
                               Email = k.Email,
                               Password = k.Password,
                               Adresse = k.Adresse,
                               Firma= k.Firma,
                               postSted = k.poststeder.postSted
                           
                            }
            ).ToList();
            return alleKunder;
        }

        public bool settInn(Person innPerson)
        {
            var nyKunde = new Kunde()
            {
                Fornavn = innPerson.fornavn,
                Etternavn = innPerson.etternavn,
                Adresse = innPerson.adresse,
                Postnummer = innPerson.postnummer,
                Email = innPerson.email,
                Password = innPerson.password,
                Firma = innPerson.firma
            };

            var db = new DbNetcontext();
            try
            {
                var eksistererPostnr = db.poststeder.Find(innPerson.postnummer);
                if(eksistererPostnr == null)
                {
                    var nyttPoststed = new Poststeder()
                    {
                        postnummer = innPerson.postnummer,
                        postSted = innPerson.postSted
                    };
                    nyKunde.poststeder = nyttPoststed;
                }

                db.kunder.Add(nyKunde);
                db.SaveChanges();

                return true;
            }catch(Exception feil)
            {
                return false;
            }
            
        }
    }
}