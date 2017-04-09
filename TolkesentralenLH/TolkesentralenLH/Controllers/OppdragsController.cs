using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TolkesentralenLH.Models;
using TolkesentralenLH.ViewModels;

namespace TolkesentralenLH.Controllers
{
    public class OppdragsController : Controller
    {
        DbOppdrag dbOppdrag = new DbOppdrag();
        // GET: Oppdrags
        public ActionResult listOppdragTolk()
        {
            dbOppdrag.finnOppdrag(1);
            int[] tolkId = {8};
            var ok = dbOppdrag.regEnForesporselPåEnEllerFlereTolk(tolkId, 1);
            List<Tolking_vm> alleTolkOppdrag = dbOppdrag.listOppdragTolk();
            return View(alleTolkOppdrag);
        }

        public ActionResult listOppdragUbehandlet()
        {
          
            List<Tolking_vm> alleTolkOppdrag = dbOppdrag.listOppdragTolkUbehandlett();
            return View(alleTolkOppdrag);
        }

        public ActionResult listOppdragOversettelse()
        {

            List<Tolking_vm> alleTolkOppdrag = dbOppdrag.listOppdragTolk();
            return View(alleTolkOppdrag);
        }

        public ActionResult regOppdragTolk()
        {

            return View();
        }


        [HttpPost]
        public ActionResult regOppdragTolk(Tolking_vm nyOppdrag)
        {
            
            if (true)
            {

                bool insertOK = dbOppdrag.regTolkOppdrag(nyOppdrag, nyOppdrag.kundeID);
                if (insertOK)
                {
                    return RedirectToAction("listOppdragTolk");
                }
            }
            return View();
        }


        public ActionResult regOppdragOversettelse()
        {

            return View();
        }


        [HttpPost]
        public ActionResult regOppdragOversettelse(Oversettelse_vm nyOppdrag)
        {

            if (true)
            {

                bool insertOK = dbOppdrag.regOppdragOverssettelse(nyOppdrag, nyOppdrag.kundeID);
                if (insertOK)
                {
                    return RedirectToAction("listOppdragTolk");
                }
            }
            return View();
        }


    }
}