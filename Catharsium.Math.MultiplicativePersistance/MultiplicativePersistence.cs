using System.Collections.Generic;
using System.Linq;
using Catharsium.Math.Persistance.Interfaces;
using Catharsium.Util.Math.Interfaces;

namespace Catharsium.Math.Persistance
{
    public class MultiplicativePersistence : IMultiplicativePersistence
    {
        private readonly IListMultiplicator multiplicator;


        public MultiplicativePersistence(IListMultiplicator multiplicator)
        {
            this.multiplicator = multiplicator;
        }


        public List<int[]> GetPath(List<int[]> input)
        {
            var currentStep = input[input.Count - 1];

            if (currentStep.Length == 1)
            {
                return input;
            }

            var nextStep = this.multiplicator.Multiply(currentStep).ToString();
            input.Add(nextStep.Select(o => int.Parse(o.ToString())).ToArray());

            return this.GetPath(input);
        }
    }
}