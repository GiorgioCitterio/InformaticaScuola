namespace EsericizioHubMerci
{
    internal class Program
    {
        static bool areaDiCaricoAperta = true;
        static SemaphoreSlim postiLiberiAreaDicarico = new SemaphoreSlim(15, 15);
        static int contatoreTirCaricati = 0;
        static int contatoreTirInAttesa = 0;
        static readonly object _lock = new object();

        static void CaricoTir()
        {
            Console.WriteLine("il tir {0} è in attesa di essere caricato", Thread.CurrentThread.ManagedThreadId);
            lock (_lock)
            {
                contatoreTirInAttesa++;
            }
            if (areaDiCaricoAperta)
            {
                postiLiberiAreaDicarico.Wait();
                Console.WriteLine("inizio a caricare un nuovo tir {0} ", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(new Random().Next(1500, 2000));
                postiLiberiAreaDicarico.Release();
                lock (_lock)
                {
                    contatoreTirCaricati++;
                    contatoreTirInAttesa--;
                    Console.WriteLine("ho caricato {0} tir e me ne mancano da caricare {1}", contatoreTirCaricati, contatoreTirInAttesa);
                }
                Console.WriteLine("posti liberi area di carico {0}", postiLiberiAreaDicarico.CurrentCount);
            }
            else
            {
                Console.WriteLine("zona di carico chiusa il tir {0} va via", Thread.CurrentThread.ManagedThreadId);
            }
        }

        static void Main(string[] args)
        {
            Thread[] tir = new Thread[40];
            for (int i = 0; i < tir.Length; i++)
            {
                tir[i] = new Thread(CaricoTir);
                tir[i].Start();
                Thread.Sleep(new Random().Next(200, 400));
            }
            Thread.Sleep(2000);
            lock (_lock)
            {
                areaDiCaricoAperta= false;
            }
            
        }
    }
}