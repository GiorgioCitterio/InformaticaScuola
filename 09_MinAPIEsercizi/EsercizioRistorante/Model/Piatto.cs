using System.ComponentModel.DataAnnotations;

namespace EsercizioRistorante.Model
{
    public class Piatto
    {
        public int PiattoId { get; set; }
        public string NomePiatto { get; set; } = null!;  
        public int Costo { get; set; }
        public int RistoranteId { get; set; }
        public Ristorante Ristorante { get; set; }
        public ICollection<Portata> Portatas { get; set; } = new HashSet<Portata>();
    }
}
