namespace _01_PrimoEsempi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Method();
            Thread t = new Thread(Method);
            t.Name = "primo thread";
            //t.Priority = ThreadPriority.Normal;
            Thread t1 = new Thread(Method1)
            {
                Name = "secondo thread",
                //Priority = ThreadPriority.BelowNormal,
            };
            t.Start();
            t1.Start();
            t.Join(); //con le join il main aspetta che finiscano i thread
            t1.Join();
            Console.WriteLine("fine main");
        }
        static void Method()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void Method1()
        {
            Console.WriteLine("Hello world1");
        }
    }
}