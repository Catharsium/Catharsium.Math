using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Configuration;
using Catharsium.Math.Geometry.Interfaces;
using Catharsium.Util.Math.Interfaces;
using Catharsium.Util.Math.Lists;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Math.Geometry.Tests.Configuration
{
    [TestClass]
    public class GeometryMathRegistrationTests
    {
        [TestMethod]
        public void AddMathUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddGeometryMath(config);
            serviceCollection.ReceivedRegistration<ICircumferenceCalculator, CircumferenceCalculator>();
        }


        [TestMethod]
        public void AddMathUtilities_RegistersMathUtilities()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddGeometryMath(config);
            serviceCollection.ReceivedRegistration<IListMultiplicator, ListMultiplicator>();
        }
    }
}