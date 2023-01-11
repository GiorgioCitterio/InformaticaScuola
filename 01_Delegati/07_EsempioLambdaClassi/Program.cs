
IsTeenAger isTeenAger = delegate (Student s) { return s.Age > 12 && s.Age < 20; };
Student s = new()
{
    Age = 14
};

//utilizzo la lambda
isTeenAger = st => st.Age > 12 && st.Age < 20;
s.Age = 22;
Console.WriteLine(isTeenAger(s));


class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

delegate bool IsTeenAger(Student stud);
