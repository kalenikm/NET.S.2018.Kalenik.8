namespace BankService
{
    public abstract class BankAccountType
    {
        protected int Bonus;
        protected decimal Coef;
        protected string Title;

        /// <summary>
        /// Considers bonus for withdraw.
        /// </summary>
        /// <param name="x">Money.</param>
        /// <returns>Value of bonus.</returns>
        public abstract int BonusForWithdraw(decimal x);

        /// <summary>
        /// Considers bonus for 
        /// </summary>
        /// <param name="x">Money.</param>
        /// <returns>Value of bonus.</returns>
        public abstract int BonusForRefill(decimal x);

        /// <summary>
        /// Returns string name of account type.
        /// </summary>
        /// <returns>Name of account type.</returns>
        public string GetName()
        {
            return Title;
        }
    }
}