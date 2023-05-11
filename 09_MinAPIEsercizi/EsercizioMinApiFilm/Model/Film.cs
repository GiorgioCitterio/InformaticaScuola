namespace EsercizioMinApiFilm.Model;

public class Film
{
    public int FilmId { get; set; }
    public string Titolo { get; set; }
    public DateTime DataDiProduzione { get; set; }
    public int RegistaId { get; set; }
    public Regista Regista { get; set; }
    public int Durata { get; set; }
    public ICollection<Proiezione> Proieziones { get; set; } = new HashSet<Proiezione>();
}