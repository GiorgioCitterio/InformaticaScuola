using System.Threading;

namespace _07_DataPartitioning
{
    internal class Program
    {
        static int[] vettore;
        static int somma1 = 0, somma2 = 0, somma3 = 0;
        static void Main(string[] args)
        {
            int length = 1000000;
            vettore = new int[length];
            for (int i = 0; i < vettore.Length; i++)
            {
                vettore[i] = i;
            }
            int dataSpilt = length / 2;
            Thread t1 = new(() =>
            {
                for (int i = 0; i < dataSpilt; i++)
                {
                    somma1 += vettore[i];
                }
            });
            Thread t2 = new(() =>
            {
                for (int i = dataSpilt; i < length; i++)
                {
                    somma2 += vettore[i];
                }
            });
            Thread t3 = new(() =>
            {
                for (int i = 0; i < length; i++)
                {
                    somma3 += i;
                }
            });
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("somma = "+(somma1+somma2));
            Console.WriteLine("somma univoca = "+somma3);

        }
    }
}