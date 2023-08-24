using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Service.Interface;

public interface ITransacaoService : IBaseService
{
    int Adicionar(Movimentacao transacao);
    int Atualizar(Movimentacao transacao);
    bool Excluir<Transacao>(int Codigo);
    IEnumerable<Movimentacao> ObterTodos();
}
