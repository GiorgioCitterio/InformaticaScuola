namespace _03_EsempioSleep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(SleepIndefinitily);
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("ciao "+i);
                    Thread.Sleep(500);
                }
            });
            t.Name = "pippo";
            t.Start();
            t1.Start();
            Thread.Sleep(2000); //il thread che esegue il main si mette in attesa (2 sec)
            t.Interrupt();
            t1.Join();
            t.Join();
            Console.WriteLine("fine main");
        }
        static void SleepIndefinitily() 
        {
            Console.WriteLine("Thread {0} about to sleep indefinitely ",
                Thread.CurrentThread.Name);
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Thread {0} awoken ",
                    Thread.CurrentThread.Name);
            }
            finally
            {
                Console.WriteLine("Thread {0} executing finally block ",
                    Thread.CurrentThread.Name);
            }
            Console.WriteLine("Thread {0} finish normal execution ",
                Thread.CurrentThread.Name);
        }
    }
}