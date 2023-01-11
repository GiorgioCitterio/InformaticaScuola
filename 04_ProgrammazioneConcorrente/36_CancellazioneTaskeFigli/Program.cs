using System.Collections.Concurrent;

namespace _36_CancellazioneTaskeFigli
{
    internal class Program
    {
        static void DoSomeWork(int taskNum, CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
            {
                Console.WriteLine("Task {0} was cancelled before it got started.",
                                  taskNum);
                ct.ThrowIfCancellationRequested();
            }

            int maxIterations = 100;

            for (int i = 0; i <= maxIterations; i++)
            {
                var sw = new SpinWait();
                for (int j = 0; j <= 100; j++)
                    sw.SpinOnce();

                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("Task {0} cancelled", taskNum);
                    ct.ThrowIfCancellationRequested();
                }
            }
        }
        static async Task Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var cancellationToken = tokenSource.Token;
            Task t;
            var tasks = new ConcurrentBag<Task>();
            Console.WriteLine("Press any key to begin tasks...");
            Console.ReadKey(true);
            Console.WriteLine("To terminate the example, press 'c' to cancel and exit...");

            Console.WriteLine();
            t = Task.Run(() => DoSomeWork(1, cancellationToken), cancellationToken);
            Console.WriteLine("Task {0} executing", t.Id);
            tasks.Add(t);
            t = Task.Run(() =>
            {
                Task tc;
                for (int i = 3; i <= 10; i++)
                {
                    tc = Task.Run(() => DoSomeWork(i, cancellationToken), cancellationToken);
                    Console.WriteLine("task {0} in esecuzione", t.Id);
                    tasks.Add(tc);
                    //DoSomeWork(2, cancellationToken);
                }
            }, cancellationToken);
            Console.WriteLine("task {0} in esecuzione", t.Id);
            tasks.Add(t);
            char ch = Console.ReadKey().KeyChar;
            if (ch == 'c' || ch == 'C')
            {
                tokenSource.Cancel();
                Console.WriteLine("\nTask cancellation requested.");
            }
            try
            {
                await Task.WhenAll(tasks.ToArray());
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                tokenSource.Dispose();
            }
            foreach (var task in tasks)
                Console.WriteLine("Task {0} status is now {1}", task.Id, task.Status);
        }
    }
}