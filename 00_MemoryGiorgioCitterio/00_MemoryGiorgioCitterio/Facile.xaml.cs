using System.Diagnostics.Contracts;

namespace _00_MemoryGiorgioCitterio;

public partial class Facile : ContentPage
{
    static public int[,] matricePosNumeri = new int[4, 4];
    public int contCarteGir = 0;
    public ImageButton cartaGirata;
    public Facile()
	{
		InitializeComponent();
        Random random = new Random();
        for (int i = 1; i < 9; i++)
        {
            int count = 0;
            while (count < 2)
            {
                int r = random.Next(0, 4);
                int c = random.Next(0, 4);
                if (matricePosNumeri[r, c] == 0)
                {
                    matricePosNumeri[r, c] = i;
                }
                else
                {
                    continue;
                }
                count++;
            }
        }
    }

    private async void HasClicked(object sender, EventArgs e)
    {
        if (!(sender is ImageButton))
        {
            return;
        }
        ImageButton image = (ImageButton)sender;
        await image.RotateTo(180, 200);
        image.Rotation = 0;
        image.Source = "num" + matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)].ToString() + ".jpg";
        contCarteGir++;
        if (contCarteGir >= 2)
        {
            await Task.Delay(500);
            if (matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)] == matricePosNumeri[Grid.GetRow(cartaGirata), Grid.GetColumn(cartaGirata)])
            {
                cartaGirata = null;
                contCarteGir= 0;
                return;
            }
            image.Source = string.Empty;
            cartaGirata.Source = string.Empty;
            contCarteGir = 0;
        }
        else
            cartaGirata = image;
    }
}