namespace _23_SommaDeiQuadratidiNNumeri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 11;
            List<Task<int>> lista = new List<Task<int>>();
            Task<int>[] vettore = new Task<int>[n];
            for (int i = 0; i < n; i++)
            {
                int valoreBase = i;
                vettore[i] = Task.Factory.StartNew((b) =>
                //lista.Add(Task.Factory.StartNew((b) =>
                {
                    int c = (int)b;
                    return c * c;
                }, valoreBase);
            }
            //var continuation = Task.WhenAll(lista);
            var continuation = Task.WhenAll(vettore);
            long sum = 0;
            for (int ctr = 0; ctr <= continuation.Result.Length - 1; ctr++)
            {
                Console.Write($"{continuation.Result[ctr]}{(ctr == continuation.Result.Length - 1 ? " = " : " + ")}");
                sum += continuation.Result[ctr];
            }
            Console.WriteLine("la somma vale " + sum);
        }
    }
}