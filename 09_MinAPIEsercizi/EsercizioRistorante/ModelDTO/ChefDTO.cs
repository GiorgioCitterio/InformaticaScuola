using EsercizioRistorante.Model;

namespace EsercizioRistorante.ModelDTO
{
    public class ChefDTO
    {
        public ChefDTO() { }
        public ChefDTO(Chef c) =>
            (ChefId, Nome, DataDiNascita) =
            (c.ChefId, c.Nome, c.DataDiNascita);
        public int ChefId { get; set; }
        public string Nome { get; set; }
        public DateTime DataDiNascita { get; set; }
    }
}
