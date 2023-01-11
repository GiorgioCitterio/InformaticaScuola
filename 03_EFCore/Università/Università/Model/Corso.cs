
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Università.Model;

public class Corso
{
    [Key]
    public int CodiceCorso {get; set; }
    public string Nome { get; set; }
    public int CodDocente { get; set; }
    [ForeignKey("CodDocente")]
    public Docente Docente { get; set; }
    public List<Frequenta> Frequenta { get; } = null!;
}
