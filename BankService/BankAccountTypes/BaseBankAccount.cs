namespace BankService.BankAccountTypes
{
    public class BaseBankAccount : BankAccountType
    {
        private static BaseBankAccount _account;

        private BaseBankAccount()
        {
            Coef = 0.1m;
            Title = "Base";
        }

        public static BaseBankAccount CreateInstance => _account ?? (_account = new BaseBankAccount());

        public override int BonusForWithdraw(decimal x)
        {
            return -(int)(Coef / 2 * x);
        }

        public override int BonusForRefill(decimal x)
        {
            return (int)(Coef * x);
        }
    }
}