using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendGym
{
    class Util
    {
        public static String GenerateRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[64];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public static double GetSigmoidResult(double x)
        {
            return 1 / (1 + Math.Exp(-x)) - 0.5;
        }

        public static double GetEuclideanDistance(int[] featureList1, int[] featureList2)
        {
            double result = 0;

            if(featureList1.Length != featureList2.Length)
            {
                throw new Exception("feature size is different");
            }

            for(int i = 0; i < featureList1.Length; i++)
            {
                result += Math.Pow(featureList1[i] - featureList2[i], 2);
            }

            return Math.Sqrt(result);
        }

        /*
        -1.0 ~ -0.7 : 매우 부정
        -0.7 ~ -0.3 : 강한 부정
        -0.3 ~ -0.1 : 약한 부정
        -0.1 ~ 0.1 : 관계 없음
        0.1 ~ 0.3 : 약한 긍정
        0.3 ~ 0.7 : 강한 긍정
        0.7 ~ 1.0 : 매우 긍정 
         */
        public static double GetPearsonCofficient(int[] featureList1, int[] featureList2)
        {
            double result1 = 0;
            double result2 = 0;
            double result3 = 0;
            double sumX = 0;
            double sumY = 0;
            double sumPowX = 0;
            double sumPowY = 0;
            double sumXY = 0;
            double n = featureList1.Length;
            if (featureList1.Length != featureList2.Length)
            {
                throw new Exception("feature size is different");
            }

            for(int i = 0; i < featureList1.Length; i++)
            {
                result1 += featureList1[i] * featureList2[i];
                result2 += Math.Abs(featureList1[i]);
                result3 += Math.Abs(featureList2[i]);

                sumXY += featureList1[i] * featureList2[i];

                sumX += featureList1[i];
                sumY += featureList2[i];

                sumPowX += Math.Pow(featureList1[i], 2);
                sumPowY += Math.Pow(featureList2[i], 2);
            }

            result1 = (sumXY - sumX * sumY / n);
            result2 = Math.Sqrt(((sumPowX - Math.Pow(sumX, 2) / n) * (sumPowY - Math.Pow(sumY, 2) / n)));
            return result1/result2;
        }
    }
}
