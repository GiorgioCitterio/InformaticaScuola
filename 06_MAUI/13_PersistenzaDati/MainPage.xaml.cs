namespace _13_PersistenzaDati
{
    public partial class MainPage : ContentPage
    {
    
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Inserisci_Clicked(object sender, EventArgs e)
        {
            StatusInserimento.Text = "";
            await App.PersonRepo.AddPerson(Persona.Text);
            StatusInserimento.Text = App.PersonRepo.StatusMessage;
        }

        private async void GetPeople_Clicked(object sender, EventArgs e)
        {
            List<Person> people;
        }
    }
}