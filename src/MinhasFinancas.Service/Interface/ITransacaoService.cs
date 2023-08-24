using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Service.Interface;

public interface ITransacaoService : IBaseService
{
    int Adicionar(Transacao transacao);
    int Atualizar(Transacao transacao);
    bool Excluir<Transacao>(int Codigo);
    IEnumerable<Transacao> ObterTodos();
}
