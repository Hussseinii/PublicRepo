
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{
    public class dbBruker
    {
        [Key]
        public string Navn { get; set; }
        public byte[] Passord { get; set; }

        public string Salt { get; set; }

    }
}