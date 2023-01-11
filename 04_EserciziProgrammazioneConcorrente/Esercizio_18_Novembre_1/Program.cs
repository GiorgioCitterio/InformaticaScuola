namespace Esercizio_18_Novembre_1
{
    internal class Program
    {
        static int numCasse = 3;
        static SemaphoreSlim posizioniLibereCassa = new SemaphoreSlim(numCasse, numCasse);
        static void ServiClienti()
        {
            int sleep = new Random().Next(1000, 5000);
            Console.WriteLine("il cliente {0} è in attesa di essere servito",
                    Thread.CurrentThread.Name);
            posizioniLibereCassa.Wait();
            Console.WriteLine("oggetto corrente {0}",posizioniLibereCassa.CurrentCount);
            Thread.Sleep(sleep);
            Console.WriteLine("dopo {0} secondi il cliente {1} è stato servito",
                sleep, Thread.CurrentThread.Name);
            posizioniLibereCassa.Release();
        }
        static void Main(string[] args)
        {
            Thread[] clienti = new Thread[20];
            for (int i = 0; i < clienti.Length; i++)
            {
                clienti[i] = new Thread(ServiClienti)
                {
                    Name = "cliente " + i
                };
            }
            foreach (var item in clienti)
            {
                item.Start();
                Thread.Sleep(new Random().Next(1000, 5000));
            }
            foreach (var item in clienti)
            {
                item.Join();
            }
        }
    }
}