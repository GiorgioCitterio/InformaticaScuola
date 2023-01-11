namespace _30_EsercizioGelateria
{
    class DatiCliente
    {
        public int? Id { get; set; }
        // memorizza l'istante in cui viene creato il Task
        public long Time { get; set; }
    }
    class DatiGelataio
    {
        public string? Nome { get; set; }
        public int Età { get; set; }
    }
    internal class Program
    {
        static int postiLiberi = 20;
        static bool aperto;
        static readonly object _lockSala = new();
        static readonly object _lockCliente = new();
        static SemaphoreSlim semCliente = new SemaphoreSlim(0, 20);
        static SemaphoreSlim gelataio = new(1, 1);
        static void Cliente(object? obj)
        {
            DatiCliente? c = obj as DatiCliente;

            bool gAperta;
            lock (_lockSala)
                gAperta = aperto;
            if (gAperta)
            {
                bool entraInSala = false;
                lock (_lockCliente)
                {
                    if (postiLiberi > 0)
                    {
                        postiLiberi--; // mi accomodo in sala d'attesa
                        entraInSala = true;
                    }
                }
                if (entraInSala)
                {
                    Console.WriteLine($"Il cliente  {c.Id} sul Task {Task.CurrentId}" +
                        $"entra in sala e aspetta di essere servito");
                    semCliente.Release();
                    Console.WriteLine($"Valore semaforo cliente {semCliente.CurrentCount}");
                    gelataio.Wait(); // attendo che il gelataio sia libero
                    double attesa = new TimeSpan(DateTime.Now.Ticks - c.Time).TotalMilliseconds;
                    Console.WriteLine($" Il cliente {c.Id} è stato servito  dal gelataio dopo {attesa:F2} millisecondi");
                }
                else
                    Console.WriteLine($"Non ci sono posti liberi, il cliente  {c.Id} va via");
            }
            else
                Console.WriteLine($"Cliente {c.Id} va via perchè la gelateria chiusa");

        }
        static void Gelataio(object? obj)
        {
            string? nome = obj as string;
            bool gAperta;
            lock (_lockSala)
            {
                gAperta = aperto;
            }
            // fino a quando il bar è aperto gestisco i clienti
            while (gAperta)
            {
                semCliente.Wait(); // aspetto che ci sia un cliente
                                   // libero un posto nella sala e servo il cliente
                lock (_lockCliente)
                {
                    postiLiberi++;
                    Console.WriteLine($"Il gelataio {nome} sta servendo il cliente  e posti liberi {postiLiberi}");

                }
                Task.Delay(1000).Wait();
                gelataio.Release();
            }

        }
        static void Gelataio1(object obj)
        {
            DatiGelataio? dati = obj as DatiGelataio;
            if (dati != null)
                Console.WriteLine("Mi chiamo " + dati.Nome + " ed ho " + dati.Età);
        }
        static void Main(string[] args)
        {
            #region Esempio Parametri al task
            //Task.Factory.StartNew((object ob) => Gelataio1(ob), new DatiGelataio { Nome="Mario",Età=20});
            //Task.Delay(2000).Wait();
            //Console.WriteLine("Fine main");
            #endregion

            // apro gelateria
            lock (_lockSala)
                aperto = true;
            // creo il gelataio
            Task.Factory.StartNew((object? obj) => Gelataio(obj), "Pippo");
            // arrivano i clienti random
            Random rand = new();
            Task[] clienti = new Task[50];
            for (int i = 0; i < clienti.Length; i++)
            {
                clienti[i] = Task.Factory.StartNew((object? obj) => Cliente(obj), new DatiCliente { Id = i, Time = DateTime.Now.Ticks });
                //Thread.Sleep(rand.Next(150, 350));
                Task.Delay(rand.Next(150, 350)).Wait();
            }

            //Thread.Sleep(12000);
            Task.Delay(12000).Wait();
            // chiudo sala
            lock (_lockSala)
            {
                aperto = false;
                Console.WriteLine("Gelateria chiusa");
            }

            // aspetto che vengano serviti tutti i clienti
            Task.WhenAll(clienti).Wait();
            Console.WriteLine("Fine main");

        }
    }
}