using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Data.Repositories;
using MinhasFinancas.Service.Interface;

namespace MinhasFinancas.Service.Service;

public class TransacaoService : BaseService, ITransacaoService
{
    #region [Private Properties]
    private readonly ITransacaoRepository _transacaoRepository;
    #endregion

    #region [Private Methods]

    #endregion

    #region [Constructor]

    public TransacaoService(IBaseRepository baseRepository) : base(baseRepository)
    {
        _transacaoRepository = new TransacaoRepository(baseRepository);
    }
    #endregion

    #region [Public Methods]
    public IEnumerable<Transacao> ObterTodos() => _transacaoRepository.ObterTodos();
    public int Adicionar(Transacao transacao) => _transacaoRepository.Adicionar(transacao).Result;
    public int Atualizar(Transacao transacao) => _transacaoRepository.Atualizar(transacao).Result;
    public bool Excluir<Transacao>(int Codigo) => _transacaoRepository.Excluir(Codigo).Result;
    #endregion
}
