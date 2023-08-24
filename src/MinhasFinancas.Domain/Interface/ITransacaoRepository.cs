using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interface;

public interface ITransacaoRepository : IBaseRepository
{
    Task<int> Adicionar(Transacao transacao);
    Task<int> Atualizar(Transacao transacao);
    Task<bool> Excluir(int codigo);
    IEnumerable<Transacao> ObterTodos();
}
