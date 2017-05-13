using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendGym.Model
{
    class ItemModel
    {
        public string itemId;
        private int featureSize;
        private int[] featureList;

        public ItemModel(int featureSize)
        {
            this.itemId = Util.GenerateRandomString();
            this.featureSize = featureSize;
            this.featureList = new int[featureSize];

            GenerateFeatureRandomly();
        }

        private void GenerateFeatureRandomly()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < featureSize; i++)
            {
                featureList[i] = random.Next(100);
            }

            for(int i = 0; i < random.Next(3); i++)
            {
                //featureList[random.Next(featureSize)] = random.Next(50) + 50;
            }
        }

        public int[] GetFeatureList()
        {
            return this.featureList;
        }

    }
}
