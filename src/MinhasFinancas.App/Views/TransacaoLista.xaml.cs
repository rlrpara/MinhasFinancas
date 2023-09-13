using MinhasFinancas.Domain.Interface;

namespace MinhasFinancas.App.Views;

public partial class TransacaoLista : ContentPage
{
    #region [Private Properties]
    private readonly IBaseRepository _baseRepository;
    #endregion

    #region [Constructor]
    public TransacaoLista(IBaseRepository baseRepository)
	{
		InitializeComponent();

        _baseRepository = baseRepository;
    }
    #endregion

    #region [Public Methods]
    private void NovoRegistro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TransacaoAdd(_baseRepository));
    }

    private void EditarRegistro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TransacaoEdit());
    }

    #endregion
}