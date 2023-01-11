
namespace EsercizioAuto.Model;

public class Assicurazione
{
    public int AssicurazioneId { get; set; }
    public string Nome { get; set; }
    public string Sede { get; set; }
    public List<Auto> Auto { get; } = null!; 
}
