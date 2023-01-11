
IsYoungerThen isYoungerThen = (s, youngAge) =>
{
    Console.WriteLine("Esempio");
    return s.Age < youngAge;
};

Student s = new()
{
    Age = 14
};
Console.WriteLine(isYoungerThen(s, 10));
//esempio uso print
Print print = () =>
{
    Console.WriteLine("Esempio stampa");
};
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

delegate bool IsYoungerThen(Student stud, int youngAge);
delegate void Print();
