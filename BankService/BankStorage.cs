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
        public BankStorage(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException();

            _filename = filename;
        }

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