namespace BankService.BankAccountTypes
{
    public class GoldBankAccount : BankAccountType
    {
        private static GoldBankAccount _account;

        private GoldBankAccount()
        {
            this.Сoefficient = 0.2m;
            this.Title = "Gold";
        }

        public static GoldBankAccount CreateInstance => _account ?? (_account = new GoldBankAccount());

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