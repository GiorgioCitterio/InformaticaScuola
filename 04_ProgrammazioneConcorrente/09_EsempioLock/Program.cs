namespace _09_EsempioLock
{
    internal class Program
    {
        static int somma = 0;
        static readonly object _lock = new object();
        static void Main(string[] args)
        {
            Thread t1 = new(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    lock (_lock) //tutte le operazioni che devono essere eseguite in modo atomico
                    {
                        somma++;
                    }
                }
            });
            Thread t2 = new(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    lock (_lock)
                    {
                        somma++;
                    }
                }
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("la somma vale: "+somma);
            Console.WriteLine("fine main");
        }
    }
}