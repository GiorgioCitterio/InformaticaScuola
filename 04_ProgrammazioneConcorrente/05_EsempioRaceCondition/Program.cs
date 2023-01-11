namespace _05_EsempioRaceCondition
{
    internal class Program
    {
        static int somma = 0; //variabile condivisa a cui accedono entrambi i thread
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    somma++;
                }
            });
            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    somma++;
                }
            });
            t1.Start();
            //t1.Join(); //funziona
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("la somma vale: "+somma);
            Console.WriteLine("fine main");
        }
    }
}