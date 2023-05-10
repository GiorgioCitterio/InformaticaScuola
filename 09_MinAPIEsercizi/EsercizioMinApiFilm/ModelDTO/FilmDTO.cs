using EsercizioMinApiFilm.Model;

namespace EsercizioMinApiFilm.ModelDTO
{
    public class FilmDTO
    {
        public FilmDTO() { }
        public FilmDTO(Film film) =>
            (FilmId, Titolo, DataDiProduzione, RegistaId, Durata) =
            (film.FilmId, film.Titolo, film.DataDiProduzione, film.RegistaId, film.Durata);
        public int FilmId { get; set; }
        public string Titolo { get; set; }
        public DateTime DataDiProduzione { get; set; }
        public int RegistaId { get; set; }
        public int Durata { get; set; }
    }
}
