namespace EFCoreImpiegatiDipartimento.Model;
public class Impiegato
{
    public int ImpiegatoId { get; set; }
    public string? Cognome { get; set; }
    public string? Nome { get; set; }
    public double Stipendio { get; set; }
    public int DipartimentoId { get; set; }
    public Dipartimento? Dipartimento { get; set; }
    public override string ToString()
    {
        return Cognome + " " + Nome + " " + Stipendio;
    }
}

