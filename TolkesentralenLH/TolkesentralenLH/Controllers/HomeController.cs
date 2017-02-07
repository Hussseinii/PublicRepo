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
        private static DbNetcont db = new DbNetcont();
        private DbOppdrag dbOppdrag = new DbOppdrag(db);

        public ActionResult Liste()
        {
            var DbPerson = new DbPerson();
            List<Person> allekunde = DbPerson.hentKunde();
            return View(allekunde);
        }

        public ActionResult Registrer()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Registrer(Kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                var DbPerson = new DbPerson();
                bool insertOK = DbPerson.settInnKunde(innKunde);
                if (insertOK)
                {
                    return RedirectToAction("Liste");
                }
            }
            return View();
        }

        // GET: Home
        //public ActionResult Index()
        //{
        //   var sp1 = new Spraak
        //    {
        //        spraak = "norsk",
        //        nivaa = "Top"
        //    };
        //    var admin = new Admin
        //    {
        //        fornavn = "Hussen",
        //        etternavn = "Ali",
        //        email = "h@hotmail.com",
        //        adresse = "stovner",
        //        regDato = DateTime.Parse("2005-09-01"),
        //        password = "1111",
        //        adminNr = "a1"

        //    };

        //    var tolk = new Tolk
        //    {
        //        fornavn = "Lunga",
        //        etternavn = "A",
        //        email = "h@hotmail.com",
        //        adresse = "stovner",
        //        password = "11111",
        //        regDato = DateTime.Parse("2005-09-01"),
        //        tolkNr = "t1"

        //        //spraak = new List<Spraak>()
        //        //{
        //        //    new Spraak()
        //        //    {
        //        //        spraak = "norsk",
        //        //        nivaa = "Top"

        //        //    }
        //        //}

        //    };

        //    var kunde = new Kunde
        //    {
        //        fornavn = "Jacob",
        //        etternavn = "Al",
        //        email = "h@hotmail.com",
        //        adresse = "stovner",
        //        regDato = DateTime.Parse("2005-09-01"),
        //        password = "1111",
        //        kundeNr = "k1"
        //    };
        //    var oppdrag1 = new Oversettelse
        //    {
        //        oppdragType = "oversettelse",
        //        oppdragsgiver = "Ahus",
        //        språkFra = "Somalisk",
        //        språkTil = "Norsk",

        //        kunde = kunde,

        //        Tolk = tolk


        //    };


        //    var oppdrag2 = new Fremmaate
        //    {
        //        oppdragType = "Frem",
        //        oppdragsgiver = "Ahus",
        //        språkFra = "Somalisk",
        //        språkTil = "Norsk",

        //        oppdragsAddres= "pilestredet 35",
        //        dato = new DateTime(2010, 8, 18),
        //        tidFra = new DateTime(2010, 8, 18,14,0,0),
        //        tidTil =new DateTime(2010, 8, 18, 14, 0, 0),

        //        kunde = kunde,

        //        Tolk = tolk

        //    };

        //    //db.Personer.Add(admin);
        //    //db.Personer.Add(tolk);
        //    //db.Personer.Add(kunde);
        //    //dbOppdrag.regOppdrag(oppdrag1);
        //    //dbOppdrag.regOppdrag(oppdrag2);
        //    dbOppdrag.slettOppdrag(2);



        //    return View(db.Personer.ToList());
        //}
    }
}