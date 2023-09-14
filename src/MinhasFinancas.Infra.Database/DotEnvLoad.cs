using MinhasFinancas.Domain.Enum;

public static class DotEnvLoad
{
    #region [Private methods]
    private static void LoadFile(string filePath, ETipoProjeto tipo)
    {
        if(tipo == ETipoProjeto.Mobile)
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
        else if(tipo == ETipoProjeto.Desktop)
        {
            foreach (var item in File.ReadAllLines(filePath))
            {
                var partes = item.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (partes.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(partes[0], partes[1]);
            }
        }
    }
    #endregion

    #region [Public methods]
    public static void Load(string pasta, ETipoProjeto tipo)
    {
        LoadFile(Path.Combine(pasta, ".env_local"), tipo);
    }

    #endregion
}
