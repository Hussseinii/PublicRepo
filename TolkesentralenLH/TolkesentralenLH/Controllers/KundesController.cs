using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TolkesentralenLH.Models;
using TolkesentralenLH.ViewModels;

namespace TolkesentralenLH.Controllers
{
    public class KundesController : Controller
    {
        DbPerson db = new DbPerson();
        // GET: Kundes
        public ActionResult ListeKunde()
        {

            List<Kunde_VM> allekunde = db.ListeAlleKunder(0);
            return View(allekunde);
        }

        public ActionResult Registrer()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Registrer(Kunde_VM innKunde)
        {
            if (true)
            {
                var DbPerson = new DbPerson();

                bool insertOK = DbPerson.settInnKunde(innKunde);
                if (insertOK)
                {
                    return RedirectToAction("ListeKunde");
                }
            }
            return View();
        }


    }
}