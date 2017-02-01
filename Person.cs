using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TolkesentralenHL.Models
{
    public class Person
    {
        public string fornavn { get; set; }
        public string etternavn { get; set; }

        public string email { get; set; }
        public string adresse { get; set; }
        public int postnummer { get; set; }

        public string postSted { get; set; }

        public DateTime date { get; set; }

        public string password { get; set; }

        public string firma { get; set; }
    }
}