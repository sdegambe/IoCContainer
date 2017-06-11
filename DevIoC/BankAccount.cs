namespace DevIoC
{
    class BankAccount
    {
        private readonly ILoan _loan;
        public BankAccount(ILoan loan)
        {
            _loan = loan;
        }

        public void GetLoan()
        {
            _loan.GetMoney(50);
        }
    }
}
