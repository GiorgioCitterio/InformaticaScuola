namespace _07_AziendaApi.Model
{
    public class SviluppaProdotto
    {
        //chiave primaria esterna
        public int ProdottoId { get; set; }
        //navigation property
        public Prodotto Prodotto { get; set; } = null!;

        //chiave primaria esterna
        public int SviluppatoreId { get; set; }
        //navigation property
        public Sviluppatore Sviluppatore { get; set; } = null!;
    }
}
