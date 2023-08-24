using MinhasFinancas.Domain.Enum;

namespace MinhasFinancas.Domain.Entities;

public class ParametrosConexao
{
    #region [Private Properties]
    private string? _nomeBanco;
    #endregion

    #region [Constructor]
    public ParametrosConexao()
    {
        NomeBanco = _nomeBanco;
    }
    #endregion

    #region [Public Methods]
    public string? Servidor { get; set; } = "";
    public string? Porta { get; set; } = "";
    public string? NomeBanco
    {
        get { return _nomeBanco?.ToLower(); }
        set => _nomeBanco = value ?? "";
    }
    public string? Usuario { get; set; } = "";
    public string? Senha { get; set; } = "";
    public ETipoBanco TipoBanco { get; set; } = 0;
    public string? PastaBanco { get; set; }
    #endregion
}
