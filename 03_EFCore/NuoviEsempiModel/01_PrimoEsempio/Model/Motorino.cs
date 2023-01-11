
using System.ComponentModel.DataAnnotations;

namespace _01_PrimoEsempio.Model;

public class Motorino
{
    [Key]
    public int NumeroTelaio { get; set; } //PK anche se non ha motorino, ma per la [key]
    public string? Marca { get; set; }
    public string? Modello { get; set; }
}
