
using System.ComponentModel.DataAnnotations;

namespace Università.Model;

public class Docente
{
    [Key]
    public int CodDocente { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public Dipartimento Dipartimento { get; set; }
    public List<Corso> Corso { get; } = null!;
}
