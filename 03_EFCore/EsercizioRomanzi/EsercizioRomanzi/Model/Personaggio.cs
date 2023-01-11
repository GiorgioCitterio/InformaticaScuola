
namespace EsercizioRomanzi.Model;

public class Personaggio
{
    public int PersonaggioId { get; set; }
    public string Nome { get; set; }
    public int RomanzoId { get; set; }
    public Romanzo Romanzo { get; set; }
    public string Sesso { get; set; }
    public string Ruolo { get; set; }
}
