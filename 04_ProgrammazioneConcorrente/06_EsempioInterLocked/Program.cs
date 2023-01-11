internal class Program
{
    static int somma = 0;
    static void Main(string[] args)
    {
        Thread t1 = new (() =>
        {
            for (int i = 0; i < 10000000; i++)
            {
                Interlocked.Increment(ref somma);
            }
        });
        Thread t2 = new(() =>
        {
            for (int i = 0; i < 10000000; i++)
            {
                Interlocked.Increment(ref somma);
            }
        });
        //Thread t3 = new(() =>
        //{
        //    for (int i = 0; i < 10000000; i++)
        //    {
        //        somma++;
        //    }
        //});
        t1.Start();
        t2.Start();
        //t3.Start();
        Thread.Sleep(1000);
        t1.Join();
        t2.Join();
        //t3.Join();
        Console.WriteLine("la somma vale: "+somma);
        Console.WriteLine("fine main");
    }
}