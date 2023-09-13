using Microsoft.Extensions.DependencyInjection;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Data.Repositories;
using MinhasFinancas.Service.Interface;
using MinhasFinancas.Service.Service;

namespace MinhasFinancas.CrossCutting.Ioc;

public static class NativeInjector
{
    public static MauiAppBuilder RegisterServices(this MauiAppBuilder services)
    {
        #region Services
        services.AddTransient<ITransacaoService, TransacaoService>();
        services.AddTransient<ITransacaoRepository, TransacaoRepository>();
        #endregion

        #region Repositories
        services.AddTransient<IBaseRepository, BaseRepository>();
        #endregion
    }
}
