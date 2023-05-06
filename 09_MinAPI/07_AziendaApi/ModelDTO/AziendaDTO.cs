using _07_AziendaApi.Model;

namespace _07_AziendaApi.ModelDTO
{
    //vado a creare una classe con solo i campi che voglio siano visualizzati dall'utente
    public class AziendaDTO
    {
        public int AziendaId { get; set; }
        public string Nome { get; set; } = null!;
        public string? Indirizzo { get; set; }
        public AziendaDTO() { }

        //costruttore che assegna i campi dell'azienda all'aziendaDTO
        public AziendaDTO(Azienda azienda) => 
            (AziendaId, Nome, Indirizzo) = 
            (azienda.AziendaId, azienda.Nome, azienda.Indirizzo);
    }
}
