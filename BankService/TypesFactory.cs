using System;

namespace BankService
{
    public static class TypesFactory
    {
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