namespace _00_MemoryGiorgioCitterio;
public enum Scelta{
    Arte,
    Supereroi,
    Frutta,
    Citta
}
public partial class SceltaTema : ContentPage
{ 
	public SceltaTema()
	{
		InitializeComponent();
	}
    public static class Globals
    {
        public static Scelta scelta;
    }

    private async void Arte(object sender, EventArgs e)
    {
        Globals.scelta = Scelta.Arte;
		await Navigation.PushAsync(new MainPage());
    }

    private async void Supereroi(object sender, EventArgs e)
    {
        Globals.scelta = Scelta.Supereroi;
        await Navigation.PushAsync(new MainPage());
    }

    private async void Frutta(object sender, EventArgs e)
    {
        Globals.scelta = Scelta.Frutta;
        await Navigation.PushAsync(new MainPage());
    }

    private async void Citta(object sender, EventArgs e)
    {
        Globals.scelta = Scelta.Citta;
        await Navigation.PushAsync(new MainPage());
    }
}