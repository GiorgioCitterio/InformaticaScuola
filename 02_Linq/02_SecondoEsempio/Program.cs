Student[] studentArray = {
new Student() { StudentID = 1, StudentName = "John", Age = 18 },
new Student() { StudentID = 2, StudentName = "Steve", Age = 21 },
new Student() { StudentID = 3, StudentName = "Bill", Age = 25 },
new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 },
new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 },
new Student() { StudentID = 6, StudentName = "Chris", Age = 17 },
new Student() { StudentID = 7, StudentName = "Rob",Age = 19 },
};

//come andrebbe fatto senza Linq
Student[] students = new Student[10];
int i = 0;
foreach (Student std in studentArray)
{
    if (std.Age > 12 && std.Age < 20)
    {
        students[i] = std;
        i++;
    }
}
//write result
foreach (var studente in students)
{
    Console.WriteLine(studente);
}
Console.ReadLine();

class Student
{
    public int StudentID { get; set; }
    public String? StudentName { get; set; }
    public int Age { get; set; }
    public override string ToString()
    {
        return String.Format($"[StudentID = {StudentID}, StudentName = {StudentName}, Age = {Age}]");
    }
}
