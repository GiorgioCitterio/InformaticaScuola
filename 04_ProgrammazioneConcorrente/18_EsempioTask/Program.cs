namespace _18_EsempioTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "main";
            Task taskA = new(() =>
            {
                Console.WriteLine("ciao dal taskA");
            });
            Task taskB = Task.Run(() =>
            {
                Console.WriteLine("ciao dal taskB");
            });
            taskA.Start();
            Thread.Sleep(1000);
            Console.WriteLine("ciao dal thread {0}",
                Thread.CurrentThread.Name);
            taskA.Wait();
            taskB.Wait();
            Console.WriteLine("fine del thread {0}",
                Thread.CurrentThread.Name);
        }
    }
}