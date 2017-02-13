using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TolkesentralenLH.Models;

namespace TolkesentralenLH.Models
{
    public class Kunde :Person
    {
      // public int postNr { get; set; }
       
        public string kundeNr { get; set; }

        public virtual List <Oppdrag> oppdrag { get; set; }

    }
}