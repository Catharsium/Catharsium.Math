using Catharsium.Math.Util.Numbers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Util.Tests.Numbers
{
    [TestClass]
    public class PartitionerTests : TestFixture<Partitioner>
    {
        #region Fixture

        private int[][] Partitions { get; set; }


        [TestInitialize]
        public void SetupProperties()
        {
            this.Partitions = new[] {
                new[] {1, 2},
                new[] {3, 5}
            };

            this.SetDependency(this.Partitions);
        }

        #endregion

        #region FindPartitions

        [TestMethod]
        public void FindPartition_EqualsLowerBoundOfPartition_ReturnsPartition()
        {
            var actual = this.Target.FindPartition(1);
            Assert.AreEqual(this.Partitions[0], actual);
        }


        [TestMethod]
        public void FindPartition_EqualsUpperBoundOfPartition_ReturnsPartition()
        {
            var actual = this.Target.FindPartition(2);
            Assert.AreEqual(this.Partitions[0], actual);
        }


        [TestMethod]
        public void FindPartition_FallsWithinBoundsOfPartition_ReturnsPartition()
        {
            var actual = this.Target.FindPartition(4);
            Assert.AreEqual(this.Partitions[1], actual);
        }


        [TestMethod]
        public void FindPartition_SmallerThanFirstPartition_ReturnsLastPartition()
        {
            var actual = this.Target.FindPartition(0);
            Assert.AreEqual(this.Partitions[0], actual);
        }


        [TestMethod]
        public void FindPartition_LargerThanLastPartition_ReturnsLastPartition()
        {
            var actual = this.Target.FindPartition(4);
            Assert.AreEqual(this.Partitions[^1], actual);
        }

        #endregion
    }
}