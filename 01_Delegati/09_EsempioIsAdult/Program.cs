
IsAdult isAdult = s =>
{
    int etaMaggiorenne = 18;
    Console.WriteLine("Esempio maggiorenne");
    return s.Age >= etaMaggiorenne;
};
Console.WriteLine(isAdult(new() { Age = 21 }));



class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

delegate bool IsAdult(Student student);