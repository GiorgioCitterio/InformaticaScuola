namespace _34_EsempioAttached
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("altro task in esecuzione");
                var child = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("task nidificato parte");
                    Thread.SpinWait(500_000);
                    Console.WriteLine("task nidificato completato");
                }, TaskCreationOptions.AttachedToParent); //dico che il figlio è attaccato al papà
            });
            parent.Wait();
            Console.WriteLine("fine main");
        }
    }
}