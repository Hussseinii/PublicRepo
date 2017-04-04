using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TolkesentralenLH.Models;
using TolkesentralenLH.ViewModels;

namespace TolkesentralenLH.Models
{
    public class DBContextInitializer : DropCreateDatabaseAlways<DbNetcont>
    {
        protected override void Seed(DbNetcont db)
        {
            var res = new DbPerson();
            var saltAdmin = res.lagSalt();
            var saltKunde = res.lagSalt();
            var saltKunde2 = res.lagSalt();
            var saltKunde3 = res.lagSalt();
            var saltKunde4 = res.lagSalt();
            var saltKunde5 = res.lagSalt();
            var saltTolk = res.lagSalt();

            try
            {
                

                db.Poststeder.Add(new Poststed() { postNr = 2050, postSted = "Jessheim" });
                db.Poststeder.Add(new Poststed() { postNr = 2060, postSted = "Gardermoen" });
                db.Poststeder.Add(new Poststed() { postNr = 2601, postSted = "Lillehammer" });
                db.SaveChanges();

                //Poststed errorfix = db.Poststeder.Find("2050");

                var kunde = new Kunde() {
                    fornavn = "Emilie",
                    etternavn = "Nice",
                    tlf = 9595995,
                    email = "kunde@kunde.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde,
                    firma = "Firma1",
                    kontaktperson = "Kontaktperson",
                    telefax = 999999,
                    fakturaAddress = "fakAdresse" 
                };

                var kunde2 = new Kunde()
                {
                    fornavn = "Arock",
                    etternavn = "Star",
                    tlf = 77734969,
                    email = "rockstar@kunde.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde,
                    firma = "Firma1",
                    kontaktperson = "Kontaktperson",
                    telefax = 999999,
                    fakturaAddress = "fakAdresse"
                };

                var kunde3 = new Kunde()
                {
                    fornavn = "Franz",
                    etternavn = "Jeger",
                    tlf = 9595995,
                    email = "jeger@kunde.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde,
                    firma = "Firma1",
                    kontaktperson = "Kontaktperson",
                    telefax = 999999,
                    fakturaAddress = "fakAdresse"
                };

                var kunde4 = new Kunde()
                {
                    fornavn = "Bob",
                    etternavn = "Marley",
                    tlf = 9595995,
                    email = "kunde@kunde.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde,
                    firma = "Firma1",
                    kontaktperson = "Kontaktperson",
                    telefax = 999999,
                    fakturaAddress = "fakAdresse"
                };

                var kunde5 = new Kunde()
                {
                    fornavn = "Rassmus",
                    etternavn = "Bothholes",
                    tlf = 9595995,
                    email = "rassmus@kunde.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde,
                    firma = "Firma1",
                    kontaktperson = "Kontaktperson",
                    telefax = 999999,
                    fakturaAddress = "fakAdresse"
                };

                var kunde6 = new Kunde()
                {
                    fornavn = "Rambo",
                    etternavn = "Ammok",
                    tlf = 9595995,
                    email = "rambo@kunde.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde,
                    firma = "Firma1",
                    kontaktperson = "Kontaktperson",
                    telefax = 999999,
                    fakturaAddress = "fakAdresse"
                };

                var jessheim = db.Poststeder.Find(2050);
                var gardermoden = db.Poststeder.Find(2060);
                var lillehammer = db.Poststeder.Find(2061);
                kunde.poststed = jessheim;
                kunde2.poststed = gardermoden;
                kunde3.poststed = lillehammer;
                kunde4.poststed = jessheim;
                kunde5.poststed = gardermoden;
                kunde6.poststed = lillehammer;

                db.Personer.Add(kunde);
                db.Personer.Add(kunde2);
                db.Personer.Add(kunde3);
                db.Personer.Add(kunde4);
                db.Personer.Add(kunde5);
                db.Personer.Add(kunde6);
                db.SaveChanges();

                var admin = new Admin()
                {
                    fornavn = "AdminFornavn",
                    etternavn = "AdminEtternavn",
                    tlf = 9595995,
                    email = "admin@admin.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde
                };
                

                var tolk = new Tolk()
                {
                    fornavn = "TolkFornavn",
                    etternavn = "TolkEtternavn",
                    tlf = 9595995,
                    email = "tolk@tolk.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde
                };

                
                db.Personer.Add(admin);
                db.Personer.Add(tolk);

                db.SaveChanges();




                DateTime localDate = DateTime.Now;
                // Kunde oppdragB = db.Personer.OfType<Kunde>().FirstOrDefault(k => k.persId == 3);

                //var oppdrag1 = new Tolking_vm()
                //{
                //    oppdragsDato = "12-12-2016",
                //    oppdragType = "Telefontolk",
                //    spraakFra = "Spansk",
                //    spraakTil = "Norsk",
                //    tidFra = "12:45",
                //    tidTil = "13:45"
                //    //kunde = db.Personer.OfType<Kunde>().FirstOrDefault(k => k.persId == 1),

                //};

                var oppdrag1 = new Tolking_vm()
                {
                    fraspraak = "Spansk",
                    tilspraak = "Norsk",
                    typetolk = "Fremmøte",
                    sted = "hioa",
                    frakl = "12:45",
                    tilkl = "12:45",
                    oppdragsdato = "imorn",
                    andreopplysninger = "snarest haster"
                    //kunde = db.Personer.OfType<Kunde>().FirstOrDefault(k => k.persId == 1),

                };
                var oppdrag2 = new Oversettelse_vm()
                {
                    fraspraak = "Spansk",
                    tilspraak = "Norsk",
                    typetolk = "Fremmøte",
                    frist = "idag",
                    andreopplysninger = "snarest haster"
                   

                };
                var oppdrag3 = new Oversettelse_vm()
                {
                    fraspraak = "Spansk",
                    tilspraak = "Norsk",
                    typetolk = "Fremmøte",
                    frist = "idag",
                    andreopplysninger = "snarest haster"


                };
                var oppdrag4 = new Oversettelse_vm()
                {
                    fraspraak = "Spansk",
                    tilspraak = "Norsk",
                    typetolk = "Fremmøte",
                    frist = "idag",
                    andreopplysninger = "snarest haster"


                };

                var o = new DbOppdrag();
                o.regTolkOppdrag(oppdrag1, 1);
                o.regTolkOppdrag(oppdrag1, 1);
                o.regTolkOppdrag(oppdrag1, 1);
                o.regOppdragOverssettelse(oppdrag2, 1);
                o.regOppdragOverssettelse(oppdrag3, 1);
                o.regOppdragOverssettelse(oppdrag4, 2);

            }
            catch (Exception e)
            {
                var breakpoint = e;
            }


        }

    }
}