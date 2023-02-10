namespace _13_PersistenzaDati
{
    public partial class App : Application
    {
        //property statica
        public static PersonRepository PersonRepo { get; set; }
        public App(PersonRepository repo)
        {
            InitializeComponent();

            MainPage = new AppShell();
            PersonRepo = repo;
        }
    }
}