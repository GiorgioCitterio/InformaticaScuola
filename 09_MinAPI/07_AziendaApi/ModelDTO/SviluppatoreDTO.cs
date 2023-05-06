using _07_AziendaApi.Model;

namespace _07_AziendaApi.ModelDTO
{
    public class SviluppatoreDTO
    {
        public int SviluppatoreId { get; set; }
        public int AziendaId { get; set; }
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public SviluppatoreDTO() { }
        public SviluppatoreDTO(Sviluppatore sviluppatore) =>
            (SviluppatoreId, AziendaId, Nome, Cognome) =
            (sviluppatore.SviluppatoreId, sviluppatore.AziendaId, sviluppatore.Nome, sviluppatore.Cognome);
    }
}
