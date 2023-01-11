internal class Program
{
    private static readonly object _lock = new object();
    private static int somma = 0;
    static void Main(string[] args)
    {
        Thread t1 = new(() =>
        {
            for (int i = 0; i < 10000000; i++)
            {
                Monitor.Enter(_lock); //chiude il lucchetto
                somma++; //modifica la somma
                Monitor.Exit(_lock); //apre il lucchetto
            }
        });

        Thread t2 = new(() =>
        {
            for (int i = 0; i < 10000000; i++)
            {
                Monitor.Enter(_lock); 
                somma++;
                Monitor.Exit(_lock); 
            }
        });
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Console.WriteLine("somma = "+somma);
        Console.WriteLine("fine main");
    }
}
