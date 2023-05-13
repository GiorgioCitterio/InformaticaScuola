using EsercizioPreVerifica.Model;

namespace EsercizioPreVerifica.ModelDTO
{
    public class FilmDTO
    {
        public FilmDTO() { }
        public FilmDTO(Film f) =>
            (FilmId, Titolo, DataDiProduzione, RegistaId, Durata) =
            (f.FilmId, f.Titolo, f.DataDiProduzione, f.RegistaId, f.Durata);
        public int FilmId { get; set; }
        public string Titolo { get; set; }
        public DateTime DataDiProduzione { get; set; }
        public int RegistaId { get; set; }
        public int Durata { get; set; }
    }
}
