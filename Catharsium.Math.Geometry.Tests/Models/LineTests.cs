using Catharsium.Math.Geometry.Interfaces;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Math.Geometry.Tests.Models
{
    [TestClass]
    public class LineTests : TestFixture<Line>
    {
        [TestMethod]
        public void GetLength_ReturnsDistanceBetweenEndPoints()
        {
            var expected = 10;
            var p = new Point(1, 2);
            var q = new Point(3, 4);
            this.Target.P = p;
            this.Target.Q = q;
            this.GetDependency<IDistanceCalculator>().GetDistance(Arg.Is<Point>(pP => System.Math.Abs(pP.X - p.X) < 0.001 && System.Math.Abs(pP.Y - p.Y) < 0.001),
                Arg.Is<Point>(pQ => System.Math.Abs(pQ.X - q.X) < 0.001 && System.Math.Abs(pQ.Y - q.Y) < 0.001)).Returns(expected);
            
            var actual = this.Target.GetLength();
            Assert.AreEqual(expected, actual);
        }
    }
}