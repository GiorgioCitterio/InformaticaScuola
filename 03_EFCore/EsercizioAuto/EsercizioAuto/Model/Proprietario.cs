
namespace EsercizioAuto.Model;

public class Proprietario
{
    public int ProprietarioId { get; set; }
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string CittàDiResidenza { get; set; }
    public List<Auto> Auto { get; } = null!;
}
