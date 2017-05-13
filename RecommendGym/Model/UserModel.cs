using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendGym.Model
{
    class UserModel
    {
        public String userId;
        private int propensitySize;
        private PropensityModel[] propensityList;

        public UserModel(int propensitySize)
        {
            this.userId = Util.GenerateRandomString();
            this.propensitySize = propensitySize;
            this.propensityList = new PropensityModel[propensitySize];

            GeneratePropensityRandomly();
        }

        private void GeneratePropensityRandomly()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for(int i = 0; i < propensitySize; i++)
            {
                double weight = random.NextDouble() - 0.5;
                double bias = random.NextDouble() - 0.5;
                this.propensityList[i] = new PropensityModel(weight, bias);
            }
        }

        public double GetPreference(double[] featureList)
        {
            double[] layer = new double[propensitySize];
            double preference = 0;
            for(int k = 0; k < propensitySize; k++)
            { 
                for(int i = 0; i < featureList.Length; i++)
                {
                    layer[k] += propensityList[k].GetCalculateOutput(featureList[i]);
                }
                layer[k] = Util.GetSigmoidResult(layer[k]);
                preference += layer[k];
            }
            

            return Util.GetSigmoidResult(preference);
        }

        public int GetPropensitySize()
        {
            return this.propensitySize;
        }

        public void PrintValue()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("userId : " + this.userId);
            Console.WriteLine("propensitySize : " + this.propensitySize);
            Console.WriteLine("propensityList");
            for(int i = 0; i < propensitySize; i++)
            {
                PropensityModel propensity = propensityList[i];
                propensity.PrintValue();
            }

        }


    }
}
