using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TolkesentralenLH.ViewModels;

namespace TolkesentralenLH.Models
{
    public class DbOppdrag
    {
        private DbNetcont db;

        public DbOppdrag()
        {
            db = new DbNetcont();

        }

        public bool regTolkOppdrag(Tolking_vm nyOppdrag, int kundeId)
        {

            Kunde Bestiller = db.Personer.OfType<Kunde>().FirstOrDefault(k => k.persId == kundeId);
            if (Bestiller != null)
            {
                var oppdragDb = new Tolking()
                {

                    oppdragType = nyOppdrag.typetolk,
                    spraakFra = nyOppdrag.fraspraak,
                    spraakTil = nyOppdrag.tilspraak,
                    oppdragsAddres = nyOppdrag.sted,
                    regDato = DateTime.Now,
                    oppdragsDato = nyOppdrag.oppdragsdato,
                    tidFra = nyOppdrag.frakl,
                    tidTil = nyOppdrag.tilkl,
                    andreOpplisning = nyOppdrag.andreopplysninger,

                };

                if (Bestiller != null)
                {
                    Bestiller.oppdrag.Add(oppdragDb);
                }
                else
                {
                    return false;
                }
                db.Oppdrag.Add(oppdragDb);
                db.SaveChanges();

                return true;
            }


            return false;
        }


        public bool regOppdragOverssettelse(Oversettelse_vm nyOppdrag, int kundeId)
        {

            Kunde Bestiller = db.Personer.OfType<Kunde>().FirstOrDefault(k => k.persId == kundeId);
            if (Bestiller != null)
            {
                var oppdragDb = new Oversettelse()
                {
                  
                    spraakFra = nyOppdrag.fraspraak,
                    spraakTil = nyOppdrag.tilspraak,
                    regDato = DateTime.Now,
                    frist = nyOppdrag.frist,
                    oppdragType = nyOppdrag.typetolk,
                    andreOpplisning = nyOppdrag.andreopplysninger,
                    
                };

                //foreach(var f in nyOppdrag.fil)
                //{
                    

                //    oppdragDb.fil.Add(f);
                //}

                 

                if (Bestiller != null)
                {
                    Bestiller.oppdrag.Add(oppdragDb);
                }
                else
                {
                    return false;
                }
                db.Oppdrag.Add(oppdragDb);
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

        public List<Tolking_vm> listOppdragTolk()
        {
            // return db.Oppdrag.ToList();
            List<Tolking> alleFramaate = db.Oppdrag.OfType<Tolking>().ToList();
            try
            {

                List<Tolking_vm> vm_listeframmate = new List<Tolking_vm>();
                foreach (var rowf in alleFramaate)
                {

                    var framaater = new Tolking_vm()
                    {
                        kundeID = rowf.kunde.persId,
                        oppdragID = rowf.oppdragsID,
                        typetolk = rowf.oppdragType,
                        fraspraak = rowf.spraakFra,
                        tilspraak = rowf.spraakTil,
                        sted = rowf.oppdragsAddres,
                        oppdragsdato = rowf.oppdragsDato,
                        frakl = rowf.tidFra,
                        tilkl = rowf.tidTil,

                        andreopplysninger = rowf.andreOpplisning,


                    };
                    vm_listeframmate.Add(framaater);
                }

                return vm_listeframmate;
            }
            catch (Exception feil)
            {
                Debug.WriteLine("Exception Message: " + feil.Message);
                return null;
            }

        }


       // Lister Tolkinger som tilhører en kunde
        public List<Tolking_vm> listTolkOppdragMedKundeId(int kundeId)
        {
          
            List<Tolking> alleTolkingAvKunde = db.Oppdrag.OfType<Tolking>().ToList();
            // var lb = alleFramaate.OfType<Oppdrag>().FirstOrDefault(Opd => Opd.kunde.persId == kundeId);
            try
            {

                List<Tolking_vm> utListe = new List<Tolking_vm>();

                foreach (var rowf in alleTolkingAvKunde)
                {

                    if (rowf.kunde.persId == kundeId)
                    {

                        var Tolking_vm = new Tolking_vm()
                        {
                            kundeID = rowf.kunde.persId,
                           oppdragID = rowf.oppdragsID,
                            typetolk = rowf.oppdragType,
                            fraspraak = rowf.spraakFra,
                            tilspraak = rowf.spraakTil,
                            sted = rowf.oppdragsAddres,
                            oppdragsdato = rowf.oppdragsDato,
                            frakl = rowf.tidFra,
                            tilkl = rowf.tidTil,
                            andreopplysninger = rowf.andreOpplisning,


                        };

                        utListe.Add(Tolking_vm);


                    }

                }

                return utListe;
            }
            catch (Exception feil)
            {
                Debug.WriteLine("Exception Message: " + feil.Message);
                return null;
            }

        }




    }
}