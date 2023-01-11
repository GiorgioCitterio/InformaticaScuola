namespace _35_CancellazioneAttivita
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var ct = tokenSource.Token;
            var task = Task.Run(() =>
            {
                ct.ThrowIfCancellationRequested();
                bool moreToDo = true;
                while (moreToDo)
                {
                    if (ct.IsCancellationRequested)
                    {
                        ct.ThrowIfCancellationRequested();
                    }
                }
            }, ct);
            Thread.Sleep(7000);
            tokenSource.Cancel();
            try
            {
                //task.Wait();
                await task;
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"{nameof(OperationCanceledException)} " +
                    $"thrown with message: { e.Message}");
             }
            catch (AggregateException e)
            {
                Console.WriteLine($"{nameof(AggregateException)} thrown with message:" +
                    $"{ e.Message}");
            }
            finally
            {
                tokenSource.Dispose();
            }
            Console.ReadLine();
        }
    }
}