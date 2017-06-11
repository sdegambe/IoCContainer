using System;

namespace DevIoC
{
    class DollarsLoan : ILoan
    {
        public void GetMoney(int quantity)
        {
            Console.WriteLine(string.Format("Dollars loan ${0}", quantity));
        }
    }
}
