using MiaEstensione;

int i = 10;
//i.MaggioreDi(20) (bool)
Console.WriteLine(i.MaggioreDi(40));
namespace MiaEstensione
{
    public static class EstensioneInt
    {
        public static bool MaggioreDi(this int i, int value)
        {
            return i > value;
        }
    }
}