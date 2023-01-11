//inizio main
Print printDel = PrintNumber;
printDel(100);
printDel = PrintMoney;
printDel(3000);
//printDel.Invoke(300); //stessa cosa
Stampa stampaDel = Print1;
Console.WriteLine(stampaDel(34));

//fine main
static void PrintNumber(int valore)
{
    Console.WriteLine("Utilizzo PrintNumber "+valore);
}
static void PrintMoney(int money)
{
    Console.WriteLine("Stampo i soldi {0:C}",money);
}
static int Print1(int valore)
{
    return valore;
}
public delegate void Print(int value);
public delegate int Stampa(int num);
