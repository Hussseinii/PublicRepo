using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TolkesentralenLH.Models;

namespace TolkesentralenLH.Models
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DbNetcont>
    {
        protected override void Seed(DbNetcont db)
        {
            var sp1 = new Spraak
            {
                spraak = "norsk",
                nivaa = "Top"
            };
            var admin = new Admin
            {
                fornavn = "Hussen",
                etternavn = "Ali",
                email = "h@hotmail.com",
                adresse = "stovner",
                regdDato = DateTime.Parse("2005-09-01"),
                password = "1111",
                adminNr ="a1"

            };

            var tolk = new Tolk
            {
                fornavn = "Hussen",
                etternavn = "Ali",
                email = "h@hotmail.com",
                adresse = "stovner",
                regdDato = DateTime.Parse("2005-09-01"),
                password = "1111",
                tolkNr = "t1",
                spraak = new List<Spraak>()
                {
                    new Spraak()
                    {
                        spraak = "norsk",
                        nivaa = "Top"

                    }
                }
              
            };
            
            var kunde = new Kunder
            {
                fornavn = "Hussen",
                etternavn = "Ali",
                email = "h@hotmail.com",
                adresse = "stovner",
                regdDato = DateTime.Parse("2005-09-01"),
                password = "1111",
                kundeNr = "k1"
            };

            db.Personer.Add(admin);
            db.Personer.Add(tolk);
            db.Personer.Add(kunde);
            db.SaveChanges();


        }
           
        }



    }
