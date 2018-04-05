namespace BankService.BankAccountTypes
{
    public class PlatinumBankAccount : BankAccountType
    {
        private static PlatinumBankAccount _account;

        private PlatinumBankAccount()
        {
            this.Сoefficient = 0.5m;
            this.Title = "Platinum";
        }

        public static PlatinumBankAccount CreateInstance => _account ?? (_account = new PlatinumBankAccount());

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