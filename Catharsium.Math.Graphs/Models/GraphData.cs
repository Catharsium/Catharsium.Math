namespace Catharsium.Math.Graphs.Models;

public class GraphData
{
    public IEnumerable<KeyValuePair<string, decimal>> Data { get; set; }

    public int Size { get; set; } = 100;

    public char Block { get; set; } = '=';
}