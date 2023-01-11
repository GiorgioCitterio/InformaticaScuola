
namespace EsercizioVerifica3IA.Model;

public class PuntiPiloti
{
    public int PuntiPilotiId { get; set; }
    public int PilotaId { get; set; }
    public Pilota Pilota { get; set; }
    public int Punti { get; set; }
    public int PosizioneInGara { get; set; }
    public DateTime DataGara { get; set; }
}
