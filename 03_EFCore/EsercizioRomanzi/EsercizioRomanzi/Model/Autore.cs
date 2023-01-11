
namespace EsercizioRomanzi.Model;

public class Autore
{
    public int AutoreId { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Nazionalità { get; set; }
    public List<Romanzo> Romanzo { get; set; }
}
