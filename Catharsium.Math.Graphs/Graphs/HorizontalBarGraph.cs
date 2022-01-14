using Catharsium.Math.Graphs.Models;
using Catharsium.Math.Graphs.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Math.Graphs.Graphs;

public class HorizontalBarGraph : IGraph
{
    private readonly IConsole console;


    public HorizontalBarGraph(IConsole console)
    {
        this.console = console;
    }


    public void Generate(GraphData data)
    {
        var maxKeyLength = data.Data.Max(g => g.Key.Length);
        var maxValueLength = data.Data.Max(g => g.Value.ToString("n0").Length);
        var maxValue = data.Data.Max(g => g.Value);
        var blockString = data.Block.ToString();

        foreach (var entry in data.Data) {
            var percentage = entry.Value / maxValue;
            var length = System.Math.Round(percentage * data.Size);
            this.console.Write(entry.Key);
            this.console.FillBlock(entry.Key.Length, maxKeyLength);
            this.console.Write($" (");
            this.console.ForegroundColor = ConsoleColor.DarkGreen;
            this.console.Write($"{entry.Value:n0}");
            this.console.ResetColor();
            this.console.Write($")");
            this.console.FillBlock(entry.Value.ToString("n0").Length, maxValueLength + 2);
            for (var i = 0; i < length; i++) {
                this.console.Write(blockString);
            }
            this.console.WriteLine();
        }
    }
}