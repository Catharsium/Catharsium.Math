using Catharsium.Math.Graph.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Math.Graph.Graphs
{
    public class GraphFactory : IGraphFactory
    {
        private readonly IEnumerable<IGraph> graphs;

        public GraphFactory(IEnumerable<IGraph> graphs)
        {
            this.graphs = graphs;
        }


        public IGraph CreateHorizontalBarGraph()
        {
            return this.graphs.FirstOrDefault(g => g.GetType() == typeof(HorizontalBarGraph));
        }
    }
}