Student[] studentArray = {
new Student() { StudentID = 1, StudentName = "John", Age = 18 },
new Student() { StudentID = 2, StudentName = "Steve", Age = 21 },
new Student() { StudentID = 3, StudentName = "Bill", Age = 25 },
new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 },
new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 },
new Student() { StudentID = 6, StudentName = "Chris", Age = 17 },
new Student() { StudentID = 7, StudentName = "Rob",Age = 19 },
};

Student[] students = StudentExtension.where(studentArray, delegate (Student st)
{
    return st.Age > 12 && st.Age < 20;
});
foreach (var item in students)
{
    if (item != null)
        Console.WriteLine(item);
}
class StudentExtension
{
    public static Student[] where(Student[] stdArray, FindStudent del)
    {
        int i = 0; 
        Student[] result = new Student[10]; 
        foreach (Student std in stdArray) 
            if (del(std))
            { 
                result[i] = std; 
                i++; 
            }
        return result;
    }
}

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

delegate bool  FindStudent(Student std);