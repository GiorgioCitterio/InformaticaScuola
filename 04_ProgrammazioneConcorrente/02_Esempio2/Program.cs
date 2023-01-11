namespace Esempio2;
public class Person
{
    public void Speak(object s)
    {
        //your code here that you want to run parallel
        //most of the time it will be a CPU bound operation
        string say = s as string;
        Console.WriteLine("Sono il metodo della classe e dico " + say);
    }
}
internal class Program
{
    static void Speak(object s)
    {
        string parla = s as string;
        Console.WriteLine("Sono il metodo statico e dico " + parla);
    }
    static void Main(string[] args)
    {
        //Thread t= new Thread(Speak);
        Person p = new Person();
        Thread t = new Thread(p.Speak);
        Thread t2 = new Thread(Speak);
        t.Start("Ciao");
        t2.Start("Ciao");
        t.Join(); // il thread del main aspetta che finisca il thread t
        t2.Join();
        Console.WriteLine("Fine main");

    }
}