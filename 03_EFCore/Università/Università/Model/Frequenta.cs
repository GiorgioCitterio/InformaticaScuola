
using System.ComponentModel.DataAnnotations;

namespace Università.Model;

public class Frequenta
{
    public int Matricola { get; set; }
    public int CodCorso { get; set; }
    public Corso Corso { get; set; }
    public Studente Studente { get; set; }
}
