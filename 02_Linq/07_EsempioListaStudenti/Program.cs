IList<Student> studentList = new List<Student>() {
new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
};

//var teenAger = studentList.Where(st => st.Age > 12 && st.Age < 20).ToList();
//teenAger.ForEach(st=>Console.WriteLine(st));

studentList.Where(st => st.Age > 12 && st.Age < 20).ToList().ForEach(st=>Console.WriteLine(st));
public class Student
{
    public int StudentID { get; set; }
    public String? StudentName { get; set; }
    public int Age { get; set; }
    public override string ToString()
    {
        return String.Format($"[StudentID = {StudentID}, StudentName = {StudentName}, Age = {Age}]");
    }
}