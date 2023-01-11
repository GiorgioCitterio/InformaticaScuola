namespace _31_EsercizioGoKart
{
    public class Info
    {
        public int Numero { get; set; }
        public string? Colore { get; set; }
    }
    internal class Program
    {
        static SemaphoreSlim postiLiberiSpogliatoio = new SemaphoreSlim(2, 2);
        static SemaphoreSlim postiLiberiPista = new SemaphoreSlim(4, 4);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}