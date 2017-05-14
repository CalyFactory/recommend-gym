using RecommendGym.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecommendGym
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int positive = 0;
            int negative = 0;
            for (int i = 0; i < 100000; i++)
            {
                UserModel userModel = new UserModel(100);
                double[] data = { 0.5, 0.4, 0.3, 0.9, 0.1 };
                double preference = userModel.GetPreference(data);
//                Console.WriteLine("result : " + preference);
                if (preference > 0)
                {
                    positive++;
                }
                else
                {
                    negative++;
                }
            }
            Console.WriteLine("positive : " + positive);
            Console.WriteLine("negative : " + negative);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int userPropensitySize = 100;
            int userSize = 100;
            int itemFeatureSize = 10;
            int itemSize = 100;
            UserModel[] userList = new UserModel[userSize];

            for(int i = 0; i < userSize; i++)
            {
                userList[i] = new UserModel(userPropensitySize);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ItemModel[] itemList = new ItemModel[10];
            for(int i = 0; i < 10; i++)
            {
                itemList[i] = new ItemModel(10);
            }

            Console.WriteLine("=================================");
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.Write(
                        String.Format("{0,10:0.0} ",
                            (Util.GetEuclideanDistance(itemList[i].GetFeatureList(), itemList[j].GetFeatureList()))
                        )
                    );
                }
                Console.WriteLine();
            }
            Console.WriteLine("=================================");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(
                        String.Format("{0,10:0.0} ",
                            (Util.GetPearsonCofficient(itemList[i].GetFeatureList(), itemList[j].GetFeatureList()))
                        )
                    );
                }
                Console.WriteLine();
            }
            Console.WriteLine("=================================");
            for(int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    double person =Util.GetPearsonCofficient(itemList[i].GetFeatureList(), itemList[j].GetFeatureList());
                    if (person >= 0.2)
                    {
                        Console.Write(" " + (j + 1));
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
