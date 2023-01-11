namespace Esercizio_18_Novembre_3
{
    internal class Program
    {
        static int ris = 0;
        static readonly object _lock = new object();
        static void RiempiArray(int[]array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var gen = new Random().Next(1, 1000);
                array[i] = gen;
            }
        }
        static void Main(string[] args)
        {
            var gen = new Random().Next(1, 10);
            int[] array0 = new int[gen];
            int[] array1 = new int[gen];
            int[] array2 = new int[gen];
            int[] array3 = new int[gen];
            RiempiArray(array0); 
            RiempiArray(array1); 
            RiempiArray(array2);
            RiempiArray(array3);
            int[] sum = new int[4] { 0, 0, 0, 0 };
            Thread t0 = new Thread(() =>
            {
                for (int i = 0; i < array0.Length; i++)
                {
                    sum[0] += array0[i];
                    lock (_lock)
                    {
                        ris += array0[i];
                    }
                }
            });
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    sum[1] += array1[i];
                    lock (_lock)
                    {
                        ris += array1[i];
                    }
                }
            });
            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < array2.Length; i++)
                {
                    sum[2] += array2[i];
                    lock (_lock)
                    {
                        ris += array2[i];
                    }
                }
            }); Thread t3 = new Thread(() =>
            {
                for (int i = 0; i < array3.Length; i++)
                {
                    sum[3] += array3[i];
                    lock (_lock)
                    {
                        ris += array3[i];
                    }
                }
            });
            t0.Start();
            t1.Start();
            t2.Start();
            t3.Start();
            t0.Join();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("la somma vale "+ris);
        }
    }
}