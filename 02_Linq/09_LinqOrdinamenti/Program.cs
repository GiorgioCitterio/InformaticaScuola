
//Stampa();
//OrdinaStudenteEtàCrescente();
//OrdinaStudenteEtàCrescente_20_25();
//OrdinaEtàNome();
OrdinaStudenteEtàDecrescente();

/// <summary>
/// Per la gestione degli oggetti statici in .Net 6 va aggiunta la classe
/// Program come partial.
/// Così è possibile usare nel main la lista senza passarla come parametro
/// ai vari metodi statici creati
/// </summary>
/// 

static void Stampa()
{
    studentList.Where(l => l.Age > 20).ToList()
    .ForEach(l => Console.WriteLine(l));
}

//ordina gli studenti in base all'età crescente
static void OrdinaStudenteEtàCrescente()
{
    studentList.OrderBy(l => l.Age).ToList()
        .ForEach(s => Console.WriteLine(s));
}

static void OrdinaStudenteEtàCrescente_20_25()
{
    studentList.Where(s => s.Age >= 20 && s.Age <= 25)
        .OrderBy(l => l.Age).ToList()
        .ForEach(s => Console.WriteLine(s));
}

static void OrdinaStudenteEtàDecrescente()
{
    studentList.OrderByDescending(l => l.Age).ToList()
        .ForEach(s => Console.WriteLine(s));
}

static void OrdinaEtàNome()
{
    studentList.OrderBy(s => s.Age).ThenBy(s => s.StudentName).ThenBy(s => s.MediaVoti)
        .ToList().ForEach(s => Console.WriteLine(s));
}
public partial class Program
{

    static Student[] studentArray1 = {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 , MediaVoti=6.5} ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 , MediaVoti=8} ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25, MediaVoti= 7.4 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, MediaVoti = 10 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 31, MediaVoti = 9 } ,
            new Student() { StudentID = 6, StudentName = "Chris",  Age = 17, MediaVoti = 8.4 } ,
            new Student() { StudentID = 7, StudentName = "Rob",Age = 19  , MediaVoti=7.7} ,
            new Student() { StudentID = 8, StudentName = "Robert",Age = 22, MediaVoti=8.1 } ,
            new Student() { StudentID = 9, StudentName = "Alexander",Age = 18, MediaVoti=4 } ,
            new Student() { StudentID = 10, StudentName = "John", Age = 18 , MediaVoti=6} ,
            new Student() { StudentID = 11, StudentName = "John",  Age = 21 , MediaVoti=8.5} ,
            new Student() { StudentID = 12, StudentName = "Bill",  Age = 25, MediaVoti= 7 } ,
            new Student() { StudentID = 13, StudentName = "Ram" , Age = 20, MediaVoti = 9 } ,
            new Student() { StudentID = 14, StudentName = "Ron" , Age = 31, MediaVoti = 9.5 } ,
            new Student() { StudentID = 15, StudentName = "Chris",  Age = 17, MediaVoti = 8 } ,
            new Student() { StudentID = 16, StudentName = "Rob2",Age = 19  , MediaVoti=7} ,
            new Student() { StudentID = 17, StudentName = "Robert2",Age = 22, MediaVoti=8 } ,
            new Student() { StudentID = 18, StudentName = "Alexander2",Age = 18, MediaVoti=9 } ,
            };
    static List<Student> studentList = studentArray1.ToList();
}

class Student
{
    public int StudentID { get; set; }
    public String? StudentName { get; set; }
    public int Age { get; set; }
    public double MediaVoti { get; set; }

    public override string ToString()
    {
        return String.Format($"[StudentID = {StudentID}, StudentName = {StudentName}, Age = {Age}, MediaVoti = {MediaVoti}]");
    }
}
