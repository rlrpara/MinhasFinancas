using MinhasFinancas.Domain.Interface;

namespace MinhasFinancas.Infra.Database.Interface;

public interface IDatabaseConfiguration
{
    IBaseRepository GerenciarBanco();
}
