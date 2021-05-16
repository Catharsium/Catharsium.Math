using Catharsium.Math.Graph.Graph;
using Catharsium.Math.Graph.Interfaces;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Math.Graph._Configuration
{
    public static class GraphMathRegistration
    {
        public static IServiceCollection AddGraphMath(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<GraphMathSettings>();
            services.AddSingleton<GraphMathSettings, GraphMathSettings>(provider => configuration);

            services.AddConsoleIoUtilities(config);

            services.AddScoped<IGraph, HorizontalGraph>();

            return services;
        }
    }
}