using CustomExtension;
namespace _06_MetodiDiEstensione
{
    public class Program
    {
        static void Main(string[] args)
        {
            string parola = "ciao        oggi  è lunedì, è una bella giornata! come va  ? f";
            Console.WriteLine(parola);
            Console.WriteLine(parola.WordCount());
            List<string> list = new List<string>()
            {
                "Pippo",
                "Pluto",
            };
        }
    }
}

namespace CustomExtension
{
    public static class StringExtension
    {
        public static int WordCount(this String s)
        {
            //return s.Split(new char[] {' ', '.', ',', ';', '?', '!'}, StringSplitOptions.RemoveEmptyEntries).Length;
            var vettore = s.Split(new char[] { ' ', '.', ',', ';', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            return vettore.Length;
        }
    }
}