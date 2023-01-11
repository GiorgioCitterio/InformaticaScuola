namespace _12_ProduttoreConsumatoreFiFo
{
    internal class Program
    {
        static readonly object _lock = new object();
        static int bufferSize = 10;
        static int[] buffer = new int[bufferSize];
        static SemaphoreSlim emptyPosCount = new SemaphoreSlim(bufferSize, bufferSize);
        static SemaphoreSlim fillPosCount = new SemaphoreSlim(0, bufferSize);
        static int readPos = 0, writePos = 0;

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
                    buffer[writePos] = 1;
                    Console.WriteLine("aggiunto elemento in posizione {0} dal thread con id {1} e nome {2}"
                        , writePos, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name);
                    Print();
                    Console.WriteLine("celle occupate {0}", fillPosCount.CurrentCount + 1);
                    writePos = (writePos + 1) % buffer.Length;
                    fillPosCount.Release();
                }
                Thread.Sleep(1000);
            }
        }

        static void Consumatore()
        {
            while (true)
            {
                fillPosCount.Wait();
                lock (_lock)
                {
                    buffer[readPos] = 0;
                    Console.WriteLine("rimosso elemento in posizione {0} dal thread con id {1} e nome {2}"
                        , readPos, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name);
                    readPos = (readPos + 1) % buffer.Length;
                    Print();
                    Console.WriteLine("celle libere {0}", emptyPosCount.CurrentCount + 1);
                    emptyPosCount.Release();
                }
                Thread.Sleep(3000);
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
}