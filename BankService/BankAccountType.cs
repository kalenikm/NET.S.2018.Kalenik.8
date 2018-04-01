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
}