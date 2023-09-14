using Microsoft.Extensions.Logging;
using MinhasFinancas.App.Views;
using MinhasFinancas.Domain.Enum;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Data.Repositories;
using MinhasFinancas.Infra.Database;
using MinhasFinancas.Service.Interface;
using MinhasFinancas.Service.Service;

namespace MinhasFinancas.App
{
    public static class MauiProgram
    {
        #region [Private Metods]
        private static MauiAppBuilder RegisterDatabaseAndRepositories(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<ITransacaoService, TransacaoService>();
            mauiAppBuilder.Services.AddTransient<ITransacaoRepository, TransacaoRepository>();
            mauiAppBuilder.Services.AddTransient<IBaseRepository, BaseRepository>();
            return mauiAppBuilder;
        }
        private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<TransacaoAdd>();
            mauiAppBuilder.Services.AddTransient<TransacaoEdit>();
            mauiAppBuilder.Services.AddTransient<TransacaoLista>();

            return mauiAppBuilder;
        }
        #endregion

        #region [Public Metods]
        public static MauiApp CreateMauiApp()
        {
            var pasta = "";
            var tipo = ETipoProjeto.Desktop;
#if ANDROID
            pasta = AppContext.BaseDirectory.ToString();
            tipo = ETipoProjeto.Mobile;
#elif WINDOWS
            pasta = AppDomain.CurrentDomain.BaseDirectory.ToString();
#endif
            _ = new DatabaseConfiguration(pasta, tipo).GerenciarBanco();

            var builder = MauiApp.CreateBuilder();

            builder.UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterViews()
                .RegisterDatabaseAndRepositories();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
        #endregion
    }
}