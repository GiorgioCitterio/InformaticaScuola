using Microsoft.VisualBasic;

namespace _29_ParallelLoopDemoResult
{
    internal class Program
    {
        private static readonly object _consoleColorLock = new object();
        static void Main(string[] args)
        {
            var rnd = new Random(50);
            int breakIndex = rnd.Next(1, 11);
            Console.WriteLine(breakIndex);
            Console.WriteLine($"I am the Main Thread with Thread Id = {Thread.CurrentThread.ManagedThreadId} and I will call Break at iteration {breakIndex}\n");
            var result = Parallel.For(1, 101, (i, state) =>
            {
                lock (_consoleColorLock)
                    Console.WriteLine($"Beginning iteration {i}");
                if (i == breakIndex)
                {
                    state.Break();
                    lock (_consoleColorLock)
                        Console.WriteLine($"Break in iteration {i}");

                }
            });
        }
    }
}