using System.Diagnostics;

namespace EsercizioVerifica1
{
    internal class Program
    {
        static readonly object _lock = new object();
        private static bool IsPrime(int number)
        {
            if (number <= 2)
            {
                return false;
            }
            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch= new Stopwatch();
            int ris = 0;
            stopwatch.Start();
            Parallel.For(1, 5_000_000, i =>
            {
                if(IsPrime(i))
                {
                    lock (_lock)
                    {
                        ris += i;
                    }
                }
            });
            stopwatch.Stop();
            Console.WriteLine("il risultato è {0} calcolandolo in modo parallelo ci ho messo {1}"
                ,ris,stopwatch.ElapsedMilliseconds);
            int ris2 = 0;
            stopwatch.Restart();
            for (int i = 1; i < 5_000_000; i++)
            {
                if (IsPrime(i))
                {
                    ris2 += i;
                }
            }
            stopwatch.Stop();
            Console.WriteLine("il risultato è {0} calcolandolo in modo sequenziale ci ho messo {1}"
                , ris2, stopwatch.ElapsedMilliseconds);
        }
    }
}