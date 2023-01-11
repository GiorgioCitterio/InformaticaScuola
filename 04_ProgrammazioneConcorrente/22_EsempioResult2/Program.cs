namespace _22_EsempioResult2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<int> taskA = Task.Run(() =>
            {
                Console.WriteLine("sto eseguendo taskA");
                return 32;
            }).ContinueWith((i) =>
            {
                Console.WriteLine("ho ricevuto il 32");
                return i.Result * 2;
            });
            taskA.ContinueWith((i) =>
            {
                Console.WriteLine("ho ricevuto il 64");
                Console.WriteLine(i.Result);
            }).Wait();
            Console.WriteLine("fine");
            Console.ReadLine();
        }
    }
}