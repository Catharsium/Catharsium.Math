using Catharsium.Math.Persistance;
using Catharsium.Math.Persistance.Interfaces;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.Math.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Math.Persistence.Configuration
{
    public static class PersistenceMathRegistration
    {
        public static IServiceCollection AddPersistenceMath(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<PersistenceMathConfiguration>();

            services.AddMathUtilities(config);
            services.AddScoped<IMultiplicativePersistence, MultiplicativePersistence>();

            return services;
        }
    }
}