using Catharsium.Math.Geometry.Comparers;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Geometry.Tests.Comparers.PointEqualityComparerTests
{
    [TestClass]
    public class EqualsTests : TestFixture<PointEqualityComparer>
    {
        #region Equals

        [TestMethod]
        public void Equals_IsReflexive()
        {
            var p = new Point(1, 2);
            var actual = this.Target.Equals(p, p);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_IsSymmetric()
        {
            var p = new Point(1, 2);
            var q = new Point(p.X, p.Y);

            var actual = this.Target.Equals(p, q);
            var actualReverse = this.Target.Equals(q, p);
            Assert.AreEqual(actual, actualReverse);
        }


        [TestMethod]
        public void Equals_PointsWithSameContents_ReturnsTrue()
        {
            var p = new Point(1, 2);
            var q = new Point(p.X, p.Y);

            var actual = this.Target.Equals(p, q);
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Equals_PointsWithDifferenX_ReturnsFalse()
        {
            var p = new Point(1, 2);
            var q = new Point(p.X + 1, p.Y);

            var actual = this.Target.Equals(p, q);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_PointsWithDifferenY_ReturnsFalse()
        {
            var p = new Point(1, 2);
            var q = new Point(p.X, p.Y + 1);

            var actual = this.Target.Equals(p, q);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_NullAndPoint_ReturnsFalse()
        {
            var q = new Point(1, 2);
            var actual = this.Target.Equals(null, q);
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void Equals_PointAndNull_ReturnsFalse()
        {
            var p = new Point(1, 2);
            var actual = this.Target.Equals(p, null);
            Assert.IsFalse(actual);
        }

        #endregion
    }
}