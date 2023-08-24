using Dapper;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Enum;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Data.Context;
using MinhasFinancas.Infra.Data.Interface;
using MinhasFinancas.Infra.Data.Repositories;
using MinhasFinancas.Infra.Database.Interface;
using System.Data;
using System.Text;

namespace MinhasFinancas.Infra.Database;

public class DatabaseConfiguration : DatabaseConfigurationBase, IDatabaseConfiguration
{
    #region [Propriedades Privadas]
    private ParametrosConexao _parametrosConexao;
    private readonly IGeradorDapper _geradorDapper;
    private string? _errorMessage;
    private string? _pastaBanco;
    #endregion

    #region [Construtor]
    public DatabaseConfiguration()
    {
        DotEnvLoad.Load();

        _parametrosConexao = ObterParametrosConexao();
        _geradorDapper = new GeradorDapper(_parametrosConexao);
        _errorMessage = null;
    }
    #endregion

    #region [Métodos Privados]
    private ParametrosConexao ObterParametrosConexao(bool RemoverNomeBanco = false) => new()
    {
        Servidor = Environment.GetEnvironmentVariable("SERVIDOR"),
        NomeBanco = RemoverNomeBanco ? "" : Environment.GetEnvironmentVariable("BANCO")?.ToLower(),
        Porta = Environment.GetEnvironmentVariable("PORTA"),
        Usuario = Environment.GetEnvironmentVariable("USUARIO"),
        Senha = Environment.GetEnvironmentVariable("SENHA"),
        TipoBanco = (ETipoBanco)Convert.ToInt32(Environment.GetEnvironmentVariable("TIPOBANCO")),
        PastaBanco = _pastaBanco
    };
    private string ObterProcedureDropConstraint()
    {
        var sqlPessquisa = new StringBuilder();
        var nomeBanco = _parametrosConexao.NomeBanco;

        switch (_parametrosConexao.TipoBanco)
        {
            case ETipoBanco.MySql:
                sqlPessquisa.AppendLine($"USE {nomeBanco};");
                sqlPessquisa.AppendLine($"DROP PROCEDURE IF EXISTS PROC_DROP_FOREIGN_KEY;");
                sqlPessquisa.AppendLine($"CREATE PROCEDURE PROC_DROP_FOREIGN_KEY(IN tableName VARCHAR(64), IN constraintName VARCHAR(64))");
                sqlPessquisa.AppendLine($"BEGIN");
                sqlPessquisa.AppendLine($"    IF EXISTS(");
                sqlPessquisa.AppendLine($"        SELECT * FROM information_schema.table_constraints");
                sqlPessquisa.AppendLine($"        WHERE ");
                sqlPessquisa.AppendLine($"            table_schema    = DATABASE()     AND");
                sqlPessquisa.AppendLine($"            table_name      = tableName      AND");
                sqlPessquisa.AppendLine($"            constraint_name = constraintName AND");
                sqlPessquisa.AppendLine($"            constraint_type = 'FOREIGN KEY')");
                sqlPessquisa.AppendLine($"    THEN");
                sqlPessquisa.AppendLine($"        SET @query = CONCAT('ALTER TABLE ', tableName, ' DROP FOREIGN KEY ', constraintName, ';');");
                sqlPessquisa.AppendLine($"        PREPARE stmt FROM @query; ");
                sqlPessquisa.AppendLine($"        EXECUTE stmt; ");
                sqlPessquisa.AppendLine($"        DEALLOCATE PREPARE stmt; ");
                sqlPessquisa.AppendLine($"    END IF; ");
                sqlPessquisa.AppendLine($"END");
                break;
            case ETipoBanco.SqlServer:
                sqlPessquisa.AppendLine($"");
                break;
            case ETipoBanco.Firebird:
                sqlPessquisa.AppendLine($"");
                break;
            case ETipoBanco.Postgresql:
                sqlPessquisa.AppendLine($"");
                break;
            case ETipoBanco.SqLite:
                sqlPessquisa.AppendLine($"");
                break;
            default:
                sqlPessquisa.AppendLine($"");
                break;
        }
        return sqlPessquisa.ToString();
    }
    private string ObterSqlCriarBanco()
    {
        var sqlPesquisa = new StringBuilder();

        switch (_parametrosConexao.TipoBanco)
        {
            case ETipoBanco.MySql:
                sqlPesquisa.AppendLine($"CREATE DATABASE {_parametrosConexao.NomeBanco}");
                sqlPesquisa.AppendLine($"CHARACTER SET utf8");
                sqlPesquisa.AppendLine($"COLLATE utf8_general_ci;");
                break;
            case ETipoBanco.SqlServer:
                sqlPesquisa.AppendLine($"CREATE DATABASE {_parametrosConexao.NomeBanco};");
                break;
            case ETipoBanco.Firebird:
                sqlPesquisa.AppendLine($"");
                break;
            case ETipoBanco.Postgresql:
                sqlPesquisa.AppendLine($"CREATE DATABASE {_parametrosConexao.NomeBanco};");
                break;
            case ETipoBanco.SqLite:
                var caminho = Path.Combine(Directory.GetCurrentDirectory(), _parametrosConexao.NomeBanco ?? "");
                if (!File.Exists(caminho))
                    File.Create(caminho).Close();
                sqlPesquisa.AppendLine($"");
                break;
            default:
                sqlPesquisa.AppendLine($"");
                break;
        }
        return sqlPesquisa.ToString();
    }
    private bool ExisteBanco()
    {
        try
        {
            _parametrosConexao = ObterParametrosConexao();

            var sqlPesquisa = new StringBuilder();

            switch (_parametrosConexao.TipoBanco)
            {
                case ETipoBanco.MySql:
                    sqlPesquisa.AppendLine($"SHOW DATABASES LIKE '{_parametrosConexao.NomeBanco}';");
                    break;
                case ETipoBanco.SqlServer:
                    sqlPesquisa.AppendLine($"SELECT NAME");
                    sqlPesquisa.AppendLine($"  FROM MASTER.DBO.SYSDATABASES");
                    sqlPesquisa.AppendLine($"WHERE NAME = N'{_parametrosConexao.NomeBanco}'");
                    break;
                case ETipoBanco.Firebird:
                    break;
                case ETipoBanco.Postgresql:
                    sqlPesquisa.AppendLine($"SELECT DATNAME");
                    sqlPesquisa.AppendLine($"  FROM PG_DATABASE");
                    sqlPesquisa.AppendLine($" WHERE DATISTEMPLATE = false");
                    sqlPesquisa.AppendLine($"   AND lower(DATNAME) = lower('{_parametrosConexao.NomeBanco}');");

                    break;
                case ETipoBanco.SqLite:
                    var caminho = Path.Combine(_parametrosConexao.PastaBanco, $"{_parametrosConexao.NomeBanco}.db" ?? "");
                    if (!File.Exists(caminho))
                        sqlPesquisa.AppendLine($"");
                    else
                        sqlPesquisa.AppendLine($"SELECT 1;");
                    break;
                default:
                    break;
            }

            using var conexao = ConnectionConfiguration.AbrirConexao(ObterParametrosConexao(RemoverNomeBanco: true));
            return conexao.Query<string>(sqlPesquisa.ToString()).ToList().Count > 0;
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
            return false;
        }
    }
    private void Criar(string? sqlCondicao, bool removerNomeBanco = false)
    {
        try
        {
            using var conexao = ConnectionConfiguration.AbrirConexao(ObterParametrosConexao(removerNomeBanco));
            conexao.Execute(sqlCondicao);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception(ex.Message);
        }
    }
    private bool ExisteDados<T>() where T : class
    {
        using var conexao = ConnectionConfiguration.AbrirConexao(_parametrosConexao);
        return conexao.QueryFirstOrDefault<int>($"SELECT COUNT(*) AS Total FROM {_geradorDapper.ObterNomeTabela<T>()};") > 0;
    }
    private void CriarTabelas()
    {
        Criar(ObterProcedureDropConstraint());

        Criar(_geradorDapper.CriarTabela<Usuario>());
    }
    private void InsereDadosPadroes()
    {
        if (!ExisteDados<Usuario>())
            Criar(_geradorDapper.GeralSqlInsertControlesMultiplos(ObterDadosUsuario()), false);
    }
    private bool ServidorAtivo()
    {
        try
        {
            _errorMessage = null;
            Console.WriteLine("########### - abrindo conexao");

            var parametros = ObterParametrosConexao(false);

            using var conexao = ConnectionConfiguration.AbrirConexao(parametros);
            return conexao?.State.Equals(ConnectionState.Open) ?? false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            _errorMessage = ex.Message;
            return false;
        }
    }
    private void ExecutarScripts()
    {
        using var conexao = ConnectionConfiguration.AbrirConexao(_parametrosConexao);

        var diretorio = Path.Combine(Directory.GetCurrentDirectory(), "scripts");

        if (Directory.Exists(diretorio))
        {
            foreach (var script in Directory.GetFiles(diretorio, "*.sql"))
            {
                foreach (var item in new StreamReader(script).ReadToEnd().Split("GO"))
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        var linha = item.Split("|");
                        if (linha.Length > 0)
                            if (!conexao.QueryFirstOrDefault<bool>(linha[0]))
                                conexao.Query<string>(linha[1]);
                    }
                }
            }
        }
    }
    #endregion

    #region Métodos Públicos
    public void CriarSchema(string nomeSchema) => Criar($"CREATE SCHEMA IF NOT EXISTS {nomeSchema}");
    public IBaseRepository GerenciarBanco(ETipoProjeto projeto, string pastaBanco)
    {
        _pastaBanco = pastaBanco;
        try
        {
            if (ServidorAtivo())
            {
                Console.WriteLine("########### - passou ServidorAtivo");

                Console.WriteLine("########### - INICIO");
                if (!ExisteBanco())
                    Criar(ObterSqlCriarBanco(), true);

                Console.WriteLine("########### - PASSOU CRIAR BANCO");

                CriarTabelas();

                InsereDadosPadroes();

                //ExecutarScripts();

                return new BaseRepository();
            }
            else
                throw new Exception($"Base de dados Offline/Erro. Erro: {_errorMessage}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception(ex.Message);
        }
    }
    #endregion
}
