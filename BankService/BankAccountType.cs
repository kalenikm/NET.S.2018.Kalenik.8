using System;

namespace BankService
{
    public abstract class BankAccountType
    {
        private decimal _coefficient;
        private string _title;

        protected decimal Сoefficient
        {
            get
            {
                return _coefficient;
            }

            set
            {
                if (_coefficient < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                _coefficient = value;
            }
        }

        protected string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _title = value;
            }
        }

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