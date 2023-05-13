namespace EsercizioPreVerifica.Model
{
    public class Regista
    {
        public int RegistaId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Nazionalità { get; set; }
        public ICollection<Film> Films { get; set; } = new HashSet<Film>();
    }
}
