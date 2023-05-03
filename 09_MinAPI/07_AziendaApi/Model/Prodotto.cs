using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07_AziendaApi.Model
{
    public class Prodotto
    {
        //chiave primaria
        public int ProdottoId { get; set; }

        //chiave esterna
        public int AziendaId { get; set; }

        //navigation property
        public Azienda Azienda { get; set; } = null!;

        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; } = null!;

        [Column(TypeName = "nvarchar(200)")]
        public string? Descrizione { get; set; }
        public ICollection<SviluppaProdotto> SviluppaProdotti { get; set; } = null!;
    }
}
