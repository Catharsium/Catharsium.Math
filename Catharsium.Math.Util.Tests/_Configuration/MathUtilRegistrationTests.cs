using Catharsium.Math.Util._Configuration;
using Catharsium.Math.Util.Interfaces;
using Catharsium.Math.Util.Lists;
using Catharsium.Math.Util.Numbers;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Math.Util.Tests._Configuration
{
    [TestClass]
    public class MathUtilRegistrationTests
    {
        [TestMethod]
        public void AddMathUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddMathUtilities(config);
            serviceCollection.ReceivedRegistration<IListMultiplicator, ListMultiplicator>();
            serviceCollection.ReceivedRegistration<IRounder, NearestRounder>();
        }
    }
}