namespace _20_EsempioTaskResult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = Task.Run(() =>
            {
                //tutte le operazioni che voglio
                //ultima operazione return
                return 32;
            });
            Console.WriteLine("il risultato del task è: " + task.Result); //corrispondente di thread.Join()
                                                                          //blocca e attende il risultato
            Console.WriteLine("fine main");
        }
    }
}