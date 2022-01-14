using Catharsium.Math.MultiplicativePersistance.Interfaces;
using Catharsium.Math.Util._Configuration;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.Math.MultiplicativePersistance._Configuration;

public static class Registration
{
    public static IServiceCollection AddPersistenceMath(this IServiceCollection services, IConfiguration config)
    {
        var configuration = config.Load<PersistenceMathConfiguration>();
        services.AddSingleton<PersistenceMathConfiguration, PersistenceMathConfiguration>(provider => configuration);

        services.AddMathUtil(config);
        services.AddScoped<IMultiplicativePersistence, MultiplicativePersistence>();

        return services;
    }
}