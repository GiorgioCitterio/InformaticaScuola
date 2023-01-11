Func<int, int, int> mathDelegate = (x, y) => x + y;
Console.WriteLine("la somma vale = "+mathDelegate(3, 4));
Func<int, bool> pariDisp = (numero) =>
{
    if (numero % 2 == 0)
        return true;
    else
        return false;
};
Console.WriteLine(pariDisp(4));
Func<Student,int, bool> maggiorenneDel = (stud, età) => stud.Age >= età;
maggiorenneDel(new() { Age = 21 }, 18);

class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}