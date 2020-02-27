using PremiumCalculator.Ent;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.BL
{
    public interface INumberGenerator
    {
        double GetRandomNumber(double minValue, double maxValue);
        CalculationEnt GetCalculation(double number, int period);
    }
}
