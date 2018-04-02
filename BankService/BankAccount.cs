using System;

namespace BankService
{
    public interface IBankAccount
    {
        void Withdraw(decimal x);
        void Refill(decimal x);
    }

    public class BankAccount : IBankAccount
    {
        private static int _globalId;
        private string _firstName;
        private string _lastName;
        private decimal _money;
        private int _bonus;

        private readonly BankAccountType _type;

        #region Properties

        public int Id { get; }

        public string FirstName
        {
            get { return _firstName; }
            private set
            {
                if(value == null)
                    throw new ArgumentNullException($"{nameof(value)} is null.");

                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException($"{nameof(value)} is null.");

                _lastName = value;
            }
        }

        public decimal Money => _money;
        public int Bonus => _bonus;

        public string Type => _type.GetName();

        #endregion

        #region ObjectMethods

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Money: {Money:C}, Bonus: {Bonus}, Type: {Type}.";
        }

        #endregion

        /// <summary>
        /// Creates new bank account.
        /// </summary>
        /// <param name="firstName">First name of person.</param>
        /// <param name="lastName">Last name of person.</param>
        /// <param name="type">Type of bank account.</param>
        public BankAccount(string firstName, string lastName, string type)
        {
            Id = ++_globalId;
            FirstName = firstName;
            LastName = lastName;
            _type = TypesFactory.GetType(type);
        }

        public BankAccount(int id, string firstName, string lastName, decimal money, int bonus, string type)
        {
            if (_globalId.Equals(id))
                _globalId++;

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            _money = money;
            _bonus = bonus;
            _type = TypesFactory.GetType(type);
        }

        /// <summary>
        /// Withdraws money from bank account.
        /// </summary>
        /// <param name="x">Money to withdraw.</param>
        public void Withdraw(decimal x)
        {
            if(x > _money)
                throw new ArgumentException("Not enough money.");
            if(x <= 0)
                throw new ArgumentException();

            _money -= x;
            _bonus += _type.BonusForWithdraw(x);
        }

        /// <summary>
        /// Refill a bank account.
        /// </summary>
        /// <param name="x">Money to refill.</param>
        public void Refill(decimal x)
        {
            if (x <= 0)
                throw new ArgumentException();

            _money += x;
            _bonus += _type.BonusForRefill(x);
        }
    }
}
