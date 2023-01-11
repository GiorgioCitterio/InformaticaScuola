using EsercizioVerifica3IA.Data;
using EsercizioVerifica3IA.Model;
//PopolaDb();
//Query1("Italiana");
//Query2("NomePilota1Ferrari", "CognomePilota1Ferrari", DateTime.Today);
//Query3(DateTime.Today);
Query4();


static void Query1(string nazionalità)
{
    using var db = new MotorsportContext();
    db.Scuderia.Where(s => s.Nazionalità.Equals(nazionalità))
        .Join(db.Pilota,
        s => s.ScuderiaId,
        p => p.ScuderiaId,
        (s, p) => p)
        .ToList().ForEach(r => Console.WriteLine(r.Nome + " " + r.Cognome));
}

static void Query2(string nome, string cognome, DateTime dataGara)
{
    using var db = new MotorsportContext();
    db.Pilota.Where(p => p.Nome.Equals(nome) && p.Cognome.Equals(cognome))
        .Join(db.PuntiPiloti,
        p => p.PilotaId,
        pp => pp.PilotaId,
        (p, pp) => pp).Where(r => r.DataGara.Equals(dataGara))
        .ToList().ForEach(ris => Console.WriteLine(ris.Punti + "\t" + ris.PosizioneInGara));
}

static void Query3(DateTime dataGara)
{
    using var db = new MotorsportContext();
    db.PuntiPiloti.Where(p => p.DataGara.Equals(dataGara))
        .Join(db.Pilota,
        p => p.PilotaId,
        pp => pp.PilotaId,
        (p, pp) => new { pp.Nome, pp.Cognome, p.Punti, p.PosizioneInGara })
        .OrderBy(r => r.PosizioneInGara)
        .ToList().ForEach(ris => Console.WriteLine(ris.Nome + "\t" + ris.Cognome + "\t" + ris.Punti + "\t" + ris.PosizioneInGara));   
}

static void Query4()
{
    using var db = new MotorsportContext();
    var gruppi = db.PuntiPiloti.GroupBy(pp => pp.PilotaId);
    foreach (var gruppo in gruppi)
    {
        Console.WriteLine($"il pilota {gruppo.Key} ha {gruppo.Select(pp => pp.Punti).Sum()} punti");
    }
        
        
}








static void PopolaDb()
{
    using var db = new MotorsportContext();
    List<Scuderia> scuderie = new List<Scuderia>()
            {
                new Scuderia(){ScuderiaId=1, NomeScuderia="Ferrari", Nazionalità="Italiana"},
                new Scuderia(){ScuderiaId=2, NomeScuderia="McLaren", Nazionalità="Inglese"},
                new Scuderia(){ScuderiaId=3, NomeScuderia="Mercedes", Nazionalità="Tedesca"},
            };
    scuderie.ForEach(s => db.Add(s));
    db.SaveChanges();
    List<Pilota> piloti = new List<Pilota>()
            {
                new Pilota(){PilotaId=1, Nome="NomePilota1Ferrari", Cognome="CognomePilota1Ferrari", ScuderiaId=1},
                new Pilota(){PilotaId=2, Nome="NomePilota2Ferrari", Cognome="CognomePilota2Ferrari", ScuderiaId=1},
                new Pilota(){PilotaId=3, Nome="NomePilota1McLaren", Cognome="CognomePilota1McLaren", ScuderiaId=2},
                new Pilota(){PilotaId=4, Nome="NomePilota2McLaren", Cognome="CognomePilota1McLaren", ScuderiaId=2},
                new Pilota(){PilotaId=5, Nome="NomePilota1Mercedes", Cognome="CognomePilota1Mercedes", ScuderiaId=3},
                new Pilota(){PilotaId=6, Nome="NomePilota1Mercedes", Cognome="CognomePilota2Mercedes", ScuderiaId=3}
            };
    piloti.ForEach(p => db.Add(p));
    db.SaveChanges();
    List<PuntiPiloti> puntiPiloti = new List<PuntiPiloti>()
            {
                new PuntiPiloti(){PuntiPilotiId=1, PilotaId=1, Punti=10,PosizioneInGara=1,DataGara=DateTime.Today},
                new PuntiPiloti(){PuntiPilotiId=2,PilotaId=2, Punti=5, PosizioneInGara=2, DataGara=DateTime.Today},
                new PuntiPiloti(){PuntiPilotiId=3,PilotaId=3, Punti=2, PosizioneInGara=3, DataGara=DateTime.Today},
                new PuntiPiloti(){PuntiPilotiId=4,PilotaId=4, Punti=1, PosizioneInGara=4, DataGara=DateTime.Today},
                new PuntiPiloti(){PuntiPilotiId=5,PilotaId=5, Punti=0, PosizioneInGara=5, DataGara=DateTime.Today},
                new PuntiPiloti(){PuntiPilotiId=6,PilotaId=6, Punti=0, PosizioneInGara=6, DataGara=DateTime.Today},

                new PuntiPiloti(){PuntiPilotiId=7,PilotaId=4, Punti=10,PosizioneInGara=1, DataGara=DateTime.Today.AddDays(-7)},
                new PuntiPiloti(){PuntiPilotiId=8,PilotaId=2, Punti=5, PosizioneInGara=2, DataGara=DateTime.Today.AddDays(-7)},
                new PuntiPiloti(){PuntiPilotiId=9,PilotaId=1, Punti=2, PosizioneInGara=3, DataGara=DateTime.Today.AddDays(-7)},
                new PuntiPiloti(){PuntiPilotiId=10,PilotaId=5, Punti=1, PosizioneInGara=4, DataGara=DateTime.Today.AddDays(-7)},
                new PuntiPiloti(){PuntiPilotiId=11,PilotaId=6, Punti=0, PosizioneInGara=5, DataGara=DateTime.Today.AddDays(-7)},
                new PuntiPiloti(){PuntiPilotiId=12,PilotaId=3, Punti=0, PosizioneInGara=6, DataGara=DateTime.Today.AddDays(-7)},
            };
    puntiPiloti.ForEach(p => db.Add(p));
    db.SaveChanges();
}