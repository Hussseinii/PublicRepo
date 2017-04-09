using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TolkesentralenLH.Models
{
    public class DbNetcont:DbContext
    {

        public DbNetcont() : base("TolkesentralenDb")
        {
            Database.SetInitializer(new DBContextInitializer());

           // Database.CreateIfNotExists();
           
        }

        // public DbSet<Oppdrag> Oppdrager { get; set; }

        public DbSet<Person> Personer { get; set; }
        public DbSet<Spraak> Spraak { get; set; }
        public DbSet<Poststed> Poststeder { get; set; }
        public DbSet<Oppdrag> Oppdrag { get; set; }
        public DbSet<Fil> Filer { get; set; }
        public DbSet<Foresporsler> foresporelse { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}