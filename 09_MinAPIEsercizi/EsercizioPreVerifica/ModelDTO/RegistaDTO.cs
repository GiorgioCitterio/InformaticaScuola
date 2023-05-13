using EsercizioPreVerifica.Model;

namespace EsercizioPreVerifica.ModelDTO
{
    public class RegistaDTO
    {
        public RegistaDTO() { }
        public RegistaDTO(Regista r) =>
            (RegistaId, Nome, Cognome, Nazionalità) =
            (r.RegistaId, r.Nome, r.Cognome, r.Nazionalità);
        public int RegistaId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Nazionalità { get; set; }
    }
}
