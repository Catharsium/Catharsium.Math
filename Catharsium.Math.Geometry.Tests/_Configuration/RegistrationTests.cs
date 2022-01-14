using Catharsium.Math.Geometry._Configuration;
using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Interfaces;
using Catharsium.Math.Util.Interfaces;
using Catharsium.Math.Util.Lists;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.Math.Geometry.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddGeometryMath_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var config = Substitute.For<IConfiguration>();

        serviceCollection.AddGeometryMath(config);
        serviceCollection.ReceivedRegistration<IAreaCalculator, AreaCalculator>();
        serviceCollection.ReceivedRegistration<ICircumferenceCalculator, CircumferenceCalculator>();
        serviceCollection.ReceivedRegistration<IDistanceCalculator, DistanceCalculator>();
    }


    [TestMethod]
    public void AddGeometryMath_RegistersMathUtilities()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var config = Substitute.For<IConfiguration>();

        serviceCollection.AddGeometryMath(config);
        serviceCollection.ReceivedRegistration<IListMultiplicator, ListMultiplicator>();
    }
}