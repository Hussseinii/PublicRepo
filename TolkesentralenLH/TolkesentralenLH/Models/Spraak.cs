using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TolkesentralenLH.Models
{
    public class Spraak
    {
        [Key]
        public int spraakId{ get; set; }
        public string navn { get; set; }
        public string nivaa { get; set; }

        public List<Tolk> tolker { get; set; }
    }
}