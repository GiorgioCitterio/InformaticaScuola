namespace _06_Preferences
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PagePreferences();
        }
    }
}