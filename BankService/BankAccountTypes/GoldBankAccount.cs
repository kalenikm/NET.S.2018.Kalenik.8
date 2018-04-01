namespace BankService.BankAccountTypes
{
    public class GoldBankAccount : BankAccountType
    {
        private static GoldBankAccount _account;

        private GoldBankAccount()
        {
            Coef = 0.2m;
            Title = "Gold";
        }

        public static GoldBankAccount CreateInstance => _account ?? (_account = new GoldBankAccount());

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