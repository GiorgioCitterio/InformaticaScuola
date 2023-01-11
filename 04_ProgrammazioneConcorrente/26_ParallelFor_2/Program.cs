using System.Diagnostics;
Stopwatch crono = new Stopwatch();

crono.Start();
List<int> lista = Enumerable.Range(1, 100).ToList();
foreach (var i in lista)
{
    Stampa(i);
}


crono.Stop();
Console.WriteLine("Tempo impiegato per forEach sequanziale" +
               crono.ElapsedMilliseconds);
crono.Restart();
Parallel.ForEach(lista, i =>
{
    Stampa(i);
});
crono.Stop();
Console.WriteLine("Tempo impiegato per forEach Parallelo" +
                crono.ElapsedMilliseconds);
//foreach (var item in lista)
//{
//    long ris = SommaGrande();
//    Console.WriteLine(ris);
//}
//crono.Stop();
//Console.WriteLine("Tempo impiegato per forEach sequanziale" +
//                crono.ElapsedMilliseconds);
//crono.Restart();
//lista = Enumerable.Range(1, 10).ToList();
//var options = new ParallelOptions() { MaxDegreeOfParallelism = 12 };
//Parallel.ForEach(lista, options,i =>
//{
//    long ris = SommaGrande();
//    Console.WriteLine(ris);
//});
//crono.Stop();
//Console.WriteLine("Tempo impiegato per forEach Parallelo" +
//                crono.ElapsedMilliseconds);




static long SommaGrande()
{
    long somma = 0;
    for (int i = 0; i < 100_000_000; i++)
    {
        somma += i;
    }
    return somma;
}
static void Stampa(int i)
{
    Console.WriteLine(i);
}