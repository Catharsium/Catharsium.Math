using Catharsium.Math.Util.Interfaces;
using Catharsium.Math.Util.Lists;
using Catharsium.Util.Comparing.Equality;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Catharsium.Math.MultiplicativePersistance.Tests;

[TestClass]
public class MultiplicativePersistenceTests : TestFixture<MultiplicativePersistence>
{
    #region Fixture

    protected EnumerableEqualityComparer<int> Comparer { get; private set; }


    [TestInitialize]
    public void SetupListMultiplicator()
    {
        this.SetDependency<IListMultiplicator>(new ListMultiplicator());
        this.Comparer = new EnumerableEqualityComparer<int>();
    }

    #endregion

    #region GetPath

    [TestMethod]
    public void GetPath_SingleDigit_ReturnsSingleStep()
    {
        var input = new[] { 0 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(1, actual.Count);
        Assert.AreEqual(input, actual[0]);
    }


    [TestMethod]
    public void GetPath_DoubleDigit_FirstStepEqualsInput()
    {
        var input = new[] { 1, 2 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(2, actual.Count);
        Assert.AreEqual(input, actual[0]);
    }


    [TestMethod]
    public void GetPath_10_ReturnsExpectedSteps()
    {
        var input = new[] { 1, 0 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(2, actual.Count);
        Assert.AreEqual(input, actual[0]);
        Assert.IsTrue(this.Comparer.Equals(new[] { 0 }, actual[1]));
    }


    [TestMethod]
    public void GetPath_25_ReturnsExpectedSteps()
    {
        var input = new[] { 2, 5 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(3, actual.Count);
        Assert.AreEqual(input, actual[0]);
        Assert.IsTrue(this.Comparer.Equals(new[] { 1, 0 }, actual[1]));
        Assert.IsTrue(this.Comparer.Equals(new[] { 0 }, actual[2]));
    }


    [TestMethod]
    public void GetPath_39_ReturnsExpectedSteps()
    {
        var input = new[] { 3, 9 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(4, actual.Count);
        Assert.AreEqual(input, actual[0]);
        Assert.IsTrue(this.Comparer.Equals(new[] { 2, 7 }, actual[1]));
        Assert.IsTrue(this.Comparer.Equals(new[] { 1, 4 }, actual[2]));
        Assert.IsTrue(this.Comparer.Equals(new[] { 4 }, actual[3]));
    }


    [TestMethod]
    public void GetPath_77_ReturnsExpectedSteps()
    {
        var input = new[] { 7, 7 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(5, actual.Count);
        Assert.AreEqual(input, actual[0]);
        Assert.IsTrue(this.Comparer.Equals(new[] { 4, 9 }, actual[1]));
        Assert.IsTrue(this.Comparer.Equals(new[] { 3, 6 }, actual[2]));
        Assert.IsTrue(this.Comparer.Equals(new[] { 1, 8 }, actual[3]));
        Assert.IsTrue(this.Comparer.Equals(new[] { 8 }, actual[4]));
    }


    [TestMethod]
    public void GetPath_679_ReturnsExpectedSteps()
    {
        var input = new[] { 6, 7, 9 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(6, actual.Count);
        Assert.AreEqual(input, actual[0]);
        Assert.IsTrue(this.Comparer.Equals(new[] { 3, 7, 8 }, actual[1]));
        Assert.IsTrue(this.Comparer.Equals(new[] { 1, 6, 8 }, actual[2]));
        Assert.IsTrue(this.Comparer.Equals(new[] { 4, 8 }, actual[3]));
        Assert.IsTrue(this.Comparer.Equals(new[] { 3, 2 }, actual[4]));
        Assert.IsTrue(this.Comparer.Equals(new[] { 6 }, actual[5]));
    }


    [TestMethod]
    public void GetPath_6788_Returns7Steps()
    {
        var input = new[] { 6, 7, 8, 8 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(7, actual.Count);
    }


    [TestMethod]
    public void GetPath_68889_Returns8Steps()
    {
        var input = new[] { 6, 8, 8, 8, 9 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(8, actual.Count);
    }


    [TestMethod]
    public void GetPath_2677889_Returns9Steps()
    {
        var input = new[] { 2, 6, 7, 7, 8, 8, 9 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(9, actual.Count);
    }


    [TestMethod]
    public void GetPath_26888999_Returns10Steps()
    {
        var input = new[] { 2, 6, 8, 8, 8, 9, 9, 9 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(10, actual.Count);
    }


    [TestMethod]
    public void GetPath_3778888999_Returns11Steps()
    {
        var input = new[] { 3, 7, 7, 8, 8, 8, 8, 9, 9, 9 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(11, actual.Count);
    }


    [TestMethod]
    public void GetPath_277777788888899_Returns11Steps()
    {
        var input = new[] { 2, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 9, 9 };
        var actual = this.Target.GetPath(new List<int[]> { input });
        Assert.AreEqual(12, actual.Count);
    }

    #endregion
}