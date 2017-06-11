using System;

namespace DevIoC
{
    class EuroLoan : ILoan
    {
        public void GetMoney(int quantity)
        {
            Console.WriteLine(string.Format("Euro loan {0}", quantity));
        }
    }
}
