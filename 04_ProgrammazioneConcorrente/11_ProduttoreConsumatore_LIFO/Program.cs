internal class Program
{
    static readonly object _lock = new object();
    static int bufferSize = 10;
    static int firstEmptyPos = 0;
    static int[] buffer = new int[bufferSize];
    static SemaphoreSlim emptyPosCount = new SemaphoreSlim(bufferSize, bufferSize);
    static SemaphoreSlim fillPosCount = new SemaphoreSlim(0, bufferSize);

    static void Print()
    {
        foreach (var item in buffer)
        {
            Console.Write(item + "\t");
        }
        Console.WriteLine();
    }
    static void Produttore()
    {
        while (true)
        {
            emptyPosCount.Wait();
            //sezione critica
            lock (_lock)
            {
                buffer[firstEmptyPos] = 1;
                Console.WriteLine("aggiunto elemento in posizione {0} dal thread con id {1} e nome {2}"
                    ,firstEmptyPos, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name);
                Print();
                firstEmptyPos++;
                fillPosCount.Release();
            }
            Thread.Sleep(200);
        }
    }
    static void Consumatore()
    {
        while (true)
        {
            fillPosCount.Wait();
            lock (_lock)
            {
                firstEmptyPos--;
                buffer[firstEmptyPos] = 0;
                Console.WriteLine("rimosso elemento in posizione {0} dal thread con id {1} e nome {2}"
                    , firstEmptyPos, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name);
                Print();
                emptyPosCount.Release();
            }
            Thread.Sleep(1500);
        }
    }
    static void Main(string[] args)
    {
        Thread threadProduttore = new(Produttore)
        {
            Name = "produttore"
        };
        Thread threadConsumatore = new(Consumatore)
        {
            Name = "consumatore"
        };
        threadProduttore.Start();
        threadConsumatore.Start();
    }
}