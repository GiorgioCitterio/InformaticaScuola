using SimpleMVVM.View;

namespace SimpleMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new DateTimePage();
            MainPage = new ViewClock();
            //MainPage = new ViewHsl();
            //MainPage = new KeyPadView();
        }
    }
}