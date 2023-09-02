namespace MinhasFinancas.App.Views;

public partial class TransacaoEdit : ContentPage
{
	public TransacaoEdit()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
}