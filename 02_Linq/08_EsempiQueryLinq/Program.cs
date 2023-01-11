using System.Collections;

Student[] studentArray1 = {
 new Student() { StudentID = 1, StudentName = "John", Age = 18 , MediaVoti=6.5} ,
 new Student() { StudentID = 2, StudentName = "Steve", Age = 21 , MediaVoti=8} ,
 new Student() { StudentID = 3, StudentName = "Bill", Age = 25, MediaVoti= 7.4 } ,
 new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, MediaVoti = 10 } ,
 new Student() { StudentID = 5, StudentName = "Ron" , Age = 31, MediaVoti = 9 } ,
 new Student() { StudentID = 6, StudentName = "Chris", Age = 17, MediaVoti = 8.4 } ,
 new Student() { StudentID = 7, StudentName = "Rob",Age = 19 , MediaVoti=7.7} ,
 new Student() { StudentID = 8, StudentName = "Robert",Age = 22, MediaVoti=8.1 } ,
 new Student() { StudentID = 9, StudentName = "Alexander",Age = 18, MediaVoti=4 } ,
 new Student() { StudentID = 10, StudentName = "John", Age = 18 , MediaVoti=6} ,
 new Student() { StudentID = 11, StudentName = "John", Age = 21 , MediaVoti=8.5} ,
 new Student() { StudentID = 12, StudentName = "Bill", Age = 25, MediaVoti= 7 } ,
 new Student() { StudentID = 13, StudentName = "Ram" , Age = 20, MediaVoti = 9 } ,
 new Student() { StudentID = 14, StudentName = "Ron" , Age = 31, MediaVoti = 9.5 } ,
 new Student() { StudentID = 15, StudentName = "Chris", Age = 17, MediaVoti = 8 } ,
 new Student() { StudentID = 16, StudentName = "Rob2",Age = 19 , MediaVoti=7} ,
 new Student() { StudentID = 17, StudentName = "Robert2",Age = 22, MediaVoti=8 } ,
 new Student() { StudentID = 18, StudentName = "Alexander2",Age = 18, MediaVoti=9 } ,
 };

List<Student> studentList = studentArray1.ToList();

//esempi di where
//studenti tra 18 e 25 anni
//primo modo
Func<Student, bool> condizioneDiRicerca = s => s.Age >= 18 && s.Age <= 25;
//secondo modo
CondizioneDiRicerca condizioneDiRicerca2 = s => s.Age >= 18 && s.Age <= 25;
//terzo modo
CondizioneDiRicerca condizioneDiRicerca3 = VerificaCondizione;
List<Student> studentResultList;
//uso il metodo 1
//studentResultList = studentList.Where(condizioneDiRicerca).ToList();
//foreach (var item in studentResultList)
//{
//    Console.WriteLine(item);
//}
//uso il metodo 2
//studentResultList = studentList.Where(new Func<Student, bool>(condizioneDiRicerca2)).ToList();
//studentResultList.ForEach(st => Console.WriteLine(st));

//visualizzare gli studenti con id compreso tra 5 e 10;
//StampaStudentiConIDMagg5Min10(studentList);

//studenti con età compresa tra 18 e 25 con indice pari
//Studenti18_25_ConIndicePari(studentList);

//visualizzare gli studenti 18_25 con media maggiore di 7.0
//Studenti18_25MediaMaggSoglia(studentList, 8);

//esempio collections con dati eterogenei
ListaEterogenea();

//fine main
static void ListaEterogenea()
{
    IList lista = new ArrayList();
    lista.Add("Pippo");
    lista.Add(4);
    lista.Add(true);
    lista.Add(new Student() { StudentID = 100, StudentName = "Mario", Age = 22, MediaVoti = 8});

    //tutti i dati di tipo string
    IList<string> risultato = lista.OfType<string>().ToList();
    foreach (var item in risultato)
    {
        Console.WriteLine(item);
    }
    lista.OfType<Student>().Where(s => s.MediaVoti >= 8)
        .ToList().ForEach(stampa => Console.WriteLine(stampa));
}

static void Studenti18_25MediaMaggSoglia(List<Student> studentList, double soglia)
{
    studentList.Where(s => s.Age >= 18 && s.Age <= 25)
        .Where(s => s.MediaVoti >= soglia)
        .ToList().ForEach(s => Console.WriteLine(s));
}

static void Studenti18_25_ConIndicePari(List<Student> studentList)
{
    studentList.Where((s, i) => (s.Age >= 18 && s.Age <= 25) && (i % 2 == 0)).ToList()
        .ForEach(s => Console.WriteLine(s));
}

static void StampaStudentiConIDMagg5Min10(List<Student> studentList)
{  
    studentList.Where(s => s.StudentID >= 5 && s.StudentID <= 10)
        .ToList().ForEach(s => Console.WriteLine(s));
}

static bool VerificaCondizione(Student st)
{
    return st.Age >= 18 && st.Age <= 25;
}

public class Student
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
public class Assenza
{
    public int ID { get; set; }
    public DateTime Giorno { get; set; }
    public int StudentID { get; set; }
}

delegate bool CondizioneDiRicerca(Student stud);