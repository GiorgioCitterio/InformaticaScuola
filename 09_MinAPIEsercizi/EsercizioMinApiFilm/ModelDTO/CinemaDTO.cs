using EsercizioMinApiFilm.Model;

namespace EsercizioMinApiFilm.ModelDTO;

public class CinemaDTO
{
    public CinemaDTO(){}
    public CinemaDTO(Cinema cinema) =>
        (CinemaId, Nome, Indirizzo, Città) =
        (cinema.CinemaId, cinema.Nome, cinema.Indirizzo, cinema.Città);
    public int CinemaId { get; set; }
    public string Nome { get; set; }
    public string Indirizzo { get; set; }
    public string Città { get; set; }
}