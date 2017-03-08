using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TolkesentralenLH.Models;

namespace TolkesentralenLH.Models
{
    public class Poststed
    {
      //hei
        
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int postNr { get; set; }

        public string postSted { get; set; }

        public virtual List<Person> person { get; set; }
    }
}