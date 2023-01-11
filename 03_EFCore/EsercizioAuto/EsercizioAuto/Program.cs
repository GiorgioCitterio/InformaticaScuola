using EsercizioAuto.Data;
using EsercizioAuto.Model;
//PopolaDb();
//StampaProprietari("città 3");
//INNomeOUTMarca("nome1", "cognome1");
//StampaNumeroAutoAss("nomeAss3");
NumeroAssicurati();

static void NumeroAssicurati()
{
    using var db = new AutoContext();
    //db.Auto.Join(db.Assicurazione,
    //    a => a.AssicurazioneId,
    //    aa => aa.AssicurazioneId,
    //    (a, aa) => new() { aa.AssicurazioneId })
    //    .GroupBy(a => a.AssicurazioneId)
    //    .Select(ris => new() { NumeroAssicurazione = ris.Key, Numero = ris.Count() }).ToList()
    //    .ForEach(r => Console.WriteLine());

    db.Auto.GroupBy(a => a.Assicurazione.AssicurazioneId);
        
}

static void StampaProprietari(string cittàResidenza)
{
    using var db = new AutoContext();
    db.Proprietario.Where(p => p.CittàDiResidenza.Equals(cittàResidenza)).ToList()
        .ForEach(r => Console.WriteLine(r.ProprietarioId + " " + r.Nome + " "+ r.Cognome));
}

static void INNomeOUTMarca(string nome, string cognome)
{
    using var db = new AutoContext();
    db.Proprietario.Where(p => p.Nome.Equals(nome) && p.Cognome.Equals(cognome))
        .Join(db.Auto,
        a => a.ProprietarioId,
        p => p.ProprietarioId,
        (a, p) => p)
        .ToList().ForEach(r => Console.WriteLine(r.Targa + " " + r.Cilindrata));
}

static void StampaNumeroAutoAss(string nomeAssicurazione)
{
    using var db = new AutoContext();
    var n = db.Assicurazione.Where(a => a.Nome.Equals(nomeAssicurazione))
        .Join(db.Auto,
        a => a.AssicurazioneId,
        aa => aa.AssicurazioneId,
        (a, aa) => aa).Count();
    Console.WriteLine($"Le auto assicurate da {nomeAssicurazione} sono {n}");
}


static void PopolaDb()
{
    List<Proprietario> proprietario = new List<Proprietario>()
    {
        new(){ProprietarioId = 1, Nome = "nome1", Cognome = "cognome1", CittàDiResidenza = "città 1"},
        new(){ProprietarioId = 2, Nome = "nome2", Cognome = "cognome2", CittàDiResidenza = "città 2"},
        new(){ProprietarioId = 3, Nome = "nome3", Cognome = "cognome3", CittàDiResidenza = "città 5"},
        new(){ProprietarioId = 4, Nome = "nome4", Cognome = "cognome4", CittàDiResidenza = "città 1"},
        new(){ProprietarioId = 5, Nome = "nome5", Cognome = "cognome5", CittàDiResidenza = "città 5"}
    };
    using var db = new AutoContext();
    proprietario.ForEach(p => db.Add(p));
    db.SaveChanges();
    List<Auto> auto = new List<Auto>()
    {
        new(){Targa = "targa 1", Cilindrata = 125, Potenza = 30, ProprietarioId = 1, AssicurazioneId = 1 },
        new(){Targa = "targa 2", Cilindrata = 250, Potenza = 20, ProprietarioId = 2, AssicurazioneId = 2 },
        new(){Targa = "targa 3", Cilindrata = 120, Potenza = 10, ProprietarioId = 3, AssicurazioneId = 2 },
        new(){Targa = "targa 4", Cilindrata = 100, Potenza = 300, ProprietarioId = 4, AssicurazioneId = 3 },
        new(){Targa = "targa 5", Cilindrata = 55, Potenza = 90, ProprietarioId = 5, AssicurazioneId = 1 },
        new(){Targa = "targa 6", Cilindrata = 125, Potenza = 30, ProprietarioId = 3, AssicurazioneId = 1 },
        new(){Targa = "targa 7", Cilindrata = 250, Potenza = 20, ProprietarioId = 4, AssicurazioneId = 2 },
        new(){Targa = "targa 8", Cilindrata = 120, Potenza = 10, ProprietarioId = 1, AssicurazioneId = 3 },
        new(){Targa = "targa 9", Cilindrata = 100, Potenza = 300, ProprietarioId = 2, AssicurazioneId = 3 },
        new(){Targa = "targa 10", Cilindrata = 55, Potenza = 90, ProprietarioId = 5, AssicurazioneId = 1 }
    };
    auto.ForEach(f => db.Add(f));
    db.SaveChanges();
    List<Assicurazione> assicurazione = new List<Assicurazione>()
    {
        new(){AssicurazioneId = 1, Nome = "nomeAss1", Sede = "sede1"},
        new(){AssicurazioneId = 2, Nome = "nomeAss2", Sede = "sede2"},
        new(){AssicurazioneId = 3, Nome = "nomeAss3", Sede = "sede3"}
    };
    assicurazione.ForEach(a => db.Add(a));
    db.SaveChanges();
}