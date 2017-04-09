using System;
using System.Collections.Generic;
using System.Data.Entity;
using TolkesentralenLH.Models;
using TolkesentralenLH.Repository;
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

                var kunde = new Kunde()
                {
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
                    email = "bob@kunde.no",
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
                    etternavn = "M",
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
                kunde3.poststed = jessheim;
                kunde4.poststed = jessheim;
                kunde5.poststed = gardermoden;
                kunde6.poststed = jessheim;

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
                admin.poststed = jessheim;
                db.Personer.Add(admin);
                db.SaveChanges();

                var spraak1 = new Spraak()
                {

                    navn = "Norsk",
                    nivaa = "F"

                };
                var spraak2 = new Spraak()
                {

                    navn = "Somalisk",
                    nivaa = "F"

                };
                var spraak3 = new Spraak()
                {

                    navn = "Lugandisk",
                    nivaa = "F"

                };

                var spraak4 = new Spraak()
                {

                    navn = "Afganisk",
                    nivaa = "F"

                };

                //db.Spraak.Add(spraak1);
                //db.Spraak.Add(spraak2);
                //db.Spraak.Add(spraak3);
                //db.Spraak.Add(spraak4);
                //db.SaveChanges();


                var tolk1 = new Tolk()
                {
                    fornavn = "TolkFornavn",
                    etternavn = "TolkEtternavn",
                    tlf = 9595995,
                    email = "tolk1@tolk.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde
                };

                var tolk2 = new Tolk()
                {
                    fornavn = "Lars",
                    etternavn = "Flexnes",
                    tlf = 9595995,
                    email = "tolk2@tolk.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde
                };

                var tolk3 = new Tolk()
                {
                    fornavn = "Bjarne",
                    etternavn = "Tolk",
                    tlf = 9595995,
                    email = "tolk3@tolk.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde
                };

                var tolk4 = new Tolk()
                {
                    fornavn = "Rambo",
                    etternavn = "Ammok",
                    tlf = 9595995,
                    email = "rambo1@tolk.no",
                    adresse = "addresse1",
                    regDato = DateTime.Now,
                    godkjent = 0,
                    password = res.lagHash("1234" + saltKunde),
                    Salt = saltKunde,
                    //spraak = {}
                };

                tolk1.poststed = jessheim;
                tolk2.poststed = jessheim;
                tolk3.poststed = jessheim;
                tolk4.poststed = jessheim;
                //db.SaveChanges();

                tolk1.spraak = new List<Spraak>();
                tolk2.spraak = new List<Spraak>();
                tolk3.spraak = new List<Spraak>();
                tolk4.spraak = new List<Spraak>();


                tolk1.spraak.Add(spraak2);
                tolk1.spraak.Add(spraak3);
                tolk1.spraak.Add(spraak4);

                tolk2.spraak.Add(spraak2);
                tolk2.spraak.Add(spraak3);
                tolk2.spraak.Add(spraak4);

                //tolk2.spraak.Add(spraak1);
                //tolk2.spraak.Add(spraak2);

                tolk3.spraak.Add(spraak2);
                tolk3.spraak.Add(spraak3);
                tolk3.spraak.Add(spraak4);

                tolk4.spraak.Add(spraak1);
                tolk4.spraak.Add(spraak2);

                db.SaveChanges();


                db.Personer.Add(tolk1);
                db.Personer.Add(tolk2);
                db.Personer.Add(tolk3);
                db.Personer.Add(tolk4);

                db.SaveChanges();




                //DateTime localDate = DateTime.Now;


                var oppdrag1 = new Tolking_vm()
                {
                    oppdragsdato = "11-05-2017",
                    dato = "12-07-2017",
                    fraspraak = "Spansk",
                    tilspraak = "Norsk",
                    andreopplysninger = "Dette er andre opplysninger",
                    typetolk = "Telefontolk",
                    sted = "HIOA pilestredet 35",
                    frakl = "13:15",
                    tilkl = "14:15",
                    
                };

                var oppdrag2 = new Tolking_vm()
                {
                    oppdragsdato = "12-05-2017",
                    dato = "12-07-2017",
                    fraspraak = "Italiensk",
                    tilspraak = "Norsk",
                    andreopplysninger = "Dette er andre opplysninger",
                    typetolk = "Fremmedmøte",
                    sted = "HIOA pilestredet 35",
                    frakl = "10:15",
                    tilkl = "12:15"
                };

                var oppdrag3 = new Tolking_vm()
                {
                    oppdragsdato = "07-05-2017",
                    dato = "12-07-2017",
                    fraspraak = "Fransk",
                    tilspraak = "Norsk",
                    andreopplysninger = "Dette er andre opplysninger",
                    typetolk = "Telefontolk",
                    sted = "HIOA pilestredet 35",
                    frakl = "11:15",
                    tilkl = "13:15"
                };
                var o = new DbOppdrag();
                var f = new DbForessporsel();
                o.regTolkOppdrag(oppdrag1, 1);
                o.regTolkOppdrag(oppdrag2, 1);
                o.regTolkOppdrag(oppdrag3, 1);

                int[] tolkId = new int[2];
                tolkId[0] = 8;
                tolkId[1] = 9;
                var ok = f.regEnForesporselPåEnEllerFlereTolk(tolkId, 1);
                db.SaveChanges();


            }
            catch (Exception e)
            {
                var breakpoint = e;
            }


        }

    }
}