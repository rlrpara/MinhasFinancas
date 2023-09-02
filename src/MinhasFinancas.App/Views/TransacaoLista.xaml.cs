namespace MinhasFinancas.App.Views;

public partial class TransacaoLista : ContentPage
{
	public TransacaoLista()
	{
		InitializeComponent();
	}

    private void NovoRegistro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TransacaoAdd());
    }

    private void EditarRegistro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TransacaoEdit());
    }
}