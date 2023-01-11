namespace EsercizioTeoria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "main";
            Console.WriteLine("Ciao dal thread {0}", Thread.CurrentThread.Name);
            Thread tA = new Thread(() =>
            {
                Console.WriteLine("ciao dal thread A");
                Thread.Sleep(2000);
                Thread tB = new Thread(() =>
                {
                    Console.WriteLine("ciao dal thread B");
                    Thread.Sleep(3000);
                });
                tB.Start();
                tB.Join();
            });
            tA.Start();
            tA.Join();
            Console.WriteLine("tutti i thread hanno finito");
        }
    }
}