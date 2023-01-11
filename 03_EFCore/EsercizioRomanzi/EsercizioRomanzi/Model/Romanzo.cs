
namespace EsercizioRomanzi.Model;

public class Romanzo
{
    public int RomanzoId { get; set; }
    public string Titolo { get; set; }
    public int AutoreId { get; set; }
    public Autore Autore { get; set; }
    public int AnnoPubblicazione{ get; set; }
    public List<Personaggio> Personaggio { get; set; }
}
