using System.Collections.Generic;

namespace Catharsium.Math.Persistance.Interfaces
{
    public interface IMultiplicativePersistence
    {
        List<int[]> GetPath(List<int[]> input);
    }
}