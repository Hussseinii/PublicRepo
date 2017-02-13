using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TolkesentralenLH.Models;

namespace TolkesentralenLH.Models
{
    public class Tolk : Person
    {
        public string tolkNr { get; set; }
       // public int postNr { get; set; }
        public List<Spraak> spraak { get; set; }

        public List<Oppdrag> oppdrag { get; set; }


    }
}