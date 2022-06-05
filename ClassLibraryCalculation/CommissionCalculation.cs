using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculation
{
    public class CommissionCalculation
    {
        /// <summary>
        /// метод расчета комиссии
        /// </summary>
        /// <param name="price"></param>
        /// <param name="commission"></param>
        /// <returns>commission</returns>
        public static double CalculationCommission(double price, double commission)
        {
            if (price < 4000000)
            {
                commission = price * 0.04;
            }
            if (price < 8000000 && price >= 4000000)
            {
                commission = price * 0.03;
            }
            if (price >= 8000000)
            {
                commission = price * 0.02;
            }
            return commission;
        }
    }
}
