using EsercizioMinApiFilm.Model;

namespace EsercizioMinApiFilm.ModelDTO;

public class ProiezioneDTO
{
    public ProiezioneDTO(){}
    public ProiezioneDTO(Proiezione proiezione) =>
        (CinemaId, FilmId, Data, Ora) =
        (proiezione.CinemaId, proiezione.FilmId, proiezione.Data, proiezione.Ora);
    public int CinemaId { get; set; }
    public int FilmId { get; set; }
    public DateTime Data { get; set; }
    public int Ora { get; set; }
}