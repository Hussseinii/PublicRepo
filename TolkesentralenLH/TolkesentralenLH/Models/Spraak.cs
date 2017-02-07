using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TolkesentralenLH.Models
{
    public class Spraak
    {
        [Key]
        public int spraakNr{ get; set; }
        public string spraak { get; set; }
       public string nivaa { get; set; }

      
        // public List<Tolk> tolk { get; set; }
    }
}