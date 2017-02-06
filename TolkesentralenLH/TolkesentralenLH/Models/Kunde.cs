using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TolkesentralenLH.Models;

namespace TolkesentralenLH.Models
{
    public class Kunde :Person
    {
        public string kundeNr { get; set; }

        public List <Oppdrag> oppdrag { get; set; }

    }
}