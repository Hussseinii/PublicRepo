using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{
    public class DbOppdrag
    {
        DbNetcont db = new DbNetcont();


        public DbOppdrag()
        {

        }


        public bool regOppdragF(Fremmaate oppdrag, int kundeId)
        {

            Kunde Bestiller = db.Personer.OfType<Kunde>().FirstOrDefault(k => k.persId == kundeId);
            if (oppdrag != null)
            {

                if (Bestiller != null)
                {
                    Bestiller.oppdrag.Add(oppdrag);
                }
                else
                {
                    return false;
                }
                db.Oppdrag.Add(oppdrag);
                db.SaveChanges();

                return true;
            }


            return false;
        }

        public bool regOppdragO(Oversettelse oppdrag, int kundeID)
        {
            Kunde Bestiller = db.Personer.OfType<Kunde>().FirstOrDefault(k => k.persId == kundeID);

            if (oppdrag != null)
            {
                if (Bestiller != null)
                {
                    Bestiller.oppdrag.Add(oppdrag);

                }
                else
                {
                    return false;
                }

                db.Oppdrag.Add(oppdrag);
                db.SaveChanges();

                return true;
            }


            return false;
        }


        public bool slettOppdrag(int oppdragsID)
        {
            var oppdrag = db.Oppdrag.Find(oppdragsID);

            if (oppdrag != null)
            {

                db.Oppdrag.Remove(oppdrag);
                db.SaveChanges();

                return true;
            }

            return false;
        }

        public bool endreOppdrag(Oppdrag oppdrag)
        {


            if (oppdrag != null)
            {
                db.Entry(oppdrag).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }

            return false;
        }


        public Oppdrag finnOppdrag(int? oppdragsID)
        {
            var oppdrag = db.Oppdrag.Find(oppdragsID);

            if (oppdrag != null)
            {

                return oppdrag;
            }

            return null;
        }

        public List<Oppdrag> listOppdrag()
        {

            return db.Oppdrag.ToList();

        }




    }
}