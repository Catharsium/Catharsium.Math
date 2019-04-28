using Catharsium.Util.Comparers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Catharsium.Math.Tests.Partitioning
{
    [TestClass]
    public class PartitionerTests : TestFixture<Partitioner>
    {
        #region Fixture

        private EnumerableEqualityComparer<decimal> ArrayComparer { get; set; }


        [TestInitialize]
        public void SetupUtils()
        {
            this.ArrayComparer = new EnumerableEqualityComparer<decimal>();
        }

        #endregion

        #region GetSections(total, seperators)

        [TestMethod]
        public void GetSections_ResultLengthIsOneOverSeperatorsLength()
        {
            var total = 14m;
            var seperators = new[] { 1m, 1m, 1m, 1m };

            var actual = this.Target.GetSections(total, seperators);
            Assert.IsNotNull(actual);
            Assert.AreEqual(5, actual.Length);
        }


        [TestMethod]
        public void GetSections_ResultSumEqualsTotalMinusSeperators()
        {
            var total = 14m;
            var seperators = new[] { 1m, 1m, 1m, 1m };

            var actual = this.Target.GetSections(total, seperators);
            Assert.IsNotNull(actual);
            Assert.AreEqual(total - seperators.Sum(), actual.Sum());
        }


        [TestMethod]
        public void GetSections_NoSeperators_ReturnsTotalAsSingleSection()
        {
            var total = 10m;
            var seperators = new decimal[0];

            var actual = this.Target.GetSections(total, seperators);
            Assert.IsNotNull(actual);
            Assert.IsTrue(this.ArrayComparer.Equals(new[] { total }, actual));
        }


        [TestMethod]
        public void GetSections_0Total_EachSectionIs0()
        {
            var total = 0m;
            var seperators = new[] { 1m, 1m };

            var actual = this.Target.GetSections(total, seperators);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.All(s => s == 0));
        }

        #endregion

        #region GetSections(total, sections, seperators)

        [TestMethod]
        public void GetSections_ReturnsGetSectionsWithPopulatedSeperators()
        {
            var total = 11m;
            var numberOfSeperators = 3;
            var seperators = 1m;

            var expectedSeperators = new decimal[numberOfSeperators];
            for (var i = 0; i < numberOfSeperators; i++)
            {
                expectedSeperators[i] = seperators;
            }
            var expected = this.Target.GetSections(total, expectedSeperators);

            var actual = this.Target.GetSections(total, numberOfSeperators, seperators);
            Assert.IsNotNull(actual);
            Assert.IsTrue(this.ArrayComparer.Equals(expected, actual));
        }

        #endregion
    }
}