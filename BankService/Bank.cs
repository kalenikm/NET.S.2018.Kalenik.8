using System;
using System.Collections.Generic;

namespace BankService
{ 
    public class Bank
    {
        private List<BankAccount> _bankAccounts;

        /// <summary>
        /// Creates new bank system.
        /// </summary>
        public Bank()
        {
            _bankAccounts = new List<BankAccount>();
        }

        /// <summary>
        /// Loads bank account from storage.
        /// </summary>
        /// <param name="storage">Storage to load from.</param>
        public void LoadAccounts(IBankStorage storage)
        {
            if (ReferenceEquals(null, storage))
                throw new ArgumentNullException($"{nameof(storage)} is null.");

            _bankAccounts = storage.Load();
        }

        /// <summary>
        /// Saves bank accounts to storage.
        /// </summary>
        /// <param name="storage">Storage to save in.</param>
        public void SaveAccounts(IBankStorage storage)
        {
            if (ReferenceEquals(null, storage))
                throw new ArgumentNullException($"{nameof(storage)} is null.");

            storage.Save(_bankAccounts);
        }

        /// <summary>
        /// Creates new bank account.
        /// </summary>
        /// <param name="account"></param>
        public void NewAccount(BankAccount account)
        {
            if (ReferenceEquals(null, account))
                throw new ArgumentNullException($"{nameof(account)} is null.");

            _bankAccounts.Add(account);
        }

        /// <summary>
        /// Remove bank account from bank system.
        /// </summary>
        /// <param name="account">Bank account to remove.</param>
        public void DeleteAccount(BankAccount account)
        {
            if (ReferenceEquals(null, account))
                throw new ArgumentNullException($"{nameof(account)} is null.");

            _bankAccounts.Remove(account);
        }

        /// <summary>
        /// Find and returns bank account by id.
        /// </summary>
        /// <param name="id">Id to find by.</param>
        /// <returns>Bank account with this id or null.</returns>
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