namespace Esercizio_ElementiCasuali
{
    internal class Program
    {
        static void Prog1(int[] array1)
        {
            array1 = new int[5000];
            Random gen = new Random();
            int temp;
            Parallel.For(0, array1.Length, i =>
            {
                array1[i] = gen.Next(-10, 20);
            });
            Parallel.For(0, array1.Length - 1, i =>
            {
                Parallel.For(i + 1, array1.Length, j =>
                {
                    if (array1[i] > array1[j])
                    {
                        temp = array1[j];
                        array1[j] = array1[i];
                        array1[i] = temp;
                    }
                    temp = 0;
                });
            });
            for (int i = 0; i < array1.Length; i++)
            {
                Console.Write(array1[i] + " ");
            }
        }
        static void Main(string[] args)
        {
            int[] array1 = new int[5000];
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 8 };
            Parallel.ForEach(array1, options, i =>
            {
                Prog1(array1);
            });
        }
    }
}