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
    }
}
