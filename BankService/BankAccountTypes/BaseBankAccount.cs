namespace BankService.BankAccountTypes
{
    public class BaseBankAccount : BankAccountType
    {
        private static BaseBankAccount _account;

        private BaseBankAccount()
        {
            this.Сoefficient = 0.1m;
            this.Title = "Base";
        }

        public static BaseBankAccount CreateInstance => _account ?? (_account = new BaseBankAccount());

        public override int BonusForWithdraw(decimal x)
        {
            return -(int)(Сoefficient / 2 * x);
        }

        public override int BonusForRefill(decimal x)
        {
            return (int)(Сoefficient * x);
        }
    }
}