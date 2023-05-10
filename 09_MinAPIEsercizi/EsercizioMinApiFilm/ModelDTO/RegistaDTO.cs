using EsercizioMinApiFilm.Model;

namespace EsercizioMinApiFilm.ModelDTO
{
    public class RegistaDTO
    {
        public RegistaDTO() { }
        public RegistaDTO(Regista regista) =>
            (RegistaId, Nome, Cognome, Nazionalità) =
            (regista.RegistaId, regista.Nome, regista.Cognome, regista.Nazionalità);
        public int RegistaId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Nazionalità { get; set; }
    }
}
