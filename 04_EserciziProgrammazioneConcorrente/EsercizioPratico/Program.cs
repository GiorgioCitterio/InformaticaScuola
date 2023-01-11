namespace EsercizioPratico
{
    internal class Program
    {
        static void Impasta()
        {
            Thread.Sleep(new Random().Next(2000, 3000));
            Console.WriteLine("inizio di un nuovo impasto");
        }
        static void Forma()
        {
            Thread.Sleep(new Random().Next(1500, 2000));
            Console.WriteLine("inizio attività di formatura dei pangoccioli");
        }
        static void Cuoci()
        {
            Thread.Sleep(2000);
            Console.WriteLine("pangoccioli sfornati");
        }
        static void Main(string[] args)
        {
            int i = 1;
            while (true)
            {
                Task pangocciolo = Task.Run(Impasta);
                Task.Run(Forma);
                Task.Run(Cuoci);
                Task.WaitAll(pangocciolo);
                Console.WriteLine("pangocciolo numero " + i);
                i++;
            }
            
        }
    }
}