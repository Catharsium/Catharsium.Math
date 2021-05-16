using System.Collections.Generic;

namespace Catharsium.Math.Graph.Models
{
    public class GraphData
    {
        public Dictionary<string, decimal> Data { get; set; }

        public int Size { get; set; } = 100;

        public char Block { get; set; } = '=';
    }
}