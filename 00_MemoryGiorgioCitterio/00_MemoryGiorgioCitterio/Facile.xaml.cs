using System.Diagnostics;

namespace _00_MemoryGiorgioCitterio;

public partial class Facile : ContentPage
{
    public int[,] matricePosNumeri = new int[4, 4];
    public int contCarteGir = 0;
    public ImageButton cartaGirata;
    public int coppieTrovate = 0;
    public int mosse = 0;
    public Stopwatch sw = new Stopwatch();
    public Facile()
	{
		InitializeComponent();
        sw.Start();
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
        lblTempo.Text = "Tempo: "+sw.Elapsed.ToString();
        await image.RotateTo(180, 200);
        image.Rotation = 0;
        image.Source = "num" + matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)].ToString() + ".jpg";
        contCarteGir++;
        mosse++;
        lblMosse.Text = "Mosse: "+mosse;
        if (contCarteGir >= 2)
        {
            await Task.Delay(500);
            if (matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)] == matricePosNumeri[Grid.GetRow(cartaGirata), Grid.GetColumn(cartaGirata)])
            {
                contCarteGir= 0;
                image.IsEnabled= false;
                cartaGirata.IsEnabled = false;
                cartaGirata = null;
                coppieTrovate++;
                if (coppieTrovate == 8)
                {
                    sw.Stop();
                    await Navigation.PushAsync(new Vittoria());
                }
                lblCoppieTrovate.Text = "Coppie trovate: " + coppieTrovate;
                return;
            }
            image.Source = string.Empty;
            cartaGirata.Source = string.Empty;
            contCarteGir = 0;
        }
        else
            cartaGirata = image;
        
    }

    private async void StopGame(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}