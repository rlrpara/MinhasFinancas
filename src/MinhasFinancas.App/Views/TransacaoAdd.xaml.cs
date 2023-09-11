namespace MinhasFinancas.App.Views;

public partial class TransacaoAdd : ContentPage
{
	public TransacaoAdd()
	{
		InitializeComponent();


	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }
}