using System.Collections.Generic;
using Catharsium.Util.Comparers;
using Catharsium.Util.Math.Interfaces;
using Catharsium.Util.Math.Lists;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Persistance.Tests
{
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
            var input = new int[] { 0 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(input, actual[0]);
        }


        [TestMethod]
        public void GetPath_DoubleDigit_FirstStepEqualsInput()
        {
            var input = new int[] { 1, 2 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(input, actual[0]);
        }


        [TestMethod]
        public void GetPath_10_ReturnsExpectedSteps()
        {
            var input = new int[] { 1, 0 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(input, actual[0]);
            Assert.IsTrue(this.Comparer.Equals(new int[] { 0 }, actual[1]));
        }


        [TestMethod]
        public void GetPath_25_ReturnsExpectedSteps()
        {
            var input = new int[] { 2, 5 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(input, actual[0]);
            Assert.IsTrue(this.Comparer.Equals(new int[] { 1, 0 }, actual[1]));
            Assert.IsTrue(this.Comparer.Equals(new int[] { 0 }, actual[2]));
        }


        [TestMethod]
        public void GetPath_39_ReturnsExpectedSteps()
        {
            var input = new int[] { 3, 9 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(4, actual.Count);
            Assert.AreEqual(input, actual[0]);
            Assert.IsTrue(this.Comparer.Equals(new int[] { 2, 7 }, actual[1]));
            Assert.IsTrue(this.Comparer.Equals(new int[] { 1, 4 }, actual[2]));
            Assert.IsTrue(this.Comparer.Equals(new int[] { 4 }, actual[3]));
        }


        [TestMethod]
        public void GetPath_77_ReturnsExpectedSteps()
        {
            var input = new int[] { 7, 7 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(5, actual.Count);
            Assert.AreEqual(input, actual[0]);
            Assert.IsTrue(this.Comparer.Equals(new int[] { 4, 9 }, actual[1]));
            Assert.IsTrue(this.Comparer.Equals(new int[] { 3, 6 }, actual[2]));
            Assert.IsTrue(this.Comparer.Equals(new int[] { 1, 8 }, actual[3]));
            Assert.IsTrue(this.Comparer.Equals(new int[] { 8 }, actual[4]));
        }


        [TestMethod]
        public void GetPath_679_ReturnsExpectedSteps()
        {
            var input = new int[] { 6, 7, 9 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(6, actual.Count);
            Assert.AreEqual(input, actual[0]);
            Assert.IsTrue(this.Comparer.Equals(new int[] { 3, 7, 8 }, actual[1]));
            Assert.IsTrue(this.Comparer.Equals(new int[] { 1, 6, 8 }, actual[2]));
            Assert.IsTrue(this.Comparer.Equals(new int[] { 4, 8 }, actual[3]));
            Assert.IsTrue(this.Comparer.Equals(new int[] { 3, 2 }, actual[4]));
            Assert.IsTrue(this.Comparer.Equals(new int[] { 6 }, actual[5]));
        }


        [TestMethod]
        public void GetPath_6788_Returns7Steps()
        {
            var input = new int[] { 6, 7, 8, 8 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(7, actual.Count);
        }


        [TestMethod]
        public void GetPath_68889_Returns8Steps()
        {
            var input = new int[] { 6, 8, 8, 8, 9 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(8, actual.Count);
        }


        [TestMethod]
        public void GetPath_2677889_Returns9Steps()
        {
            var input = new int[] { 2, 6, 7, 7, 8, 8, 9 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(9, actual.Count);
        }


        [TestMethod]
        public void GetPath_26888999_Returns10Steps()
        {
            var input = new int[] { 2, 6, 8, 8, 8, 9, 9, 9 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(10, actual.Count);
        }
        

        [TestMethod]
        public void GetPath_3778888999_Returns11Steps()
        {
            var input = new int[] { 3, 7, 7, 8, 8, 8, 8, 9, 9, 9 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(11, actual.Count);
        }


        [TestMethod]
        public void GetPath_277777788888899_Returns11Steps()
        {
            var input = new int[] { 2, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 9, 9 };
            var actual = this.Target.GetPath(new List<int[]> { input });
            Assert.AreEqual(12, actual.Count);
        }

        #endregion
    }
}