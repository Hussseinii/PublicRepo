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

        public static implicit operator List<object>(Spraak v)
        {
            throw new NotImplementedException();
        }

        // public List<Tolk> tolk { get; set; }
    }
}