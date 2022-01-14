using Catharsium.Math.Graphs._Configuration;
using Catharsium.Math.Graphs.Graphs;
using Catharsium.Math.Graphs.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.Math.Graphs.Tests._Configuration;

[TestClass]
public class GraphMathRegistrationTests
{
    [TestMethod]
    public void AddGraphMath_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddGraphMath(configuration);
        serviceCollection.ReceivedRegistration<IGraphFactory, GraphFactory>();
        serviceCollection.ReceivedRegistration<IGraph, HorizontalBarGraph>();
    }


    [TestMethod]
    public void AddGraphMath_RegistersPackages()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddGraphMath(configuration);
        serviceCollection.ReceivedRegistration<IConsole>();
    }
}