
namespace _13_EsercizioGiostra
{
    internal class Program
    {
        static int giostraSize = 5;
        static int[] giostra = new int[giostraSize];
        static SemaphoreSlim contPosizioniLibere = new SemaphoreSlim(giostraSize, giostraSize);

        static void CodaGiostra()
        {
            while (true)
            {
                contPosizioniLibere.Wait();
                int num = new Random().Next(1000, 3000);
                Console.WriteLine("la persona di nome {0} con id {1} è salita sulla giostra per {2} secondi"
                    , Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, num);
                contPosizioniLibere.Release();
                Console.WriteLine("la persona di nome {0} con id {1} è scesa dalla giostra dopo {2} secondi"
                    , Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, num);
                Thread.Sleep(1000);
            }
        }
        
        static void Main(string[] args)
        {
            Thread[] threadPersone = new Thread[5];
            for (int i = 0; i < threadPersone.Length; i++)
            {
                threadPersone[i] = new Thread(CodaGiostra)
                {
                    Name = "persona" + i
                };
            }
            foreach (var item in threadPersone)
            {
                item.Start();
            }
            foreach (var item in threadPersone)
            {
                item.Join();
            }
        }
    }
}
