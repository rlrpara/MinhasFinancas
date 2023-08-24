using MinhasFinancas.App.Views;

namespace MinhasFinancas.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TransacaoLista();
        }
    }
}