using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Enum;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Service.Interface;
using MinhasFinancas.Service.Service;
using System.Text;

namespace MinhasFinancas.App.Views;

public partial class TransacaoAdd : ContentPage
{
    #region [Private Properties]
    private StringBuilder _mensagem;
    private readonly ITransacaoService _transacaoService;
    #endregion

    #region [Private Methods]
    private bool isValidData()
    {
        var valid = true;
        _mensagem.Clear();

        if (string.IsNullOrWhiteSpace(txtNome.Text))
        {
            _mensagem.AppendLine("O campo 'NOME' deve ser preechido");
            valid = false;
        }
        else if (string.IsNullOrWhiteSpace(txtValor.Text))
        {
            _mensagem.AppendLine("O campo 'VALOR' deve ser preechido");
            valid = false;
        }
        else if(!double.TryParse(txtValor.Text, out double valorSaida))
        {
            _mensagem.AppendLine("O campo 'VALOR' é inválido");
            valid = false;
        }

        if (!valid)
        {
            lblError.Text = _mensagem.ToString();
            lblError.IsVisible = !valid;
        }

        return valid;
    }
    private Transacao OnterTransacao() => new Transacao
    {
        Nome = txtNome.Text,
        DataLancamento = dtpLancamento.Date,
        Tipo = rbReceita.IsChecked ? (int)TipoTransacao.Entrada : (int)TipoTransacao.Saida,
        Valor = double.TryParse(txtValor.Text, out double valorSaida) && valorSaida >= 0 ? valorSaida : 0,
        DataCadastro = DateTime.Now,
        DataAtualizacao = DateTime.Now,
        Ativo = true
    };
    #endregion

    #region [Constructor]
    public TransacaoAdd(IBaseRepository baseRepository)
	{
		InitializeComponent();

        _mensagem = new StringBuilder();
        _transacaoService = new TransacaoService(baseRepository);
    }
    #endregion

    #region [Public Methods]
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) => Navigation.PopModalAsync();

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        if (!isValidData())
            return;

        _transacaoService.Adicionar(OnterTransacao());

        Navigation.PopModalAsync();

        var count = _transacaoService.ObterTodos().Count();
        Application.Current.MainPage.DisplayAlert("Mensagem", $"Existem {count} registro(s) no banco.", "OK");
    }

    #endregion
}