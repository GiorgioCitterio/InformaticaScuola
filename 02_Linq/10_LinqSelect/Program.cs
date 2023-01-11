//esempio select con oggetti anonimi
//EsempioSelect();
//EsempioSelectClasse();
//RaggruppaPerEtà();
//RaggruppaPerNome();
//AssenzePerOgniStudente();
AssenzeStudente("Steve");

static void RaggruppaPerNome()
{
    var gruppoStudenti = studentList.GroupBy(s => s.StudentName);
    foreach (var gruppo in gruppoStudenti)
    {
        Console.WriteLine("Chiave raggruppamento "+gruppo.Key);
        foreach (var student in gruppo)
        {
            Console.WriteLine(student);
        }
        Console.WriteLine(gruppo.Count());
        Console.WriteLine("Voto medio "+gruppo.Average(s => s.MediaVoti));
    }
}

static void RaggruppaPerEtà()
{
    var gruppoStudEtà = studentList.GroupBy(s => s.Age);
    foreach (var gruppo in gruppoStudEtà)
    {
        Console.WriteLine("gruppo "+gruppo.Key);
        foreach (var student in gruppo)
        {
            Console.WriteLine(student);
        }
        Console.WriteLine($"Numero studenti del gruppo con età {gruppo.Key} sono {gruppo.Count()}");
        Console.WriteLine($"Media voti del gruppo con età {gruppo.Key} sono {gruppo.Average(s => s.MediaVoti)}");
        Console.WriteLine($"Voto massimo del gruppo con età {gruppo.Key} è {gruppo.Max(s => s.MediaVoti)}");
        Console.WriteLine($"Voto minimo del gruppo con età {gruppo.Key} è {gruppo.Min(s => s.MediaVoti)}");

    }
}

static void EsempioSelect()
{
    studentList.Select(s => new { Nome = s.StudentName, Età = s.Age })
        .ToList().ForEach(s => Console.WriteLine("nome = "+s.Nome + " età = " + s.Età));
}

static void EsempioSelectClasse()
{
    studentList.Where(s => s.Age > 20)
        .Select(s => new Persona() { Nome = s.StudentName, Età = s.Age })
        .OrderBy(sp => sp.Nome)
        .ToList()
        .ForEach(s => Console.WriteLine(s));
}

//join (id, nome e giorno di assenza per ogni studente)
static void AssenzePerOgniStudente()
{
    var assenzeStudenti = studentList.Join(assenzeList1,
        s => s.StudentID,
        a => a.StudentID,
        (s, a) => new { ID = a.ID, NomeStud = s.StudentName, GiornoAss = a.Giorno });
    foreach (var item in assenzeStudenti)
    {
        Console.WriteLine($"id {item.ID} nome {item.NomeStud} assenza {item.GiornoAss}");
    }
}

static void AssenzeStudente(string nome)
{
    studentList.Where(s => s.StudentName.Equals(nome))
        .Join(assenzeList1,
        s => s.StudentID,
        a => a.StudentID,
        (s, a) => new { Nome = nome, GiornoAss = a.Giorno })
        .ToList().ForEach(t => Console.WriteLine(t.Nome + " " + t.GiornoAss));
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

    static List<Assenza> assenzeList1 = new List<Assenza> {
        new Assenza(){ID = 1, Giorno = DateTime.Today, StudentID = 1 },
        new Assenza(){ID = 2, Giorno = DateTime.Today.AddDays(-1) ,StudentID = 1 },
        new Assenza(){ID = 3, Giorno = DateTime.Today.AddDays(-3), StudentID = 1 },
        new Assenza(){ID = 4, Giorno = new DateTime(2020,11,30), StudentID = 2 },
        new Assenza(){ID = 5, Giorno = new DateTime(2020,11,8), StudentID = 3 }
        };
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

class Persona
{
    public string Nome { get; set; }
    public int Età { get; set; }
    public override string ToString()
    {
        return String.Format($"[Nome = {Nome}, Età = {Età}]");
    }
}

public class Assenza
{
    public int ID { get; set; }
    public DateTime Giorno { get; set; }
    public int StudentID { get; set; }
}