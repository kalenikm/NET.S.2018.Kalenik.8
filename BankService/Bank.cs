using System;
using System.Collections.Generic;

namespace BankService
{ 
    public class Bank
    {
        private List<BankAccount> _bankAccounts;

        public Bank()
        {
            _bankAccounts = new List<BankAccount>();
        }

        public void LoadAccounts(IBankStorage storage)
        {
            if(storage == null)
                throw new ArgumentNullException();

            _bankAccounts = storage.Load();
        }

        public void SaveAccounts(IBankStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException();

            storage.Save(_bankAccounts);
        }

        public void NewAccount(string firstName, string lastName, string type)
        {
            _bankAccounts.Add(new BankAccount(firstName, lastName, type));
        }

        public void DeleteAccount(BankAccount account)
        {
            if(account == null)
                throw new ArgumentNullException();

            _bankAccounts.Remove(account);
        }

        public BankAccount GetAccount(int id)
        {
            foreach (var acc in _bankAccounts)
            {
                if (acc.Id.Equals(id))
                    return acc;
            }
            return null;
        }
    }
}