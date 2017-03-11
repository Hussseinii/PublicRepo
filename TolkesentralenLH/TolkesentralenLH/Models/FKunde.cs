using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{
    public class FKunde
    {
        
        [Required]
        [RegularExpression("/^[a-zøæåA-ZØÆÅ. \\-]{2,30}$/")]
        public string fornavn { get; set; }
        [Required]
        [RegularExpression("/^[a-zøæåA-ZØÆÅ. \\-]{2,30}$/")]
        public string etternavn { get; set; }
        [Required]
        [RegularExpression("/^[a-zæøåA-ZÆØÅ. \\-]{2,30}$/")]
        public int tlf { get; set; }
        [Required]
        [RegularExpression("/^[a-zæøåA-ZÆØÅ. \\-]{2,30}$/")]
        public string email { get; set; }
        [Required]
        [RegularExpression("/^[a-zøæåA-ZØÆÅ.0-9 \\-]{2,30}$/")]
        public string adresse { get; set; }
        [Required]
        [RegularExpression("/^[0-9]{4}$/")]
        public int postNr { get; set; }
        [Required]
        [RegularExpression("/^[a-zøæåA-ZØÆÅ. \\-]{2,30}$/")]
        public string postSted { get; set; }

        [Required]
        public string password { get; set; }
        [Required]
        [RegularExpression("/^[a-zøæåA-ZØÆÅ. \\-]{2,30}$/")]
        public string firma { get;  set; }
        [Required]
        public string kontaktperson { get; set; }
        [Required]
        public int telefax { get;  set; }
        [Required]
        [RegularExpression("/^[a-zøæåA-ZØÆÅ. \\-]{2,30}$/")]
        public string fakturaAddress { get; set; }
        
    }
}