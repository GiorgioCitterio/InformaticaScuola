//sorgente di dati
string[] names = { "Bill", "Steve", "James", "Mohan" };

//Linq query
var miaQuery = from name in names
               where name.Contains('a')
               select name;
foreach(var mia in miaQuery)
    Console.WriteLine(mia);