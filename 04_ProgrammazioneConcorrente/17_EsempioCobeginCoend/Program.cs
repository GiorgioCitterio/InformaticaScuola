namespace _17_EsempioCobeginCoend
{
    internal class Program
    {
        static int A, B, C, D, E, F, G, Z;
        static void Proc1()
        {
            B = 2;
            E = A + B;
            Console.WriteLine("E: {0}", E);
        }
        static void Proc2()
        {
            C = 3;
            F = A + 3 * C;
            Console.WriteLine("F: {0}", F);
        }
        static void Proc3()
        {
            D = 4;
            G = 2 * D - A;
            Console.WriteLine("G: {0}", G);
        }
        static void Main(string[] args)
        {
            A = 1;
            Parallel.Invoke(Proc1, Proc2, Proc3);
            Z = E + F + G;
            Console.WriteLine("z= " + Z);
        }
    }
}