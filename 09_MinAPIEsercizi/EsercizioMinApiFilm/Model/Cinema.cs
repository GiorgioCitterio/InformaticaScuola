namespace EsercizioMinApiFilm.Model;

public class Cinema
{
    public int CinemaId { get; set; }
    public string Nome { get; set; }
    public string Indirizzo { get; set; }
    public string Città { get; set; }
    public ICollection<Proiezione> Proieziones { get; set; } = new HashSet<Proiezione>();
}