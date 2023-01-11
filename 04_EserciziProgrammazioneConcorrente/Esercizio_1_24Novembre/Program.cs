
namespace Esercizio_1_24Novembre
{
    internal class Program
    {
        static bool aperto = true;
        static SemaphoreSlim postiLiberi = new SemaphoreSlim(5, 5);
        static int ricavoGiornaliero = 0;
        static readonly object _lock = new object();

        static void EntraCliente()
        {
            while (true)
            {
                lock (_lock)
                {
                    if (aperto == false)
                    {
                        break;
                    }
                    Console.ResetColor();
                    Console.WriteLine("il cliente {0} sta aspettando di entrare"
                        , Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1500);
                    if (aperto && postiLiberi.CurrentCount != 0)
                    {
                        postiLiberi.Wait();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("il cliente {0} è entrato nel negozio, posti liberi {1}",
                            Thread.CurrentThread.ManagedThreadId, postiLiberi.CurrentCount);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("negozio pieno il cliente {0} non entra"
                            , Thread.CurrentThread.ManagedThreadId);
                    }
                }
            }
            
        }

        static void EsceCliente()
        {
            if (aperto && postiLiberi.CurrentCount != 0)
            {
                Thread.Sleep(5500);
                lock (_lock)
                {
                    ricavoGiornaliero += 20;
                }
                postiLiberi.Release();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("il cliente {0} ha pagato 20 euro al negozio e esce posti liberi {1}"
                    , Thread.CurrentThread.ManagedThreadId,postiLiberi.CurrentCount);   
            }
        }

        static void ChiudiNegozio()
        {
            Thread.Sleep(15000);
            lock (_lock)
            {
                aperto = false;
            }
        }

        static void Main(string[] args)
        {
            int numeroClienti = 20;
            Thread negozio = new Thread(ChiudiNegozio);
            negozio.Start();
            for (int i = 0; i < numeroClienti; i++)
            {
                new Thread(EntraCliente).Start();
                new Thread(EsceCliente).Start();
                Thread.Sleep(500);
            }
            negozio.Join();
            Console.ResetColor();
            Console.WriteLine("ricavo giornaliero= " + ricavoGiornaliero);
        }
    }
}
