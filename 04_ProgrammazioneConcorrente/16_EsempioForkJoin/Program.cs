namespace _16_EsempioForkJoin
{
    internal class Program
    {
        static int A, B, C, D, E, F, G, H;
        static void ProcA()
        {
            B = 20;
            E = B * 2;
            Console.WriteLine("E= "+E);
        }
        static void ProcB()
        {
            C = 30;
            F = C * C;
            Console.WriteLine("F= "+F);
        }
        static void Main(string[] args)
        {
            Thread t1 = new(ProcA);
            Thread t2 = new(ProcB);
            t1.Start();
            t2.Start();
            A = 10;
            D = A + 5;
            Console.WriteLine("D= "+D);
            t1.Join();
            G = E - D;
            Console.WriteLine("G= "+G);
            t2.Join();
            H = F + G;
            Console.WriteLine("H=" + H);
        }
    }
}