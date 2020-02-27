using System;
using System.Collections.Generic;
using System.Text;
using PremiumCalculator.Ent;

namespace PremiumCalculator.BL
{
    public class NumberGenerator : INumberGenerator
    {
        private readonly Random random = new Random();
        private enum Periods { Monthly = 1, Quarterly = 3, SemiAnually = 6, Anually = 12 }

        public double GetRandomNumber(double minValue, double maxValue)
        {
            var number = random.NextDouble();
            return minValue + (number * (maxValue - minValue));
        }

        public CalculationEnt GetCalculation(double number, int period)
        {
            CalculationEnt obj = new CalculationEnt();

            int frecuency = 0;
            switch (period)
            {
                case 1:
                    frecuency = (int)Periods.Monthly;
                    break;
                case 2:
                    frecuency = (int)Periods.Quarterly;
                    break;
                case 3:
                    frecuency = (int)Periods.SemiAnually;
                    break;
                case 4:
                    frecuency = (int)Periods.Anually;
                    break;
                default:
                    frecuency = -1;
                    break;
            }

            if(frecuency > 0)
            {
                obj.Monthly = number / frecuency;
                obj.Annual = number * (12 / frecuency);
            }

            return obj;
        }
    }
}
