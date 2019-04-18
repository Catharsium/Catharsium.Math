using Catharsium.Math.Interfaces;
using Catharsium.Math.Rounding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Math.Configuration
{
    public static class MathRegistration
    {
        public static IServiceCollection AddMath(this IServiceCollection services, IConfiguration config)
        {
            //var configuration = config.Load<MathConfiguration>();

            services.AddScoped<IPrecisionCalculator, PrecisionCalculator>();
            //services.AddScoped<IBalancedRounder, BalancedRounder>();

            return services;
        }
    }
}