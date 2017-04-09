using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{

    public abstract class Oppdrag
    {
        [Key]
        public int oppdragsID { get; set; }

        public DateTime  regDato { get; set; }
        public string spraakFra { get; set; }

        public string spraakTil { get; set; }
        public string oppdragType { get; set; }
        public string andreOpplisning { get; set; }

        public virtual Kunde kunde { get; set; }
        public virtual Tolk Tolk { get; set; }
        public bool sendt { get; set; }
    }


   // [Table("Fremmaate")]
    public class Tolking : Oppdrag
    {

        public string oppdragsAddres { get; set; }
        public string oppdragsDato { get; set; }
        public string tidFra { get; set; }
        public string tidTil { get; set; }
    }

   // [Table("Oversettelse")]
    public class Oversettelse : Oppdrag
    {

        public string frist { get; set; }
        public List<Fil> fil { get; set; }

    }
    //[Table("foresporelse")]
    public class Foresporsler
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int foresporselID { get; set; }

        public DateTime regDato { get; set; }
        public string spraakFra { get; set; }

        public string spraakTil { get; set; }
        public string oppdragType { get; set; }
        public string andreOpplisning { get; set; }

      
        public string oppdragsAddres { get; set; }
        public string oppdragsDato { get; set; }
        public string tidFra { get; set; }
        public string tidTil { get; set; }

       // public virtual Kunde kunde { get; set; }
        public virtual List<Tolk> Tolk { get; set; }

    }
}