using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TolkesentralenLH.Models
{
    public class Spraak
    {
       
        //public int spraakId{ get; set; }
    
        [Key]
        public string navn { get; set; }
        //public string nivaa { get; set; }

        public List<Tolk> tolker { get; set; }
    }
}