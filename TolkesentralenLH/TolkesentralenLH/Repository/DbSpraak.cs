using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TolkesentralenLH.Models;

namespace TolkesentralenLH.Repository
{
    public class DbSpraak
    {
        DbNetcont db = new DbNetcont();

        public bool RegSpraak(Spraak nyttSpraak)
        {
            Spraak spraak = db.Spraak.Find(nyttSpraak.navn);
            if (spraak ==null)
            {
               
                db.Spraak.Add(nyttSpraak);
                db.SaveChanges();
            }else
            {
                var nySpraak = new Spraak()
                {
                    navn = nyttSpraak.navn,

                };

                return true;

            }

            return false;
        }

        public List<Spraak> ListSpraak()
        {

            return db.Spraak.ToList();
        }



    }
}