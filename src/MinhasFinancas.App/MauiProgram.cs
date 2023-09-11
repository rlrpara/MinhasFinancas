using Microsoft.Extensions.Logging;
using MinhasFinancas.CrossCutting.Ioc;
using MinhasFinancas.Domain.Enum;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Database;

namespace MinhasFinancas.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string? dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            IBaseRepository baseRepository = new DatabaseConfiguration().GerenciarBanco(ETipoProjeto.Desktop, dbPath);
            //IBaseRepository baseRepository = new DatabaseConfiguration().GerenciarBanco(ETipoProjeto.Desktop, FileSystem.AppDataDirectory);

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.RegisterServices();

#if DEBUG
        builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}