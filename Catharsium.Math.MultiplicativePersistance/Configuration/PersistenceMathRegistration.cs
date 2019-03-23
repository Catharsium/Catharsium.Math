using Catharsium.Util.Configuration;
using Catharsium.Util.Configuration.Extensions;
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

            return services;
        }
    }
}