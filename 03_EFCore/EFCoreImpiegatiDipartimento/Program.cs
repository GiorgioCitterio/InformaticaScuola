using EFCoreImpiegatiDipartimento.Data;
using EFCoreImpiegatiDipartimento.Model;
using var db = new DipartimentiImpiegatiContext();
var creaDati = false;
var visualizzaDip = true;
var nomeDip = "marco";
if(creaDati)
{
    var listaDipartimenti = new List<Dipartimento> 
    {
        new Dipartimento{DipartimentoId = 1, NomeDip = "informatica"},
        new Dipartimento{DipartimentoId = 2, NomeDip = "matematica"},
        new Dipartimento{DipartimentoId = 3, NomeDip = "italiano"},
        new Dipartimento{DipartimentoId = 4, NomeDip = "inglese"},
    };
    var listaImpiegati = new List<Impiegato>
    {
        new (){ImpiegatoId = 1, Cognome = "rossi", Nome = "mario", Stipendio = 1800, DipartimentoId = 1},
        new (){ImpiegatoId = 2, Cognome = "verdi", Nome = "marco", Stipendio = 2800, DipartimentoId = 3},
        new (){ImpiegatoId = 3, Cognome = "gialli", Nome = "francesco", Stipendio = 1500, DipartimentoId = 2},
        new (){ImpiegatoId = 4, Cognome = "bianchi", Nome = "giuse", Stipendio = 650, DipartimentoId = 4},
        new (){ImpiegatoId = 5, Cognome = "neri", Nome = "filippo", Stipendio = 7000, DipartimentoId = 3},
        new (){ImpiegatoId = 6, Cognome = "gialli", Nome = "sebastian", Stipendio = 700, DipartimentoId = 2},
        new (){ImpiegatoId = 7, Cognome = "arancio", Nome = "kevin", Stipendio = 3500, DipartimentoId = 4},
    };
    listaDipartimenti.ForEach(d => db.Add(d));
    db.SaveChanges();
    listaImpiegati.ForEach(i => db.Add(i));
    db.SaveChanges();
}
if (visualizzaDip)
{
    db.Dipartimenti.ToList().ForEach(d => Console.WriteLine(d));
}

db.Impiegati.Where(i => (i.Nome == nomeDip)).ToList().ForEach(i => Console.WriteLine(i));