namespace _04_Navigazione;

public partial class Pagina3 : ContentPage
{
	public Pagina3()
	{
		InitializeComponent();
	}
    private async void Home(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}