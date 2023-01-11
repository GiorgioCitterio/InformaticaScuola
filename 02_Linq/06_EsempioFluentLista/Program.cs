//string collection
IList<string> stringList = new List<string>() { 
    "C# Tutorials", 
    "VB.NET Tutorials", 
    "Learn C++", 
    "MVC Tutorials", 
    "Java" 
};
var ris = stringList.Where(s => s.Contains("Tutorials"));
foreach (var item in ris)
    Console.WriteLine(item);
