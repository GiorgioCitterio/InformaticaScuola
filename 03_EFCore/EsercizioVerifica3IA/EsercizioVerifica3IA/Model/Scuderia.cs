
namespace EsercizioVerifica3IA.Model;

public class Scuderia
{
    public int ScuderiaId { get; set; }
    public string NomeScuderia { get; set; }
    public string Nazionalità { get; set; }
    public List<Pilota> Pilota { get; } = null!;
}
