// tramite la func scrivere un metodo che riceve una lista
// di studenti e un'età Et e restituisca il numero di studenti com
// età maggiore di Et.


using System.Diagnostics.Tracing;

Func<List<Student>, int, int> numeroStudenti = (lista, età) =>
{
    int conta = 0;
    foreach (var item in lista)
    {
        if (item.Age > età)
            conta++;
    }

    return conta;
};
List<Student> lista = new()
{
    new Student()
    {
        Id=1,
        Name="Pippo",
        Age=21
    },
    new()
    {
        Id=2,
        Name="Pluto",
        Age=19
    },
    new()
    {
        Id=3,
        Name="Topolino",
        Age=17
    }
};
int numStud = numeroStudenti(lista, 18);
Console.WriteLine(numStud);




class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}