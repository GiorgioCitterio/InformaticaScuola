using _00_Calcolatrice.View;

namespace _00_Calcolatrice
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CalculatorView();
        }
    }
}