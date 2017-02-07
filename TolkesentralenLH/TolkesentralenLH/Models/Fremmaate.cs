using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{
    public class Fremmaate:Oppdrag
    {
        public String oppdragsAddres { get; set; }
        public DateTime dato { get; set; }

        public DateTime tidFra { get; set; }

        public DateTime tidTil { get; set; }
    }
}