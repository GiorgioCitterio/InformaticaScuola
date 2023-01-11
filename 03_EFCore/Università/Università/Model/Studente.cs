
using System.ComponentModel.DataAnnotations;

namespace Università.Model;

public class Studente
{
    [Key]
    public int Matricola { get; set; } 
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public int CorsoLaureaId { get; set; }
    public CorsoLaurea CorsoLaurea { get; set; }
    public int AnnoDiNascita { get; set; }
    public List<Frequenta> Frequenta { get; } = null!;
}
