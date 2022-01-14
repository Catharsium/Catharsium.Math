using Catharsium.Math.Geometry.Comparers;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.Math.Geometry.Tests.Comparers.PointEqualityComparerTests;

[TestClass]
public class GetHashCodeTests : TestFixture<PointEqualityComparer>
{
    #region GetHashCode

    [TestMethod]
    public void GetHashCode_ReturnsObjectHashcode()
    {
        var input = new Point(1, 2);
        var actual = this.Target.GetHashCode(input);
        Assert.AreEqual(input.GetHashCode(), actual);
    }

    #endregion
}