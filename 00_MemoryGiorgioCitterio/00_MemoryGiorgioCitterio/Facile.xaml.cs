using System.Diagnostics;
using System.Reflection;

namespace _00_MemoryGiorgioCitterio;

public partial class Facile : ContentPage
{
    public int[,] matricePosNumeri = new int[4, 4];
    public int contCarteGir = 0;
    public ImageButton cartaGirata;
    public int coppieTrovate = 0;
    public int mosse = 0;
    public Stopwatch sw = new Stopwatch();
    public int rigaCorrente;
    public int colonnaCorrente;
    public int pointer = 0;
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
        Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            TimeSpan span = TimeSpan.FromSeconds(1);

            Dispatcher.DispatchAsync(() =>
            {
                pointer -= 1;
                if (pointer == -1)
                {
                    pointer = 59;
                    lblTempo.Text = "Tempo: 01:00";
                }
                if (pointer == 0)
                {
                    Navigation.PushAsync(new Perso());
                }
                else
                {
                    lblTempo.Text = "Tempo: "+pointer.ToString("00:00");
                }
            });
            return true;
        });
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
        switch (SceltaTema.Globals.scelta)
        {
            case Scelta.Arte:
                image.Source = "arte" + matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)].ToString() + ".jpg";
                break;
            case Scelta.Supereroi:
                image.Source = "marvel_" + matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)].ToString() + ".jpg";
                break;
            case Scelta.Frutta:
                image.Source = "frutta" + matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)].ToString() + ".jpg";
                break;
            case Scelta.Citta:
                image.Source = "cit" + matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)].ToString() + ".jpg";
                break;
            default:
                break;
        }
        contCarteGir++;
        mosse++;
        lblMosse.Text = "Mosse: "+mosse;
        if (contCarteGir >= 2)
        {
            if (rigaCorrente == Grid.GetRow(image) && colonnaCorrente == Grid.GetColumn(image))
            {
                return;
            }
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
        {
            cartaGirata = image;
            rigaCorrente = Grid.GetRow(image);
            colonnaCorrente = Grid.GetColumn(image);
        }  
    }

    private async void StopGame(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}