using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{
    public class Fremmaate:Oppdrag
    {
        
        public int fremmaateNr { get; set; }
        public String oppdragsAddres { get; set; }
        public DateTime dato { get; set; }

        public DateTime tidFra { get; set; }

        public DateTime tidTil { get; set; }
    }
}