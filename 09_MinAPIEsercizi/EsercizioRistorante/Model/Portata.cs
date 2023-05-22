namespace EsercizioRistorante.Model
{
    public class Portata
    {
        public int ChefId { get; set; }
        public Chef Chef { get; set; }
        public int PiattoId { get; set; }
        public Piatto Piatto { get; set; }
        public int NumeroPorzioni { get; set; }
    }
}
