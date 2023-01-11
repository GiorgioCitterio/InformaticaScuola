namespace Esercizio_2_24Novembre
{
    internal class Program
    {
        static SemaphoreSlim postiLiberiSpogliatoio= new SemaphoreSlim(2, 2);
        static SemaphoreSlim postiLiberiPista = new SemaphoreSlim(4, 4);
        
        static void EntraSpogliatoio()
        {
            if (postiLiberiSpogliatoio.CurrentCount != 0)
            {
                postiLiberiSpogliatoio.Wait();
                Console.WriteLine("il pilota {0} indossa la tuta, posti liberi spogliatoio {1}",
                    Thread.CurrentThread.ManagedThreadId, postiLiberiSpogliatoio.CurrentCount);
                postiLiberiSpogliatoio.Release();
                Thread.Sleep(500);
            }
            else
            {
                Console.WriteLine("spogliatoio pieno il pilota {0} attende"
                    , Thread.CurrentThread.ManagedThreadId);
            }
        }
        
        static void AccessoAllaPista()
        {
            if (postiLiberiPista.CurrentCount != 0)
            {
                postiLiberiPista.Wait();
                Console.WriteLine("il pilota {0} è entrato in pista, posti liberi in pista {1}"
                    ,Thread.CurrentThread.ManagedThreadId, postiLiberiPista.CurrentCount);
                Thread.Sleep(1500);
                Console.WriteLine("il pilota {0} ha finito i 15 giri e esce"
                    ,Thread.CurrentThread.ManagedThreadId);
                postiLiberiPista.Release();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("pista piena il pilota {0} attende"
                    , Thread.CurrentThread.ManagedThreadId);
            }
        }

        static void RitornaNelloSpogliatoio()
        {
            if (postiLiberiSpogliatoio.CurrentCount != 0)
            {
                postiLiberiSpogliatoio.Wait();
                Console.WriteLine("il pilota {0} si cambia ed esce, posti liberi spogliatoio {1}",
                    Thread.CurrentThread.ManagedThreadId, postiLiberiSpogliatoio.CurrentCount);
                postiLiberiSpogliatoio.Release();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("spogliatoio pieno il pilota {0} attende"
                    , Thread.CurrentThread.ManagedThreadId);
            }
        }
        static void Main(string[] args)
        {
            Thread[] gruppoDiAmici = new Thread[8];
            for (int i = 0; i < gruppoDiAmici.Length; i++)
            {
                gruppoDiAmici[i] = new Thread(() =>
                {
                    EntraSpogliatoio();
                    AccessoAllaPista();
                    RitornaNelloSpogliatoio();
                });
                gruppoDiAmici[i].Start();
                Thread.Sleep(500);
                //Task[] gruppoAmiciTask = new Task[8];
                //for (int i = 0; i < gruppoAmiciTask.Length; i++)
                //{
                //    gruppoAmiciTask[i] = Task.Run(() =>
                //    {
                //        EntraSpogliatoio();
                //        AccessoAllaPista();
                //        RitornaNelloSpogliatoio();
                //    });
                //}
                //Task.WaitAll(gruppoAmiciTask);
            }
        }
    }
}