using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.ViewModels
{
    public class Oppdrag_VM
    {

        public int kundeID { get; set; }
        public int oppdragID { get; set; }
        public string dato { get; set; }
        public string fraspraak { get; set; }
        public string tilspraak { get; set; }
        public string andreopplysninger { get; set; }
    }

    public class Tolking_vm : Oppdrag_VM
    {


        public string typetolk { get; set; }
        public string sted { get; set; }
        public string oppdragsdato { get; set; }

        public string frakl { get; set; }

        public string tilkl { get; set; }

    }



    public class Oversettelse_vm : Oppdrag_VM
    {

        public string frist { get; set; }
        public List<Models.Fil> fil { get; set; }




    }

    // Klassen arver Person fordi ved anonym (ikke-registrert) forespørsel må info om kunden fylles ut
    public class Oppdrag_Anonym_VM : Person_VM
    {
        public int id { get; set; }
        public string dato { get; set; }
        public string sted { get; set; }
        public string tid { get; set; }
        public string type { get; set; }
        public string fraspraak { get; set; }
        public string tilspraak { get; set; }
    }






}