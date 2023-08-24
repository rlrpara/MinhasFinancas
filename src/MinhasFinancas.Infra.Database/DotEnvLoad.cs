public static class DotEnvLoad
{
    #region [Private methods]
    private static void LoadFile(string filePath)
    {
        if (!File.Exists(filePath))
            return;

        foreach (var linha in File.ReadAllLines(filePath))
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
