using Microsoft.Data.Sqlite;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Enum;
using System.Data;

namespace MinhasFinancas.Infra.Data.Context;

public class DeafultSqlConnectionFactory
{
    #region [Propriedades Privadas]
    private readonly ParametrosConexao _parametrosConexao;
    #endregion

    #region [Métodos Privados]
    private SqliteConnection ObterStringConexaoSqlite()
    {
        var caminho = Path.Combine($"{_parametrosConexao.PastaBanco}", $"{_parametrosConexao.NomeBanco}.db" ?? "");
        if (!File.Exists(caminho))
            File.Create(caminho).Close();
        return new SqliteConnection($"Data Source={caminho};");
    }

    #endregion

    #region [Construtor]
    public DeafultSqlConnectionFactory(ParametrosConexao parametrosConexao) => _parametrosConexao = parametrosConexao;
    #endregion

    #region [Métodos Públicos]
    public IDbConnection? Conexao() => _parametrosConexao.TipoBanco switch
    {
        ETipoBanco.SqLite => ObterStringConexaoSqlite(),
        _ => null,
    };
    #endregion
}
