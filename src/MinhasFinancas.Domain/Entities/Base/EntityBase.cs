using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entities.Base;

public class EntityBase
{
    #region [Private Properties]
    private int _codigo;
    private DateTime? _dataCadastro;
    private DateTime? _dataAtualizacao;
    private bool _ativo;
    #endregion

    #region [Construtctor]
    public EntityBase()
    {
        Codigo = _codigo;
        DataCadastro = _dataCadastro;
        DataAtualizacao = _dataAtualizacao;
        Ativo = _ativo;
    }
    #endregion

    #region [Public Methods]
    [Nota(ChavePrimaria = true)]
    [Column("ID", Order = 1)]
    public int Codigo
    {
        get { return _codigo; }
        set { _codigo = value; }
    }

    [Nota()]
    [Column("DATA_CADASTRO", Order = 100)]
    public DateTime? DataCadastro
    {
        get { return _dataCadastro; }
        set { _dataCadastro = value == null ? DateTime.Now : value; }
    }

    [Nota()]
    [Column("DATA_ATUALIZACAO", Order = 101)]
    public DateTime? DataAtualizacao
    {
        get { return _dataAtualizacao; }
        set { _dataAtualizacao = value == null ? DateTime.Now : value; }
    }

    [Nota()]
    [Column("ATIVO", Order = 102)]
    public bool Ativo
    {
        get { return _ativo; }
        set { _ativo = value; }
    }
    #endregion

}
