using System.Dynamic;

namespace BankService
{
    public abstract class BankAccountType
    {
        protected int Bonus;
        protected decimal Coef;
        protected string Title;
        public abstract int BonusForWithdraw(decimal x);
        public abstract int BonusForRefill(decimal x);

        public string GetName()
        {
            return Title;
        }
    }

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
            return -(int)(Coef/2 * x);
        }

        public override int BonusForRefill(decimal x)
        {
            return (int)(Coef * x);
        }
    }

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
    public class PlatinumBankAccount : BankAccountType
    {
        private static PlatinumBankAccount _account;

        private PlatinumBankAccount()
        {
            Coef = 0.5m;
            Title = "Platinum";
        }

        public static PlatinumBankAccount CreateInstance => _account ?? (_account = new PlatinumBankAccount());

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