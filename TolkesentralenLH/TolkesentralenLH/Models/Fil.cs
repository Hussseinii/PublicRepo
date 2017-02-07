using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TolkesentralenLH.Models
{
    public class Fil
    {
        [Key]
        public int filID { get; set; }
        public int size { get; set; }
        public string type { get; set; }

        public virtual Oppdrag  oppdrag { get; set; }


    }
}