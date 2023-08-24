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
    public IEnumerable<Transacao> ObterTodos() => _baseRepository.BuscarTodosPorQueryGerador<Transacao>();
    public async Task<int> Adicionar(Transacao transacao) => await _baseRepository.AdicionarAsync(transacao);
    public async Task<int> Atualizar(Transacao transacao) => await _baseRepository.AtualizarAsync(transacao.Codigo, transacao);
    public async Task<bool> Excluir(int codigo) => await _baseRepository.ExcluirAsync<Transacao>(codigo) > 0;


    #endregion
}
