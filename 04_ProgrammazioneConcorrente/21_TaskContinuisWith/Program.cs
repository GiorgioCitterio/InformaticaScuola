namespace _21_TaskContinuisWith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);
            taskA.ContinueWith(ris => Console.WriteLine("oggi è {0} ", ris.Result));
            Thread.Sleep(1000);
            Console.WriteLine("fine main");
        }
    }
}