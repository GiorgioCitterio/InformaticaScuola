using System.Diagnostics;

Stopwatch crono = new();
List<int> list = Enumerable.Range(0, 100).ToList();
crono.Start();
foreach (var i in list)
{
    Stampa(i);
}
crono.Stop();
Console.WriteLine("tempo impiegato per foreach sequenziale " + crono.ElapsedMilliseconds + "\n");
crono.Restart();
Parallel.ForEach(list, i =>
{
    Stampa(i);
});
crono.Stop();
Console.WriteLine("tempo impiegato per foreach parallelo " + crono.ElapsedMilliseconds + "\n");

//Console.WriteLine("foreach sequenziale");
//crono.Start();
//List<int> list = Enumerable.Range(0, 10).ToList();
//foreach (var item in list)
//{
//    long ris = SommaGrande();
//    Console.WriteLine(ris);
//}
//crono.Stop();
//Console.WriteLine("tempo impiegato per foreach sequenziale " + crono.ElapsedMilliseconds + "\n");
//Console.WriteLine("foreach parallelo");
//list = Enumerable.Range(0, 100).ToList();
//crono.Restart();
//var options = new ParallelOptions() { MaxDegreeOfParallelism = 8 };
//Parallel.ForEach(list,options, i =>
//{
//    long ris = SommaGrande();
//    Console.WriteLine(ris);
//});
//crono.Stop();
//Console.WriteLine("tempo impiegato per foreach parallelo " + crono.ElapsedMilliseconds + "\n");




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