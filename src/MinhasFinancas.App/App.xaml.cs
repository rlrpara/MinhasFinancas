using MinhasFinancas.App.Views;
using MinhasFinancas.Domain.Interface;

namespace MinhasFinancas.App
{
    public partial class App : Application
    {
        public App(IBaseRepository baseRepository)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TransacaoLista(baseRepository));
        }
    }
}