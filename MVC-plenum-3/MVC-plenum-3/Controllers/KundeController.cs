using MVC_plenum_2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_plenum_2.Controllers
{
    public class KundeController : Controller
    {
        public ActionResult Liste()
        {
            var kundeDb = new DBKunde();
            List<Kunde> alleKunder = kundeDb.hentAlle();
            return View(alleKunder);
        }

        public ActionResult Detaljer(int id)
        {
            var kundeDb = new DBKunde();
            Kunde enKunde = kundeDb.hentEnKunde(id);
            return View(enKunde);
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
                var kundeDb = new DBKunde();
                bool insertOK = kundeDb.settInn(innKunde);
                if (insertOK)
                {
                    return RedirectToAction("Liste");
                }
            }
            return View();
        }

        public ActionResult Endre(int id)
        {
            var kundeDb = new DBKunde();
            Kunde enKunde = kundeDb.hentEnKunde(id);
            return View(enKunde);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Endre(int id, Kunde endreKunde)
        {
            if (ModelState.IsValid)
            {
                var kundeDb = new DBKunde();
                bool endringOK = kundeDb.endreKunde(id, endreKunde);
                if (endringOK)
                {
                    return RedirectToAction("Liste");
                }
            }
            return View();
        }

        public void Slett(int id)
        {
            // denne kalles via et Ajax-kall
            var kundeDb = new DBKunde();
            bool slettOK = kundeDb.slettKunde(id);
            // kunne returnert en feil dersom slettingen feilet....
        }
    }
}
