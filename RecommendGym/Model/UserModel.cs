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
            Random random = new Random();
            for(int i = 0; i < propensitySize; i++)
            {
                double weight = random.NextDouble();
                double bias = random.NextDouble();
                this.propensityList[i] = new PropensityModel(weight, bias);
            }
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
