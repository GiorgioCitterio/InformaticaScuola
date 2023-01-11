namespace _00_MemoryGiorgioCitterio;

public partial class Vittoria : ContentPage
{
	public Vittoria()
	{
		InitializeComponent();
	}

    private async void ToHome(object sender, EventArgs e)
    {
		await Navigation.PopToRootAsync();
    }
}