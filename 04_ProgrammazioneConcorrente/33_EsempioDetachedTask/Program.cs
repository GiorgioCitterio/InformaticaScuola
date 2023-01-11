namespace _33_EsempioDetachedTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parent = Task<int>.Factory.StartNew(() => 
            {
                Console.WriteLine("altro task in esecuzione");
                var child = Task<int>.Factory.StartNew(() =>
                {
                    Console.WriteLine("task nidificato parte");
                    Thread.SpinWait(500_000); //aspetta un certo numero di iterazioni
                    Console.WriteLine("task nidificato completato");
                    return 42;
                });
                return child.Result;
            });
            //parent.Wait();
            Console.WriteLine(parent.Result);
            Console.WriteLine("fine main");
        }
    }
}