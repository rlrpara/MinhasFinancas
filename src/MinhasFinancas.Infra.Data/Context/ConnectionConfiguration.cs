using MinhasFinancas.Domain.Entities;
using System.Data;

namespace MinhasFinancas.Infra.Data.Context;

public static class ConnectionConfiguration
{
    #region [Métodos Privados]
    private static IDbConnection? Inicia(IDbConnection? conexao)
    {
        try
        {
            Console.WriteLine("########### - TESTAR SE ABRE A CONEXAO");
            if (conexao != null)
            {
                Console.WriteLine($"########### - CONNECTIONSTRING = {conexao.ConnectionString}");
                if (conexao.State == ConnectionState.Open) conexao.Close();
                if (conexao.State == ConnectionState.Closed) conexao.Open();
                Console.WriteLine("########### - CONEXAO ABERTA");
            }
            else
            {
                Console.WriteLine($"############# - CONEXÃO NULA");
            }
            return conexao;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion

    #region Métodos Públicos
    public static IDbConnection? AbrirConexao(ParametrosConexao parametrosConexao) => Inicia(new DeafultSqlConnectionFactory(parametrosConexao).Conexao());
    #endregion
}
