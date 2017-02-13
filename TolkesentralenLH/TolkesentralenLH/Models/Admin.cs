using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TolkesentralenLH.Models;

namespace TolkesentralenLH.Models
{
    public class Admin:Person
    {
        
        public string adminNr { get; set; }
       // public int postNr { get; set; }
    }
}