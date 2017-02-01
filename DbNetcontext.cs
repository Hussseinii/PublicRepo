using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace TolkesentralenHL.Models
{

    public class Kunde
    {
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }

        public string Email { get; set; }
        public string Adresse { get; set; }
        public int Postnummer { get; set; }

        public string postSted { get; set; }

        public DateTime date { get; set; }

        public string Password { get; set; }
        public string kundeNrID { get; set; }

        public string Firma { get; set; }

        public List<Oppdrag> Oppdrag { get; set; }

        public List<Tolk_Tjeneste> TolkTjenester { get; set; }

        public List<Oversettelse> Oversettelser { get; set; }

        public virtual Poststeder poststeder { get; set; }

    }


    public class Administrator
    {

        public string fornavn { get; set; }
        public string etternavn { get; set; }

        public string email { get; set; }
        public string adresse { get; set; }
        public int postnummer { get; set; }

       // public string postSted { get; set; }

        public DateTime date { get; set; }

        public string password { get; set; }

        public virtual Poststeder poststed { get; set; }


    }

    public class Poststeder
    {
        public int postnummer { get; set; }

        public string postSted { get; set; }

        public virtual List<Kunde> kunder { get; set; }

        public List<Tolk> Tolker { get; set; }

        public List<Administrator> Administrator { get; set; }

    }

    public class Tolk
    {
        public string fornavn { get; set; }
        public string etternavn { get; set; }

        public string email { get; set; }
        public string adresse { get; set; }
        public int postnummer { get; set; }

        public string postSted { get; set; }

        public DateTime date { get; set; }

        public string password { get; set; }

        public virtual Poststeder poststed { get; set; }

        public List<Oppdrag> Oppdrager { get; set; }
    }

    public class Oppdrag
    {
        public int oppdragNummer { get; set; }

        public DateTime tidsrom { get; set; }

        public string oppdragsType { get; set; }

        public string oppdragsGiver { get; set; }

        public string spraak { get; set; }

        public virtual Tolk tolk { get; set; }

    }

    //public class Bestillinger
    //{
    //    public int bestillingsNummer { get; set; }
    //    public DateTime tid { get; set; }

    //    public string oppdragsType { get; set; }

    //    public string oppdragsGiver { get; set; }

    //    public string fraSpraak { get; set; }
    //    public string tilSpraak { get; set; }
    //}

    public class Tolk_Tjeneste
    {

        public string TypeTolk { get; set; }
        public string kontantPerson { get; set; }

        public DateTime tildato { get; set; }

        public DateTime fradato { get; set; }

        public string oppmooteSted { get; set; }


    }

    public class Oversettelse
    {
        public string DocumentType { get; set; }

        public string Melding { get; set; }
        // Det felte skall ha string fordi vi bestment at tiden på Oversettelse skall 
        //bestemes av admin ikke kunde. Ansatte setter tiden
        public string dato { get; set; }

       // public testarea Document { get; set; }
    }




    public class DbNetcontext : DbContext
    {
        public DbNetcontext()
            :base("name=TolkesentralenHL")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Oppdrag> Oppdrager { get; set; }

        public DbSet<Kunde>  kunder { get; set; }

        public DbSet<Tolk> Tolker { get; set; }

        public DbSet<Poststeder> poststeder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}