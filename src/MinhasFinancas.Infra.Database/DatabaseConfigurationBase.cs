using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Infra.Database;

public class DatabaseConfigurationBase
{
    public IEnumerable<Usuario> ObterDadosUsuario() => new List<Usuario>()
    {
        new Usuario()
        {
            CodigoSistema = 1,
            CPF = "00000000000",
            Email = "meusaas@gmail.com",
            Nome = "Conta administrativa",
            Senha = "admin@2023",
            Administrador = true,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now,
            Ativo = true
        },
    };
}
