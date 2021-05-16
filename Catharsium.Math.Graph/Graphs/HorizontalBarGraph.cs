using Catharsium.Math.Graph.Interfaces;
using Catharsium.Math.Graph.Models;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Linq;

namespace Catharsium.Math.Graph.Graphs
{
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

            foreach (var group in data.Data) {
                var percentage = group.Value / maxValue;
                var length = System.Math.Round(percentage * data.Size);
                var text = $"{group.Key}{group.Value:n0}";
                this.console.Write(group.Key);
                this.console.FillBlock(group.Key.Length, maxKeyLength);
                this.console.Write($" (");
                this.console.ForegroundColor = ConsoleColor.DarkGreen;
                this.console.Write($"{group.Value:n0}");
                this.console.ResetColor();
                this.console.Write($")");
                this.console.FillBlock(text.Length, maxValueLength + 2);
                for (var i = 0 ; i < length ; i++) {
                    this.console.Write(blockString);
                }
                this.console.WriteLine();
            }
        }
    }
}