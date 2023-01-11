namespace _32_EsercizioNegozio
{
    class Program
    {
        static bool aperto = true;// aperto o chiuso
        static int capacità = 5; // num max clienti
        static int presenze = 0, presenzeTot = 0;
        static int ricavo = 0;
        static readonly object locker = new object();
        static void EntraCliente(object id)
        {
            lock (locker)
            {
                if (aperto)
                    Console.WriteLine("Negozio aperto");
            }
            while (true)
            {
                Thread.Sleep(1500);
                Console.WriteLine("Un nuovo cliente vuole entrare ");
                lock (locker)
                {
                    if (aperto)
                    {

                        if (presenze < capacità)
                        {

                            presenze++;
                            presenzeTot++;
                            Console.WriteLine($"Cliente entrato e ci sono {presenze} nel negozio");
                        }
                        else
                            Console.WriteLine($"Negozio pieno ci sono {presenze} clienti ");

                    }
                    else
                    {
                        Console.WriteLine("Negozio chiuso termina entrata");
                        break;

                    }

                }
            }
        }
        static void EsceCliente()
        {
            while (true)
            {
                Thread.Sleep(5000);
                lock (locker)
                {
                    if (aperto)
                    {
                        if (presenze >= 1)
                        {
                            ricavo += 20;
                            Console.WriteLine("Esce un cliente e paga 20 € con ricavo " + ricavo + "€");
                            presenze--;
                            Console.WriteLine($"Ci sono {presenze} clienti nel negozio ");

                        }
                        else
                            Console.WriteLine("Non ci sono più clienti nel negozio");
                    }
                    else
                    {
                        Console.WriteLine("Negozio chiuso e stanno uscendo gli ultimi clienti");
                        for (int i = presenze; i > 0; i--)
                        {
                            Console.WriteLine("Esce cliente " + i);

                            ricavo += 20;
                            Console.WriteLine("Ricavo da uscita " + ricavo + "€");
                        }
                        break;
                    }

                }
            }
        }
        static void ChiudiNegozio()
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Thread.Sleep(15000);
            lock (locker)
            {
                aperto = false;
            }
        }
        static void Main(string[] args)
        {
            Thread esceCliente = new(EsceCliente);
            Thread entraCliente = new(EntraCliente);
            Thread chiudiNegozio = new(ChiudiNegozio);
            entraCliente.Start();
            Thread.Sleep(1000);
            esceCliente.Start();
            chiudiNegozio.Start();
            entraCliente.Join();
            esceCliente.Join();
            chiudiNegozio.Join();
            Console.WriteLine("Ricavo = " + ricavo + "€");
            Console.WriteLine("Presenze totali " + presenzeTot);
            Console.WriteLine("Fine main");

        }
    }
}