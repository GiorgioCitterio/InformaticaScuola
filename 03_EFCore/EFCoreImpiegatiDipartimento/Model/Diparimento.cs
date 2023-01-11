namespace EFCoreImpiegatiDipartimento.Model;
public class Dipartimento
{
    public int DipartimentoId { get; set; }
    public string? NomeDip { get; set; }
    public List<Impiegato> Impiegato { get; } = new List<Impiegato>();
    public override string ToString()
    {
        return DipartimentoId + " " + NomeDip + " ";
    }
}
