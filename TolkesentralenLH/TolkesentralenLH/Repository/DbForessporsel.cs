using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TolkesentralenLH.Models;
using TolkesentralenLH.ViewModels;

namespace TolkesentralenLH.Repository
{
    public class DbForessporsel
    {

        private DbNetcont db;

        public DbForessporsel()
        {
            db = new DbNetcont();

        }



        /*****************Registerer en foresporsel på en tolk av typen Tolking eller flere tolk*****************/

        public bool regEnForesporselPåEnEllerFlereTolk(int[] tolkId, int opprdragId)
        {

            Tolking oppdrag = db.Oppdrag.OfType<Tolking>().FirstOrDefault(T => T.oppdragsID == opprdragId);
            if (oppdrag != null)
            {
                var foresp = new Foresporsler()
                {

                    foresporselID = oppdrag.oppdragsID,
                    oppdragType = oppdrag.oppdragType,
                    spraakFra = oppdrag.spraakFra,
                    spraakTil = oppdrag.spraakTil,
                    oppdragsAddres = oppdrag.oppdragsAddres,
                    regDato = oppdrag.regDato,
                    oppdragsDato = oppdrag.oppdragsDato,
                    tidFra = oppdrag.tidFra,
                    tidTil = oppdrag.tidTil,
                    andreOpplisning = oppdrag.andreOpplisning,


                };

                foreach (int tolk_ID in tolkId)
                {
                    var tolk = db.Personer.OfType<Tolk>().FirstOrDefault(T => T.persId == tolk_ID);

                    if (tolk != null)
                    {


                       tolk.foresporsler.Add(foresp);
                        oppdrag.sendt = true;
                      
                       db.SaveChanges();

                        
                    }else
                    {

                        return false;
                    }


                }

                return true;


            }


            return false;
        }


        //liste alle forespørsler som er tilsendt tolk
        public List<Tolking_vm> listTolkForesporsler()
        {


            var foresp = db.foresporelse.ToList();
            try
            {

                List<Tolking_vm> utListe = new List<Tolking_vm>();

                foreach (var rowf in foresp)
                {

                    var Tolking_vm = new Tolking_vm()
                    {
                            
                        oppdragID = rowf.foresporselID,
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


                return utListe;
            }
            catch (Exception feil)
            {
                Debug.WriteLine("Exception Message: " + feil.Message);
                return null;
            }

        }

        //lister  ut forespørseler/oppdrag som er tilsendt en tolk
        public List<Tolking_vm> listTolkForesporslerMedID(int tolkId)
        {


            Tolk tolk = db.Personer.OfType<Tolk>().FirstOrDefault(T => T.persId == tolkId);
            List<Tolking_vm> utListe = new List<Tolking_vm>();
            try
            {

                if(tolk !=null)
                {


                

                    

                    foreach (var rowf in tolk.foresporsler)
                    {



                        var Tolking_vm = new Tolking_vm()
                        {

                            oppdragID = rowf.foresporselID,
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