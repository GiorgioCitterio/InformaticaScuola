using EsercizioRistorante.Model;

namespace EsercizioRistorante.ModelDTO
{
    public class PortataDTO
    {
        public PortataDTO() { }
        public PortataDTO(Portata p) =>
            (ChefId, PiattoId, NumeroPorzioni) =
            (p.ChefId, p.PiattoId, p.NumeroPorzioni);
        public int ChefId { get; set; }
        public int PiattoId { get; set; }
        public int NumeroPorzioni { get; set; }
    }
}
