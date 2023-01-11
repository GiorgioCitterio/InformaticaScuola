
MathDelegate mathDelegate = (x, y) => x + y;
var result = mathDelegate(3, 4);
Console.WriteLine("Risultato = " + result);
mathDelegate = (x, y) => x - y;
result = mathDelegate(3, 2);
Console.WriteLine("Risultato differenza = " + result);

//mathDelegate = Somma;
//result = mathDelegate(3, 4);
//Console.WriteLine(result);

mathDelegate = (a, b) =>
{
    Console.WriteLine("Sto chiamando la lambda su due righe");
    a *= 3;
    b *= 2;
    return a + b;
};
Console.WriteLine(mathDelegate(4, 4));

static double Somma(double x, double y)
{
    return x + y;
}

public delegate double MathDelegate(double value1, double value2);