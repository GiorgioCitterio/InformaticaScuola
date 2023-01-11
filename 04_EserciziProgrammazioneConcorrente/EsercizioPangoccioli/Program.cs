namespace EsercizioPangoccioli
{
    internal class Program
    {
        static SemaphoreSlim SImpasta = new SemaphoreSlim(1, 1);
        static SemaphoreSlim SForma = new SemaphoreSlim(0, 1);
        static SemaphoreSlim SCuoci = new SemaphoreSlim(0, 1);
        static int i = 0;
        static void Impasta()
        {
            while (true)
            {
                SImpasta.Wait();
                Task.Delay(new Random().Next(2000, 3000)).Wait();
                Console.WriteLine("Inizio di un nuovo impasto");
                SForma.Release();
            }
        }
        static void Forma()
        {
            while (true)
            {
                SForma.Wait();
                Task.Delay(new Random().Next(1500, 2000)).Wait();
                Console.WriteLine("Inizio attività di formatura dei Pangoccioli");
                SCuoci.Release();
            }
        }
        static void Cuoci()
        {
            while (true)
            {
                SCuoci.Wait();
                Task.Delay(2000).Wait();
                Console.WriteLine("Inizio fase di cottura");
                SImpasta.Release();
                i++;
                Console.WriteLine("pangocciolo numero " + i);
            }    
        }
        static void Main(string[] args)
        {
            Task pangocciolo = Task.Run(Impasta);
            Task.Run(Forma);
            Task.Run(Cuoci);
            Task.WaitAll(pangocciolo);

        }
    }
}