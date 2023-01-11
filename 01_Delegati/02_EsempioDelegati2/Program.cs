class Program
{
    public delegate double MathDelegate(double value1, double value2);
    public static double Somma(double value1, double value2)
    {
        return value1 + value2;
    }
    public static double Sottrazione(double value1, double value2)
    {
        return value1 - value2;
    }
    public static void Main(string[] args)
    {
        MathDelegate mathDelegate = Somma;
        Console.WriteLine("somma = "+mathDelegate(2, 3));
        mathDelegate = Sottrazione;
        Console.WriteLine("sottrazione = "+mathDelegate(2, 3));
    }
}