using Catharsium.Util.Comparers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Catharsium.Math.Partitioning;

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
        public void GetSections_ResultLengthIsOneOverSeparatorsLength()
        {
            var total = 14m;
            var separators = new[] { 1m, 1m, 1m, 1m };

            var actual = this.Target.GetSections(total, separators);
            Assert.IsNotNull(actual);
            Assert.AreEqual(5, actual.Length);
        }


        [TestMethod]
        public void GetSections_ResultSumEqualsTotalMinusSeparators()
        {
            var total = 14m;
            var separators = new[] { 1m, 1m, 1m, 1m };

            var actual = this.Target.GetSections(total, separators);
            Assert.IsNotNull(actual);
            Assert.AreEqual(total - separators.Sum(), actual.Sum());
        }


        [TestMethod]
        public void GetSections_NoSeparators_ReturnsTotalAsSingleSection()
        {
            var total = 10m;
            var separators = new decimal[0];

            var actual = this.Target.GetSections(total, separators);
            Assert.IsNotNull(actual);
            Assert.IsTrue(this.ArrayComparer.Equals(new[] { total }, actual));
        }


        [TestMethod]
        public void GetSections_0Total_EachSectionIs0()
        {
            var total = 0m;
            var separators = new[] { 1m, 1m };

            var actual = this.Target.GetSections(total, separators);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.All(s => s == 0));
        }

        #endregion

        #region GetSections(total, sections, seperators)

        [TestMethod]
        public void GetSections_ReturnsGetSectionsWithPopulatedSeparators()
        {
            var total = 11m;
            var numberOfSeparators = 3;
            var separators = 1m;

            var expectedSeparators = new decimal[numberOfSeparators];
            for (var i = 0; i < numberOfSeparators; i++)
            {
                expectedSeparators[i] = separators;
            }
            var expected = this.Target.GetSections(total, expectedSeparators);

            var actual = this.Target.GetSections(total, numberOfSeparators, separators);
            Assert.IsNotNull(actual);
            Assert.IsTrue(this.ArrayComparer.Equals(expected, actual));
        }

        #endregion
    }
}