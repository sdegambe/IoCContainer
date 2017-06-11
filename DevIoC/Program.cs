using System;

namespace DevIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            IDevIoCContainer container = new DevIoCContainer();
            container.RegisterType<ILoan, EuroLoan>();
            container.RegisterType<BankAccount, BankAccount>();
            var bank = container.Resolve<BankAccount>();
            bank.GetLoan();

            Console.ReadLine();
        }
    }
}
