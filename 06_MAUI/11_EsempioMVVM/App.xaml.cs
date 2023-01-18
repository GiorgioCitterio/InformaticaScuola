using _11_EsempioMVVM.View;

namespace _11_EsempioMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new KeyPadView();
        }
    }
}