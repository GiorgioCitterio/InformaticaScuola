using _04_Navigazione.Dati;

namespace _04_Navigazione;

public partial class Pagina2 : ContentPage
{
	Utente ut;
	public Pagina2(Utente ut)
	{
		InitializeComponent();
		this.ut = ut;
	}
	private async void Indietro(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
    private async void Pagina3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pagina3());
    }
    private async void ScriviLabel(object sender, EventArgs e)
    {
		lblUtente.Text = ut.Name;
    }
}