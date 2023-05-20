using EsercizioRistorante.Model;

namespace EsercizioRistorante.ModelDTO
{
    public class RistoranteDTO
    {
        public RistoranteDTO() { }
        public RistoranteDTO(Ristorante r) =>
            (RistoranteId, Nome, Città) =
            (r.RistoranteId, r.Nome, r.Città);
        public int RistoranteId { get; set; }
        public string Nome { get; set; }
        public string Città { get; set; }
    }
}
