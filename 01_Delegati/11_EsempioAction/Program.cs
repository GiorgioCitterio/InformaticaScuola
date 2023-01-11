Action<double, double> mathDelegate = (x, y) =>
{
    Console.WriteLine("la somma vale = " + (x + y));
};
mathDelegate(3.5, 5.7);
Action<Student, Student> confronto = (s1, s2) =>
{
    Console.WriteLine(s1.Age);
    Console.WriteLine(s2.Age + "\t" + s2.Name);
};
confronto(new() { Age = 21, Name = "pippo" }, new() { Age = 23, Name = "pluto" });

class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}

