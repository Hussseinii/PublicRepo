using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TolkesentralenLH.Models
{
    public abstract class Person
    {
        [Key]
        public int persId { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public int tlf { get; set; }
        public string email { get; set; }
        public string adresse { get; set; }
        public byte[] password { get; set; }

        public DateTime regDato { get; set; }
        public int godkjent { get; set; }
        public string Salt { get; set; }
        public virtual Poststed poststed { get; set; }
    }

    public class Admin : Person
    {


    }

    public class Kunde : Person
    {
        public string firma { get; set; }
        public string kontaktperson { get; set; }
        public int telefax { get; set; }
        public string fakturaAddress { get; set; }
      
        public virtual List<Oppdrag> oppdrag { get; set; }
    }

    public class Tolk : Person
    {
        public virtual List<Foresporsler> foresporsler { get; set; }
        public virtual List<Spraak> spraak { get; set; }
        public virtual List<Oppdrag> oppdrag { get; set; }
        
    }

}