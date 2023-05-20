namespace EsercizioRistorante.Model
{
    public class Ristorante
    {
        public int RistoranteId { get; set; }   
        public string Nome { get; set; }
        public string Città { get; set; }
        public ICollection<Piatto> Piattos { get; set; } = new HashSet<Piatto>();
    }
}
