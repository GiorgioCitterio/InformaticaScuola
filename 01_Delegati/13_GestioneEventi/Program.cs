Pub pub = new Pub();
pub.OnChange += () => Console.WriteLine("Subscriber 1");
pub.OnChange += () => Console.WriteLine("Subscriber 2");
pub.OnRise();
int x = 3;
pub.OnGetInput += (p) =>
{
    Console.WriteLine("OnGetInput invocato");
    p += x;
    Console.WriteLine("x= " + x);
    Console.WriteLine("p= " + p);
};
pub.OnGetInput += (p) =>
{
    Console.WriteLine("OnGetInput 1");
    p += x;
    p++;
    Console.WriteLine("x= " + x);
    Console.WriteLine("p= " + p);
};
pub.RaiseWithInput(5);



class Pub
{
    public event Action OnChange = delegate { };
    public event Action<int> OnGetInput = delegate { };
    public void OnRise()
    {
        OnChange();
    }
    public void RaiseWithInput(int p)
    {
        OnGetInput(p);
    }


}