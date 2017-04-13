using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendGym.Model
{
    class NeuralModel
    {
        private double weight;
        private double bias;

        public NeuralModel(double weight, double bias)
        {
            this.weight = weight;
            this.bias = bias;
        }

        public void PrintValue()
        {
            Console.WriteLine("weight : " + weight + " bias : " + bias);
        }
    }
}
