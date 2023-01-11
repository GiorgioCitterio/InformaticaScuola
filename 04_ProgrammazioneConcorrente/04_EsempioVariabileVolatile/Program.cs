namespace _04_EsempioVariabileVolatile
{
    internal class Program
    {
        static volatile bool _cancel = false;
        static void Main(string[] args)
        {
            Thread t = new Thread(Speak);
            t.Start("pippo");
            Thread.Sleep(5000);
            _cancel = true;
            t.Join();
            Console.WriteLine("fine main");
        }
        static void Speak(object obj)
        {
            double i = 0;
            while (!_cancel)
            {
                string? parola = obj as string;
                Console.WriteLine(parola);
                i++;
            }
            Console.WriteLine("contatore = "+i);
        }
    }
}