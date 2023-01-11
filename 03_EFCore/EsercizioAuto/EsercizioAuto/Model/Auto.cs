
using System.ComponentModel.DataAnnotations;

namespace EsercizioAuto.Model;

public class Auto
{
    [Key]
    public string Targa { get; set; }
    public double Cilindrata { get; set; }
    public double Potenza { get; set; }
    public int ProprietarioId { get; set; }
    public Proprietario? Proprietario { get; set; }
    public int AssicurazioneId { get; set; }
    public Assicurazione? Assicurazione { get; set; }
}
