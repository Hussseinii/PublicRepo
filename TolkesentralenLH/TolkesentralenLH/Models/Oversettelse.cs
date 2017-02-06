using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{
    public class Oversettelse:Oppdrag
    {
        public List<Fil> fil{ get; set; }

        public String frist{ get; set; }

    }
}