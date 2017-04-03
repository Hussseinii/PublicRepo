using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TolkesentralenLH.Models;
using TolkesentralenLH.Repository;

namespace TolkesentralenLH.Controllers
{
    public class SpraakController : Controller
    {
        DbSpraak db = new DbSpraak();
        // GET: Spraak
        public ActionResult RegSpraak()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RegSpraak(Spraak nyttSpraak)
        {
            if(true)
            {

                db.RegSpraak(nyttSpraak);
                
            }

            return RedirectToAction("ListSpraak");
        }

        public ActionResult ListSpraak()
        {

            return View(db.ListSpraak());
        }


    }
}