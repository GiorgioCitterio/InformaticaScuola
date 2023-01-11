namespace _10_EsempioSemafori
{
    internal class Program
    {
        static SemaphoreSlim semaforo;
        static int padding;
        static readonly object _lock = new object();
        static void Main(string[] args)
        {
            semaforo = new(0, 3);
            Console.WriteLine("{0} thread che possono accedere al semaforo",
                semaforo.CurrentCount);
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new(() =>
                {
                    Console.WriteLine("thread {0} parte e attende il semaforo",
                        Thread.CurrentThread.ManagedThreadId);
                    semaforo.Wait();
                    //Interlocked.Add(ref padding, 100);
                    lock (_lock)
                    {
                        padding += 100;
                    }
                    Console.WriteLine("thread {0} è entrato nel semaforo",
                        Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000 + padding);
                    semaforo.Release();
                    Console.WriteLine("thread {0} rilascia il semaforo",
                        Thread.CurrentThread.ManagedThreadId);
                });
            }
            //start thread
            foreach(var thread in threads)
            {
                thread.Start();
            }
            Thread.Sleep(500);
            Console.WriteLine("il main setta il semaforo a 3");
            semaforo.Release(3);
            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine("alla fine il padding vale: " + padding);
        }
    }
}