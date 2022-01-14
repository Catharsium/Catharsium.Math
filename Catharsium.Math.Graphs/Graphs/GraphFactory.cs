using Catharsium.Math.Graphs.Interfaces;
using Catharsium.Math.Graphs.Interfaces;

namespace Catharsium.Math.Graphs.Graphs;

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