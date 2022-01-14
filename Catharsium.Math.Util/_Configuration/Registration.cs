using Catharsium.Math.Util.Interfaces;
using Catharsium.Math.Util.Lists;
using Catharsium.Math.Util.Numbers;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.Math.Util._Configuration;

public static class Registration
{
    public static IServiceCollection AddMathUtil(this IServiceCollection services, IConfiguration config)
    {
        var configuration = config.Load<MathUtilConfiguration>();
        services.AddSingleton<MathUtilConfiguration, MathUtilConfiguration>(provider => configuration);

        services.AddScoped<IListMultiplicator, ListMultiplicator>();
        services.AddScoped<IRounder, NearestRounder>();
        services.AddScoped<IPartitioner, Partitioner>();

        return services;
    }
}