
namespace EsercizioVerifica3IA.Model;

public class Pilota
{
    public int PilotaId { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public int ScuderiaId { get; set; }
    public Scuderia Scuderia { get; set; }
    public List<PuntiPiloti> PuntiPiloti { get; } = null!;
}
