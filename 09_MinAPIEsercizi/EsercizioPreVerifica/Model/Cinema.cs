namespace EsercizioPreVerifica.Model
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        public ICollection<Proiezione> Proieziones { get; set; } = new HashSet<Proiezione>();
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Città { get; set; }
    }
}
