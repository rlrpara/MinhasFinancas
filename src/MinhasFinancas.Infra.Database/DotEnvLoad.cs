public static class DotEnvLoad
{
    #region [Private methods]
    private static void LoadFile(string filePath)
    {
        string db = MinhasFinancas.Infra.Database.Properties.Resources.Env.ToString();

        foreach (string linha in db.Split("\r\n"))
        {
            var partes = linha.Split('=', StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length != 2)
                continue;

            Environment.SetEnvironmentVariable(partes[0], partes[1]);
        }
    }
    #endregion

    #region [Public methods]
    public static void Load()
    {
        LoadFile(Path.Combine(AppContext.BaseDirectory.ToString(), ".env_local"));
    }

    #endregion
}
