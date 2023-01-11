namespace _15_BarbiereAddormentatoLock
{
    internal class Program
    {
        const int numberOfSeats = 10;
        static int freeSeats = numberOfSeats;
        static readonly object _lock = new object();
        static SemaphoreSlim barberReady = new SemaphoreSlim(1, 1);
        static SemaphoreSlim clientReady = new SemaphoreSlim(0, numberOfSeats);

        static void Barber()
        {
            while (true)
            {
                clientReady.Wait(); //attesa di un cliente
                lock (_lock)
                {
                    freeSeats++; ////entro nella sezione critica e modifico la variabile condivisa
                    Console.WriteLine("Barbiere libere posto in sala");
                }
                Console.WriteLine("Taglia i capelli");
                Thread.Sleep(2000);
                barberReady.Release();
            }
        }

        static void Cliente(object nomeObj)
        {
            string nome = (string)nomeObj;
            bool clienteSiSiede = false;
            if (freeSeats > 0)
            {
                lock (_lock)
                {
                    freeSeats--;
                    Console.WriteLine("Il cliente con id {0} e nome{1} entra in sala e aspetta di essere servito, ci sono {2} posti liberi",
                        Thread.CurrentThread.ManagedThreadId, nome, freeSeats);
                    clienteSiSiede = true;
                }
            }
            if (clienteSiSiede)
            {
                clientReady.Release();
                barberReady.Wait(); //aspetta che venga servito
                Console.WriteLine("sono il cliente {0} e nome {1} mi sto tagliando i capelli e ci sono {2} posti liberi in sala",
                    Thread.CurrentThread.ManagedThreadId, nome, freeSeats);
            }
            else
            {
                //salone pieno
                Console.WriteLine("sala piena cliente {0}, nome {1} va via",
                    Thread.CurrentThread.ManagedThreadId, nome);
            }

        }

        static void Main(string[] args)
        {
            Thread barber = new Thread(Barber);
            barber.Start();
            int numeroClienti = 20;
            for (int i = 0; i < numeroClienti; i++)
            {
                new Thread(Cliente).Start("c" + i);
                Thread.Sleep(500);
            }
            barber.Join();
        }
    }
}