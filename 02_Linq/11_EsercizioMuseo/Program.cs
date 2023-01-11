//OpereArtista("Picasso");
ArtistiPerNazionalità();




static void ArtistiPerNazionalità()
{
    var gruppoArtisti = artisti.GroupBy(ar => ar.Nazionalita);
    foreach (var gruppo in gruppoArtisti)
    {
        Console.WriteLine(gruppo.Key);
        foreach (var artisti in gruppo)
        {
            Console.WriteLine(artisti);
        }
        Console.WriteLine("Numero artisti "+gruppo.Count());
    }
}

static void OpereArtista(string cognomeArtista)
{
    artisti.Where(a => a.Cognome.Equals(cognomeArtista))
        .Join(opere,
        a => a.Id,
        o => o.FkArtista,
        (a, o) => new { CognomeArtista = cognomeArtista, NomeArtista = a.Nome, Titolo = o.Titolo })
        .ToList().ForEach(n => Console.WriteLine(n.CognomeArtista + " " + n.NomeArtista + " " + n.Titolo));

    artisti.Join(opere,
        a => a.Id,
        o => o.FkArtista,
        (a, o) => new { CognomeArtista = cognomeArtista, NomeArtista = a.Nome, Titolo = o.Titolo })
        //.Where(a => a.Cognome.Equals(cognomeArtista))
        .ToList().ForEach(n => Console.WriteLine(n.CognomeArtista + " " + n.NomeArtista + " " + n.Titolo));

    //terzo modo
    int idArtista = artisti.Where(ar => ar.Cognome.Equals(cognomeArtista)).First().Id;
    opere.Where(op => op.FkArtista.Equals(idArtista))
        .ToList().ForEach(ris => Console.WriteLine(ris));
}

public partial class Program
{
    static IList<Artista> artisti = new List<Artista>()
    {
        new Artista(){Id=1, Cognome="Picasso", Nome="Pablo", Nazionalita="Spagna"},
        new Artista(){Id=2, Cognome="Dalì", Nome="Salvator", Nazionalita="Spagna"},
        new Artista(){Id=3, Cognome="De Chirico", Nome="Giorgio", Nazionalita="Italia"},
        new Artista(){Id=4, Cognome="Guttuso", Nome="Renato", Nazionalita="Italia"}
    };

    static IList<Opera> opere = new List<Opera>()
    {
        new Opera(){Id=1, Titolo="Guernica", Quotazione=50000000.00m , FkArtista=1},//opera di Picasso
        new Opera(){Id=2, Titolo="I tre musici", Quotazione=15000000.00m, FkArtista=1},//opera di Picasso
        new Opera(){Id=3, Titolo="Les demoiselles d’Avignon",Quotazione=12000000.00m, FkArtista=1},//opera di Picasso
        new Opera(){Id=4, Titolo="La persistenza della memoria",Quotazione=16000000.00m, FkArtista=2},//opera di Dalì
        new Opera(){Id=5, Titolo="Metamorfosi di Narciso", Quotazione=8000000.00m,FkArtista=2},//opera di Dalì
        new Opera(){Id=6, Titolo="Le Muse inquietanti",Quotazione=22000000.00m, FkArtista=3},//opera di De Chirico
    };
    static IList<Personaggio> personaggi = new List<Personaggio>() 
    {
        new Personaggio(){Id=1, Nome="Uomo morente", FkOperaId=1},//un personaggio di Guernica
        new Personaggio(){Id=2, Nome="Un musicante", FkOperaId=2},
        new Personaggio(){Id=3, Nome="una ragazza di Avignone", FkOperaId=3},
        new Personaggio(){Id=4, Nome="una seconda ragazza di Avignone", FkOperaId=3},
        new Personaggio(){Id=5, Nome="Narciso", FkOperaId=5},
        new Personaggio(){Id=6, Nome="Una musa metafisica", FkOperaId=6},
    };
}

public class Artista
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string Cognome { get; set; }
    public string? Nazionalita { get; set; }
    public override string ToString()
    {
        return String.Format($"[ID = {Id}, Nome = {Nome}, Cognome = {Cognome}, Nazionalità = { Nazionalita}]"); 
    }
}

public class Opera
{
    public int Id { get; set; }
    public string? Titolo { get; set; }
    public decimal Quotazione { get; set; }
    public int FkArtista { get; set; }
    public override string ToString()
    {
        return String.Format($"[ID = {Id}, Titolo = {Titolo}, Quotazione = {Quotazione}, FkArtista = { FkArtista}]"); 
    }
}

public class Personaggio
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int FkOperaId { get; set; }
    public override string ToString()
    {
        return String.Format($"[ID = {Id}, Nome = {Nome}, FkOperaId = {FkOperaId}]"); ;
    }
}