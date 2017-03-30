using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TolkesentralenLH.Models;

namespace TolkesentralenLH.Controllers
{
    public class SpraakController : Controller
    {
        DbNetcont db = new DbNetcont();
        // GET: Spraak
        public ActionResult RegSpraak()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RegSpraak(Spraaak nyttSpraak)
        {
            if(true)
            {

                db.Spraak.Add(nyttSpraak);
                db.SaveChanges();
            }

            return RedirectToAction("ListSpraak");
        }

        public ActionResult ListSpraak()
        {
           

            return View(db.Spraak.ToList());
        }


    }
}