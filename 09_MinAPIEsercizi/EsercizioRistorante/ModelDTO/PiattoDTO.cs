using EsercizioRistorante.Model;

namespace EsercizioRistorante.ModelDTO
{
    public class PiattoDTO
    {
        public PiattoDTO() { }
        public PiattoDTO(Piatto p) =>
            (PiattoId, NomePiatto, Costo, RistoranteId) =
            (p.PiattoId, p.NomePiatto, p.Costo, p.RistoranteId);
        public int PiattoId { get; set; }
        public string NomePiatto { get; set; }
        public int Costo { get; set; }
        public int RistoranteId { get; set; }
    }
}
