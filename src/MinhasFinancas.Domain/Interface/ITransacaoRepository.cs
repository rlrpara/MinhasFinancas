using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interface;

public interface ITransacaoRepository : IBaseRepository
{
    Task<int> Adicionar(Movimentacao transacao);
    Task<int> Atualizar(Movimentacao transacao);
    Task<bool> Excluir(int codigo);
    IEnumerable<Movimentacao> ObterTodos();
}
