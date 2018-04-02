using System;
using BankService.BankAccountTypes;

namespace BankService
{
    public static class TypesFactory
    {
        /// <summary>
        /// Create bank account type by string name.
        /// </summary>
        /// <param name="type">Name of bank account type.</param>
        /// <returns>Bank account type.</returns>
        public static BankAccountType GetType(string type)
        {
            switch (type)
            {
                case "Base":
                    return BaseBankAccount.CreateInstance;
                case "Gold":
                    return GoldBankAccount.CreateInstance;
                case "Platinum":
                    return PlatinumBankAccount.CreateInstance;
                default:
                    throw new ArgumentException();
            }
        }
    }
}