using System;
using System.Collections.Generic;
using System.IO;

namespace BankService
{
    public interface IBankStorage
    {
        List<BankAccount> Load();
        void Save(IEnumerable<BankAccount> accounts);
    }
    public class BankStorage : IBankStorage
    {
        private readonly string _filename;

        /// <summary>
        /// Creates new storage.
        /// </summary>
        /// <param name="filename">Filename of file to storage.</param>
        public BankStorage(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException();

            _filename = filename;
        }

        /// <summary>
        /// Loads bank accounts info from file.
        /// </summary>
        /// <returns>List of bank accounts.</returns>
        public List<BankAccount> Load()
        {
            if (!new FileInfo(_filename).Exists)
                throw new ArgumentException();

            var accounts = new List<BankAccount>();

            using (var br = new BinaryReader(new FileStream(_filename, FileMode.OpenOrCreate)))
            {
                while (br.PeekChar() != -1)
                {
                    accounts.Add(new BankAccount(br.ReadInt32(), br.ReadString(), br.ReadString(), br.ReadDecimal(), br.ReadInt32(), br.ReadString()));
                }
            }
            return accounts;
        }

        /// <summary>
        /// Saves bank accounts to file.
        /// </summary>
        /// <param name="accounts">Collection of bank accounts.</param>
        public void Save(IEnumerable<BankAccount> accounts)
        {
            using (var bw = new BinaryWriter(new FileStream(_filename, FileMode.Create)))
            {
                foreach (var acc in accounts)
                {
                    bw.Write(acc.Id);
                    bw.Write(acc.FirstName);
                    bw.Write(acc.LastName);
                    bw.Write(acc.Money);
                    bw.Write(acc.Bonus);
                    bw.Write(acc.Type);
                }
            }
        }
    }
}