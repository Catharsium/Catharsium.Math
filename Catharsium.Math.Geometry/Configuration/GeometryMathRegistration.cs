using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Interfaces;
using Catharsium.Util.Configuration;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Math.Geometry.Configuration
{
    public static class GeometryMathRegistration
    {
        public static IServiceCollection AddGeometryMath(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<GeometryMathConfiguration>();

            services.AddMathUtilities(config);
            services.AddScoped<ICircumferenceCalculator, CircumferenceCalculator>();

            return services;
        }
    }
}