using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07_AziendaApi.Model
{
    public class Sviluppatore
    {
        //chiave primaria
        public int SviluppatoreId { get; set; }

        //chiave primaria
        public int AziendaId { get; set; }
        public Azienda Azienda { get; set; } = null!;

        [Column(TypeName = "nvarchar(40)")]
        public string Nome { get; set; } = null!;

        [Column(TypeName = "nvarchar(40)")]
        public string Cognome { get; set; } = null!;
        public ICollection<SviluppaProdotto> SviluppaProdotti { get; set; } = null!;
    }
}
