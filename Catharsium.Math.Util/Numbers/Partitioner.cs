using System.Linq;
using Catharsium.Math.Util.Interfaces;

namespace Catharsium.Math.Util.Numbers
{
    public class Partitioner : IPartitioner
    {
        private int[][] Partitions { get; }


        public Partitioner(int[][] partitions)
        {
            this.Partitions = partitions;
        }



        public int[] FindPartition(int i)
        {
            var result = this.Partitions.FirstOrDefault(p => p[0] <= i && p[1] >= i);
            return result ?? this.Partitions[^1];
        }
    }
}