namespace _25_EsempioParallelFor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++) //esegue con un solo thread
            {
                Console.WriteLine("iterazione " + i + " eseguita dal thread {0}",
                    Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("esempio con parallelo");
            Parallel.For(0, 10, i => //esegue con più thread in parallelo
            {
                Console.WriteLine("iterazione " + i + " eseguita dal thread {0}",
                    Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(20);
            });
        }
    }
}