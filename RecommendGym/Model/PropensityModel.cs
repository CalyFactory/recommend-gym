using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendGym.Model
{
    class PropensityModel
    {
        private double weight;
        private double bias;

        public PropensityModel(double weight, double bias)
        {
            this.weight = weight;
            this.bias = bias;
        }

        public void PrintValue()
        {
            Console.WriteLine("weight : " + weight + " bias : " + bias);
        }

        public double GetCalculateOutput(double value)
        {
            return value * weight + bias;
        }

    }
}
