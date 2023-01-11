using EsercizioRomanzi.Data;
using EsercizioRomanzi.Model;

//PopolaDb();
//AutoriPerNazionalità("Inglese");
//RomanziAutori("Owen", "Thomas");
//ContaPerNazionalità1("Inglese");
//ContaTutteNazionalità();

static void AutoriPerNazionalità(string nazionalità)
{
    using var db = new RomanziContext();
    db.Autori.Where(a => a.Nazionalità.Equals(nazionalità)).ToList()
        .ForEach(r => Console.WriteLine(r.Cognome + " " + r.Nome));
}

static void RomanziAutori(string cognome, string nome)
{
    using var db = new RomanziContext();
    db.Autori.Where(a => a.Cognome.Equals(cognome) && a.Nome.Equals(nome))
        .Join(db.Romanzi,
        a => a.AutoreId,
        r => r.AutoreId,
        (a, r) => r).ToList().ForEach(r => Console.WriteLine(r.Titolo + " "+ r.AnnoPubblicazione));
}

static void ContaPerNazionalità(string nazionalità)
{
    using var db = new RomanziContext();
    var n = db.Autori.Where(a => a.Nazionalità.Equals(nazionalità))
        .Join(db.Romanzi,
        a => a.AutoreId,
        r => r.AutoreId,
        (a, r) => r).Count();
    Console.WriteLine(n);
}

static void ContaPerNazionalità1(string nazionalità)
{
    using var db = new RomanziContext();
    var n = db.Romanzi.Where(r => r.Autore.Nazionalità.Equals(nazionalità)).Count();
    Console.WriteLine(n);
}

static void ContaTutteNazionalità()
{
    using var db = new RomanziContext();
    db.Autori.Join(db.Romanzi,
    a => a.AutoreId,
    r => r.AutoreId,
    (a, r) => new { Nazionalita = a.Nazionalità, r.RomanzoId })
    .GroupBy(r => r.Nazionalita)
    .Select(g => new { Nazionalità = g.Key, NumeroRomanzi = g.Count() })
    .ToList() 
    .ForEach(t => Console.WriteLine($"Nazionalità = {t.Nazionalità}; numero romanzi ={ t.NumeroRomanzi}"));

    db.Romanzi.GroupBy(r => r.Autore.Nazionalità)//effettuo il raggruppamento
    .Select(g => new { Nazionalità = g.Key, NumeroRomanzi = g.Count() })//calcolo la funzionegruppo - Count in questo caso
    .ToList()//restituisco il risultato all'app
    .ForEach(t => Console.WriteLine($"Nazionalità = {t.Nazionalità}; numero romanzi ={ t.NumeroRomanzi}"));//processo il risultato
}


static void Q5(string nazionalità)
{
    using var db = new RomanziContext();
    //primo modo - uso di join di join
    Console.WriteLine("Primo modo - uso di join");
    db.Autori.Where(a => a.Nazionalità != null && a.Nazionalità.Contains(nazionalità)).
    Join(db.Romanzi,
    a => a.AutoreId,
    r => r.AutoreId,
    (a, r) => new { r.RomanzoId }).
    Join(db.Personaggi,
    r => r.RomanzoId,
    p => p.RomanzoId,
    (r, p) => p).
    ToList().
    ForEach(p => Console.WriteLine($"{p.Nome} {p.Ruolo} {p.Sesso}"));
    //uso di navigation property
    Console.WriteLine("\nSecondo modo - uso di navigation property");
    db.Personaggi.Where(p => p.Romanzo.Autore.Nazionalità != null &&
    p.Romanzo.Autore.Nazionalità.Contains(nazionalità))
    .ToList()
    .ForEach(p => Console.WriteLine($"{p.Nome} {p.Ruolo} {p.Sesso}"));
}

static void NomiPersonaggi() { }

static void PopolaDb()
{
    List<Autore> autori = new List<Autore>()
    {
        new Autore() { AutoreId = 1, Nome = "Ernest", Cognome = "Hemingway",
        Nazionalità = "Americana" },//AutoreId=1
        new Autore() { AutoreId = 2, Nome = "Philip", Cognome = "Roth",
        Nazionalità = "Americana" },//AutoreId=2
        new Autore() { AutoreId = 3, Nome = "Thomas", Cognome = "Owen",
        Nazionalità = "Belga" },//AutoreId=3
        new Autore() { AutoreId = 4, Nome = "William", Cognome = "Shakespeare",
        Nazionalità = "Inglese" },//AutoreId=4
        new Autore() { AutoreId = 5, Nome = "Charles", Cognome = "Dickens",
        Nazionalità = "Inglese" },//AutoreId=5

    };
    using var db = new RomanziContext();
    autori.ForEach(a => db.Add(a));
    db.SaveChanges();
    //romanzi
    List<Romanzo> romanzi = new List<Romanzo>()
    {
        new Romanzo(){RomanzoId=1, Titolo="For Whom the Bell Tolls",
        AnnoPubblicazione=1940, AutoreId=1},//RomanzoId=1
        new Romanzo(){RomanzoId=2,Titolo="The Old Man and the Sea",
        AnnoPubblicazione=1952, AutoreId=1},
        new Romanzo(){RomanzoId=3,Titolo="A Farewell to Arms",
        AnnoPubblicazione=1929, AutoreId=1},
        new Romanzo(){RomanzoId=4,Titolo="Letting Go", AnnoPubblicazione=1962,
        AutoreId=2},
        new Romanzo(){RomanzoId=5,Titolo="When She Was Good",
        AnnoPubblicazione=1967, AutoreId=2},
        new Romanzo(){RomanzoId=6,Titolo="Destination Inconnue",
        AnnoPubblicazione=1942, AutoreId=3},
        new Romanzo(){RomanzoId=7,Titolo="Les Fruits de l'orage",
        AnnoPubblicazione=1984, AutoreId=3},
        new Romanzo(){RomanzoId=8,Titolo="Giulio Cesare",
        AnnoPubblicazione=1599, AutoreId=4},
        new Romanzo(){RomanzoId=9,Titolo="Otello", AnnoPubblicazione=1604,
        AutoreId=4},
        new Romanzo(){RomanzoId=10,Titolo="David Copperfield",
        AnnoPubblicazione=1849, AutoreId=5},
    };
    romanzi.ForEach(r => db.Add(r));
    db.SaveChanges();
    //personaggi
    List<Personaggio> personaggi = new List<Personaggio>()
    {
        new Personaggio(){PersonaggioId=1, Nome="Desdemona",
        Ruolo="Protagonista", Sesso="Femmina", RomanzoId=9},//PersonaggioId=1
        new Personaggio(){PersonaggioId=2,Nome="Jago", Ruolo="Protagonista",
        Sesso="Maschio", RomanzoId=9},
        new Personaggio(){PersonaggioId=3,Nome="Robert", Ruolo="Protagonista",
        Sesso="Maschio", RomanzoId=1},
        new Personaggio(){PersonaggioId=4,Nome="Cesare", Ruolo="Protagonista",
        Sesso="Maschio", RomanzoId=8},
        new Personaggio(){PersonaggioId=5,Nome="David", Ruolo="Protagonista",
        Sesso="Maschio", RomanzoId=10}
    };
    personaggi.ForEach(p => db.Add(p));
    db.SaveChanges();
}