using MinhasFinancas.Domain.Enum;
using MinhasFinancas.Domain.Interface;

namespace MinhasFinancas.Infra.Database.Interface;

public interface IDatabaseConfiguration
{
    IBaseRepository GerenciarBanco(ETipoProjeto projeto, string pastaBanco);
}
