namespace Esercizio_18_Novembre_2
{
    internal class Program
    {
        static int numeroPosti = 20;
        static SemaphoreSlim postiLiberiParcheggio = new SemaphoreSlim(numeroPosti, numeroPosti);

        static void GestioneParcheggio()
        {
            int sleep = new Random().Next(5000, 10000);
            Console.WriteLine("l'auto {0} è in attesa di entrare nel parcheggio",
                Thread.CurrentThread.ManagedThreadId);
            postiLiberiParcheggio.Wait();
            Console.WriteLine("L'auto {0} è entrata nel parcheggio", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(sleep);
            Console.WriteLine("l'auto {0} sta uscendo dal parcheggio dopo {1} secondi",
                Thread.CurrentThread.ManagedThreadId, sleep);
            postiLiberiParcheggio.Release();
        }

        static void Main(string[] args)
        {
            Task[] auto = new Task[30];
            for (int i = 0; i < auto.Length; i++)
            {
                auto[i] = Task.Run(GestioneParcheggio);
            }
            Task.WaitAll(auto);
        }
    }
}