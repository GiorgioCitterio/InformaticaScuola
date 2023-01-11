
using System.ComponentModel.DataAnnotations;

namespace EsempiModel.Model;

internal class Moto
{
    [Key]
    public int Targa { get; set; }
    public string Modello { get; set; }
}
