namespace _13_EsercizioABBC
{
    internal class Program
    {
        static SemaphoreSlim sincA = new SemaphoreSlim(1, 1);
        static SemaphoreSlim sincB = new SemaphoreSlim(0, 1);
        static SemaphoreSlim sincC = new SemaphoreSlim(0, 1);
        static void Main(string[] args)
        {
            Thread Ta = new(() =>
            {
                while (true)
                {
                    sincA.Wait();
                    Console.Write("A");
                    sincB.Release();
                    Thread.Sleep(500);
                }
            });
            Thread Tb = new(() =>
            {
                while (true)
                {
                    sincB.Wait();
                    Console.Write("BB");

                    sincC.Release();
                    Thread.Sleep(500);
                }
            });
            Thread Tc = new(() =>
            {
                while (true)
                {
                    sincC.Wait();
                    Console.Write("C");

                    sincA.Release();
                    Console.WriteLine();
                    Thread.Sleep(500);
                }
            });
            Ta.Start();
            Tb.Start();
            Tc.Start();
            Ta.Join();
            Tb.Join();
            Tc.Join();
        }
    }
}