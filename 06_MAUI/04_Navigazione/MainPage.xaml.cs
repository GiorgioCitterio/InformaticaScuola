using _04_Navigazione.Dati;

namespace _04_Navigazione
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        Utente ut;

        public MainPage()
        {
            InitializeComponent();
            ut = new Utente()
            {
                Id = 1,
                Name = "Pippo",
            };
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void Pagina2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina2(ut));
        }
    }
}