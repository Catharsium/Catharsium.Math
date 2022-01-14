using Catharsium.Math.MultiplicativePersistance._Configuration;
using Catharsium.Math.MultiplicativePersistance.Interfaces;
using Catharsium.Math.Util.Interfaces;
using Catharsium.Math.Util.Lists;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.Math.MultiplicativePersistance.Tests._Configuration;

[TestClass]
public class PersistenceMathRegistrationTests
{
    [TestMethod]
    public void AddMathUtilities_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var config = Substitute.For<IConfiguration>();

        serviceCollection.AddPersistenceMath(config);
        serviceCollection.ReceivedRegistration<IMultiplicativePersistence, MultiplicativePersistence>();
    }


    [TestMethod]
    public void AddMathUtilities_RegistersMathUtilities()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var config = Substitute.For<IConfiguration>();

        serviceCollection.AddPersistenceMath(config);
        serviceCollection.ReceivedRegistration<IListMultiplicator, ListMultiplicator>();
    }
}