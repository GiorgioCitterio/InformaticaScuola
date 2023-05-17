using EsercizioPreVerifica.Model;

namespace EsercizioPreVerifica.ModelDTO
{
    public class ProiezioneDTO
    {
        public ProiezioneDTO() { }
        public ProiezioneDTO(Proiezione p) =>
            (CinemaId, FilmId, Data, Ora) =
            (p.CinemaId, p.FilmId, p.Data, p.Ora);
        public int CinemaId { get; set; }
        public int FilmId { get; set; }
        public DateTime Data { get; set; }
        public DateTime Ora { get; set; }
    }
}
