using Catharsium.Math.Util.Interfaces;
namespace Catharsium.Math.Util.Numbers;

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
        if (result != null) {
            return result;
        }

        if (i < this.Partitions[0][0]) {
            return this.Partitions[0];
        }

        return i > this.Partitions[^1][1]
            ? this.Partitions[^1]
            : null;
    }
}