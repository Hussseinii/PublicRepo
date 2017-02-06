using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TolkesentralenLH
{
    public class Kunde
    {

        public int persId { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }

        public string email { get; set; }
        public string adresse { get; set; }

        public int postNr { get; set; }

        public string postSted { get; set; }

        public DateTime regdDato { get; set; }

        public string password { get; set; }
    }
}