using Catharsium.Math.Configuration;
using Catharsium.Math.Interfaces;
using Catharsium.Math.Rounding;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Math.Tests.Configuration
{
    [TestClass]
    public class MathRegistrationTests
    {
        [TestMethod]
        public void AddMathUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddMath(config);
            serviceCollection.ReceivedRegistration<IPrecisionCalculator, PrecisionCalculator>();
            serviceCollection.ReceivedRegistration<IBalancedRounder, BalancedRounder>();
        }
    }
}