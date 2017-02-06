using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TolkesentralenLH.Models;

namespace TolkesentralenLH.Controllers
{
    public class HomeController : Controller
    {
        private DbNetcont db = new DbNetcont();
        // GET: Home
        public ActionResult Index()
        {
            var sp1 = new Spraak
            {
                spraak = "norsk",
                nivaa = "Top"
            };
            var admin = new Admin
            {
                fornavn = "Hussen",
                etternavn = "Ali",
                email = "h@hotmail.com",
                adresse = "stovner",
                regdDato = DateTime.Parse("2005-09-01"),
                password = "1111",
                adminNr = "a1"

            };

            var tolk = new Tolk
            {
                fornavn = "Lunga",
                etternavn = "A",
                email = "h@hotmail.com",
                adresse = "stovner",
                regdDato = DateTime.Parse("2005-09-01"),
                password = "1111",
                tolkNr = "t1",
                spraak = new List<Spraak>()
                {
                    new Spraak()
                    {
                        spraak = "norsk",
                        nivaa = "Top"

                    }
                }

            };

            var kunde = new Kunde
            {
                fornavn = "Jacob",
                etternavn = "Al",
                email = "h@hotmail.com",
                adresse = "stovner",
                regdDato = DateTime.Parse("2005-09-01"),
                password = "1111",
                kundeNr = "k1"
            };

            var oppdrag1 = new Oversettelse
            {
                oppdragType = "oversettelse",
                oppdragsgiver = "Ahus",
                språkFra = "Somalisk",
                språkTil = "Norsk",

                kunde = kunde,

                Tolk = tolk
          

            };

            //var oppdrag2 = new Fremmaate
            //{
            //    oppdragType = "oversettelse",
            //    oppdragsgiver = "Ahus",
            //    språkFra = "Somalisk",
            //    språkTil = "Norsk",

            //    kunde = kunde,

            //    Tolk = tolk


            //};

            db.Personer.Add(admin);
            db.Personer.Add(tolk);
            db.Personer.Add(kunde);
            db.Oppdrag.Add(oppdrag1);
            //db.Oppdrag.Add(oppdrag2);
            db.SaveChanges();


            return View(db.Personer.ToList());
        }
    }
}