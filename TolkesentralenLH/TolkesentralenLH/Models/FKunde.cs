using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{
    public class FKunde
    {
        public string fornavn { get; set; }
        public string etternavn { get; set; }

        public string email { get; set; }
        public string adresse { get; set; }

        public DateTime regDato { get; set; }

        public string password { get; set; }

    }
}