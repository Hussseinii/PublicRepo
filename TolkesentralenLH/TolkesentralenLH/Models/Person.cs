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

        public string email { get; set; }
        public string adresse { get; set; }

        public DateTime regdDato { get; set; }

        public string password { get; set; }

        public List<Poststed> poststed { get; set; }
    }
}