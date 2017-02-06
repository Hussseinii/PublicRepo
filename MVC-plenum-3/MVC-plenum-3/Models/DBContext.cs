using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVC_plenum_2.Models
{

    public class Kunder
    {
         public int ID { get; set; }
         public string Fornavn { get; set; }
         public string Etternavn { get; set; }
         public string Adresse { get; set; }
         public string Postnr { get; set; }

         public virtual Poststeder Poststeder {get;set;} 
    }
    public class Poststeder
    {
        public string Postnr { get; set; }
        public string Poststed { get; set; }

        public virtual List<Kunder> Kunder { get; set; }
    }

    public class Tolker
    {
        [Key]
        public int TolkerID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }

        public virtual Poststeder Poststeder { get; set; }

        public List<Oppdrager> Oppdrager { get; set; }

        public virtual List<Tolk_Tjeneste> Tolk_Tjenester { get; set; }
    }
    public class Oppdrager
    {
        [Key]
        public int oppdragNummer { get; set; }

        public DateTime tidsrom { get; set; }

        public string oppdragsType { get; set; }

        public string oppdragsGiver { get; set; }

        public string spraak { get; set; }

        public virtual List<Tolker> Tolker { get; set; }//changed this to list

    }

    public class Bestillinger
    {
        [Key]
        public int bestillingsNummer { get; set; }
        public DateTime tid { get; set; }

        public string oppdragsType { get; set; }

        public string oppdragsGiver { get; set; }

        public string fraSpraak { get; set; }
        public string tilSpraak { get; set; }

        public int ID { get; set; }

        public virtual List<Kunder> Kunder { get; set; }
    }

    public class Tolk_Tjeneste
    {
        [Key]
        public string TypeTolk { get; set; }
        public string kontantPerson { get; set; }

        public DateTime tildato { get; set; }

        public DateTime fradato { get; set; }

        public string oppmooteSted { get; set; }

        public virtual List<Kunder> Kunder { get; set; }


    }

    public class Administrator
    {
        [Key]
        public int AdminID { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }

        public string email { get; set; }
        public string adresse { get; set; }
        public int postnummer { get; set; }

        public string postSted { get; set; }

        public DateTime date { get; set; }

        public string password { get; set; }

        public virtual Poststeder poststed { get; set; }
        public virtual List<Kunder> Kunder { get; set; }
        public virtual List<Tolker> Tolker { get; set; }//changes this to list

        public List<Oppdrager> Oppdrager { get; set; }

        public virtual List<Tolk_Tjeneste> Tolk_Tjenester { get; set; }


    }

    public class KundeContext : DbContext
    {
        public KundeContext()
            : base("name=Kunder")
        {
            Database.CreateIfNotExists();
        }
        
        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }

        public DbSet<Oppdrager>  Oppdrager { get; set; }

        public DbSet<Tolker> Tolker { get; set; }

        public DbSet<Bestillinger> Bestillinger { get; set; }

        public DbSet<Administrator> Administratorer { get; set; }//made this change in case it goes wrong

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poststeder>()
                        .HasKey(p => p.Postnr);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}