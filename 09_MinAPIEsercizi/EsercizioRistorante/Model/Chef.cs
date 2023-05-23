using System.ComponentModel.DataAnnotations.Schema;

namespace EsercizioRistorante.Model
{
    public class Chef
    {
        public int ChefId { get; set; }
        [Column(TypeName = "nvchar(40)")]
        public string Nome { get; set; }
        public DateTime DataDiNascita { get; set; }
        public ICollection<Portata> Portatas { get; set; } = new HashSet<Portata>();
    }
}
