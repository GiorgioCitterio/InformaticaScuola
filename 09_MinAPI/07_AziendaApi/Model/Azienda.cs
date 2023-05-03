using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07_AziendaApi.Model
{
    public class Azienda
    {
        //chiave primaria
        public int AziendaId { get; set; }
        
        //si possono inserire al massimo 100 caratteri per questo campo
        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; } = null!;
        [Column(TypeName = "nvarchar(100)")]
        public string? Indirizzo { get; set; }

        //riferimenti alla chiavi esterne
        public ICollection<Prodotto> Prodotti { get; set; } = new HashSet<Prodotto>();
        public ICollection<Sviluppatore> Sviluppatori { get; set; } = new HashSet<Sviluppatore>();
    }
}
