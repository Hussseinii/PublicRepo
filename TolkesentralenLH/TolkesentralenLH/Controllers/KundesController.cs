using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TolkesentralenLH.Models;
using TolkesentralenLH.Repository;
using TolkesentralenLH.ViewModels;

namespace TolkesentralenLH.Controllers
{
    public class KundesController : Controller
    {
        DbPerson db = new DbPerson();
        DbForessporsel db1 = new DbForessporsel();
        // GET: Kundes
        public ActionResult ListeKunde()
        {

            // List<Kunde_VM> allekunde = db.ListeAlleKunder(0);
            //return View(allekunde);
            List<Tolking_vm> allfor = db1.listTolkForesporsler();
            return View(allfor);
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
        /**********************************************************Tolk-start*****************************/
        public ActionResult RegTolk()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult RegTolk(Tolk_VM innTolk)
        {
            if (true)
            {
                var DbPerson = new DbPerson();

                bool insertOK = DbPerson.settinnTolk(innTolk);
                if (insertOK)
                {
                    return RedirectToAction("ListTolk");
                }
            }
            return View();
        }

        public ActionResult RegSpraakPåTolk()
        {


            return View();
        }

        [HttpPost]
        public ActionResult RegSpraakPåTolk(int tolkID, Spraak sp)
        {
            if (true)
            {
                var DbPerson = new DbPerson();

                bool insertOK = DbPerson.RegSprakkPåTolk(tolkID, sp);
                if (insertOK)
                {
                    return RedirectToAction("ListTolk");
                }
            }
            return View();
        }
        public ActionResult ListTolk()
        {
            
           // List<Tolk_VM> alleTolk= db.ListeAlleTolk();
            return View(db.ListeAlleTolkSomSnakkeDetSprrak(1, 2));
        }




        /**********************************************************Tolk-slutt*****************************/

    }
}