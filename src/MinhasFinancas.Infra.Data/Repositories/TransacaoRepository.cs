using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interface;

namespace MinhasFinancas.Infra.Data.Repositories;

public class TransacaoRepository : BaseRepository, ITransacaoRepository
{
    #region [Private Properties]
    private readonly IBaseRepository _baseRepository;
    #endregion

    #region [Private Methods]

    #endregion

    #region [Constructor]
    public TransacaoRepository(IBaseRepository baseRepository) => _baseRepository = baseRepository;
    #endregion

    #region [Public Methods]
    public IEnumerable<Movimentacao> ObterTodos() => _baseRepository.BuscarTodosPorQueryGerador<Movimentacao>();
    public async Task<int> Adicionar(Movimentacao transacao) => await _baseRepository.AdicionarAsync(transacao);
    public async Task<int> Atualizar(Movimentacao transacao) => await _baseRepository.AtualizarAsync(transacao.Codigo, transacao);
    public async Task<bool> Excluir(int codigo) => await _baseRepository.ExcluirAsync<Movimentacao>(codigo) > 0;


    #endregion
}
