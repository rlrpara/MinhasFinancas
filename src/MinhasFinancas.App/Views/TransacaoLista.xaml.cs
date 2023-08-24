namespace MinhasFinancas.App.Views;

public partial class TransacaoLista : ContentPage
{
	public TransacaoLista()
	{
		InitializeComponent();
	}

    private void NovoRegistro_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new TransacaoAdd();
    }
}