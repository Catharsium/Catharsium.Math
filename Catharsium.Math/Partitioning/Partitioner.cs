using System;
using System.Linq;

namespace Catharsium.Math.Tests.Partitioning
{
    public class Partitioner
    {
        public decimal[] GetSections(decimal total, int numberOfSections, decimal margin)
        {
            var margins = new decimal[numberOfSections];
            for (var i = 0; i < numberOfSections; i++)
            {
                margins[i] = margin;
            }

            return this.GetSections(total, margins);
        }


        public decimal[] GetSections(decimal total, decimal[] margins)
        {
            var netTotal = System.Math.Max(0, total - margins.Sum());
            var numberOfSections = margins.Length + 1;
            var section = netTotal / numberOfSections;
            var result = new decimal[numberOfSections];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = section;
            }

            return result;
        }
    }
}