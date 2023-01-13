using System.Diagnostics;

namespace _00_MemoryGiorgioCitterio;
public enum Tema
{
    Arte,
    Supereroi,
    Frutta,
    Citta
}
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
    public int secondi = 90;
    public bool vittoria = false;
    public bool esegui = true;
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
            TimeSpan ts = sw.Elapsed;
            Dispatcher.DispatchAsync(async() =>
            {
                secondi -= 1;
                if (secondi == 0 && vittoria == false)
                {
                    await Navigation.PushAsync(new Perso());
                }
                else
                {
                    lblTempo.Text = "Tempo: "+ String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
                }
            });
            return true;
        });
    }
    private async void HasClicked(object sender, EventArgs e)
    {
        if (!esegui)
        {
            return;
        }
        else
            esegui = false;
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
                Dati.tema = Tema.Arte;
                break;
            case Scelta.Supereroi:
                image.Source = "marvel_" + matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)].ToString() + ".jpg";
                Dati.tema = Tema.Supereroi;
                break;
            case Scelta.Frutta:
                image.Source = "frutta" + matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)].ToString() + ".jpg";
                Dati.tema = Tema.Frutta;
                break;
            case Scelta.Citta:
                image.Source = "cit" + matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)].ToString() + ".jpg";
                Dati.tema = Tema.Citta;
                break;
            default:
                break;
        }
        contCarteGir++;
        mosse++;
        lblMosse.Text = "Mosse: " + mosse;
        if (contCarteGir >= 2)
        {
            if (rigaCorrente == Grid.GetRow(image) && colonnaCorrente == Grid.GetColumn(image))
            {
                esegui = true;
                return;
            }
            await Task.Delay(500);
            if (matricePosNumeri[Grid.GetRow(image), Grid.GetColumn(image)] == matricePosNumeri[Grid.GetRow(cartaGirata), Grid.GetColumn(cartaGirata)])
            {
                contCarteGir = 0;
                image.IsEnabled = false;
                cartaGirata.IsEnabled = false;
                cartaGirata = null;
                coppieTrovate++;
                if (coppieTrovate == 8)
                {
                    vittoria = true;
                    sw.Stop();
                    Dati.mosseImpiegate = mosse;
                    Dati.tempoImpiegato = sw.Elapsed;
                    Dati.data = DateTime.Now;
                    await Navigation.PushAsync(new Vittoria());
                }
                lblCoppieTrovate.Text = "Coppie trovate: " + coppieTrovate;
                esegui = true;
                return;
            }
            image.Source = string.Empty;
            cartaGirata.Source = string.Empty;
            contCarteGir = 0;
            esegui = true;
        }
        else
        {
            cartaGirata = image;
            rigaCorrente = Grid.GetRow(image);
            colonnaCorrente = Grid.GetColumn(image);
            esegui = true;
        }
    }
    private async void StopGame(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void ChangeTheme(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
    public static class Dati
    {
        public static int mosseImpiegate { get; set; }
        public static TimeSpan tempoImpiegato { get; set; }
        public static DateTime data { get; set; }
        public static Tema tema { get; set; }
    }
}