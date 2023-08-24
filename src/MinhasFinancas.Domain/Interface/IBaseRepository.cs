namespace MinhasFinancas.Domain.Interface;

public interface IBaseRepository
{
    void QueryAsync(string sql);
    Task<IEnumerable<T>> QueryAsync<T>(string where) where T : class;
    Task<T> BuscarPorIdAsync<T>(int id) where T : class;
    Task<T> BuscarPorQueryAsync<T>(string query);
    IEnumerable<T> BuscarTodosPorQueryGerador<T>(string? sqlWhere = null) where T : class;
    Task<T> BuscarPorQueryGeradorAsync<T>(string sqlWhere = null) where T : class;
    Task<IEnumerable<T>?> BuscarTodosPorQueryAsync<T>(string query = null) where T : class;
    Task<IEnumerable<T>> BuscarTodosPorQueryGeradorAsync<T>(string sqlWhere = null) where T : class;
    Task<int> AdicionarAsync<T>(T entidade) where T : class;
    Task<int> AdicionarMultiplosAsync<T>(IEnumerable<T> evento) where T : class;
    Task<int> AtualizarAsync<T>(int id, T entidade) where T : class;
    Task<int> ExcluirAsync<T>(int id) where T : class;
    Task<int?> ObterUltimoRegistroAsync<T>() where T : class;
    Task<int> QueryCount<TEntity>(string? where) where TEntity : class;
}
