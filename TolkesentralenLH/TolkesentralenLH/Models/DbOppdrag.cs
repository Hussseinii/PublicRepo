using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{
    public class DbOppdrag
    {
        DbNetcont db;// = new DbNetcont();


        public DbOppdrag(DbNetcont db)
        {
            this.db = db; 
        }


        public bool regOppdrag(Oppdrag oppdrag)
        {

          
            if(oppdrag !=null)
            {
               
                db.Oppdrag.Add(oppdrag);
                db.SaveChanges();
            }


            return false;
        }

        public bool slettOppdrag(int oppdragsID)
        {
            var oppdrag = db.Oppdrag.Find(oppdragsID);

            if(oppdrag!= null)
            {

                db.Oppdrag.Remove(oppdrag);
                db.SaveChanges();

                return true;
            }

            return false;
        }



    }
}