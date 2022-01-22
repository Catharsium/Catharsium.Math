using Catharsium.Math.Graphs.Graphs;
using Catharsium.Math.Graphs.Interfaces;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.Math.Graphs._Configuration;

public static class Registration
{
    public static IServiceCollection AddGraphsMath(this IServiceCollection services, IConfiguration config)
    {
        var configuration = config.Load<GraphsMathSettings>();
        services.AddSingleton<GraphsMathSettings, GraphsMathSettings>(provider => configuration);

        services.AddConsoleIoUtilities(config);

        services.AddScoped<IGraphFactory, GraphFactory>();
        services.AddScoped<IGraph, HorizontalBarGraph>();

        return services;
    }
}