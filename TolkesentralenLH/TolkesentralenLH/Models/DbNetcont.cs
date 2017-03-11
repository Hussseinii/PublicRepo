using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TolkesentralenLH.Models
{
    public class DbNetcont:DbContext
    {

        public DbNetcont() : base("TolkesentralenDb")
        {

            Database.CreateIfNotExists();
        }

        // public DbSet<Oppdrag> Oppdrager { get; set; }

        public DbSet<Person> Personer { get; set; }
        public DbSet<Spraak> Spraak { get; set; }
        public DbSet<Poststed> Poststeder { get; set; }
        public DbSet<Oppdrag> Oppdrag { get; set; }
        public DbSet<Fil> Filer { get; set; }
        public DbSet<dbBruker> Brukere { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}