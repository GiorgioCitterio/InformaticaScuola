using EsercizioPreVerifica.Model;

namespace EsercizioPreVerifica.ModelDTO
{
    public class CinemaDTO
    {
        public CinemaDTO() { }
        public CinemaDTO(Cinema c) =>
            (CinemaId, Nome, Indirizzo, Città) =
            (c.CinemaId, c.Nome, c.Indirizzo, c.Città);
        public int CinemaId { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Città { get; set; }
    }
}
