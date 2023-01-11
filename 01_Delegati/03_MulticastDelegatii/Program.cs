
Del a, b, c, d, k;
a = new Del(Hello);
b = Goodbye;
c = a + b + a + b;
k = null;
k += a;
k += b;
d = c - a;
//invoco i delegati
Console.WriteLine("Invoco il delegato A");
a("A");
Console.WriteLine("Invoco il delegato B");
b("B");
Console.WriteLine("Invoco il delegato C");
c("C");
Console.WriteLine("Invoco il delegato D");
d("D");
Console.WriteLine("Invoco il delegato K");
k("K");
int n = c.GetInvocationList().Length;
Console.WriteLine(n);


static void Hello(string s)
{
    Console.WriteLine("Hello " + s);
}
static void Goodbye(string s)
{
    Console.WriteLine("Goodbye " + s);
}
delegate void Del(string s);
