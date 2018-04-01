using System;
using System.Text.RegularExpressions;
using static System.String;

namespace BookService
{
    public class Book : IComparable, IEquatable<Book>
    {
        private string _isbn;
        private string _author;
        private string _title;
        private string _publisher;
        private int _year;
        private int _pages;
        private decimal _price;

        #region Properties

        public string Isbn
        {
            get { return _isbn; }
            private set
            {
                if (!IsValidString(value))
                    throw new ArgumentException($"{nameof(value)} is empty or null.");

                if (!IsValidIsbn(value))
                    throw new ArgumentException($"{nameof(value)} is incorrect. Check format of ISBN.");

                _isbn = value;
            }
        }

        public string Author
        {
            get { return _author; }
            private set
            {
                if (!IsValidString(value))
                    throw new ArgumentException($"{nameof(value)} is empty or null.");

                _author = value;
            }
        }
        public string Title
        {
            get { return _title; }
            private set
            {
                if (!IsValidString(value))
                    throw new ArgumentException($"{nameof(value)} is empty or null.");

                _title = value;
            }
        }
        public string Publisher
        {
            get { return _publisher; }
            private set
            {
                if (!IsValidString(value))
                    throw new ArgumentException($"{nameof(value)} is empty or null.");

                _publisher = value;
            }
        }
        public int Year
        {
            get { return _year; }
            private set
            {
                if (!IsValidYear(value))
                    throw new ArgumentException($"{nameof(value)} is incorrect.");

                _year = value;
            }
        }
        public int Pages
        {
            get { return _pages; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(value)} is incorrect. Number of pages can't be less then 0.");

                _pages = value;
            }
        }
        public decimal Price
        {
            get { return _price; }
            private set
            {
                if (Math.Round(value, 2) <= 0)
                    throw new ArgumentException($"{nameof(value)} is incorrect. Price can't be less then 0.");

                _price = value;
            }
        }

        #endregion
        
        public int CompareTo(object obj)
        {
            Book book = obj as Book;

            if(ReferenceEquals(book, null))
                throw new ArgumentException($"{nameof(obj)} is not a Book.");

            return Compare(book.Title, Title, StringComparison.Ordinal);
        }

        public bool Equals(Book book)
        {
            if (ReferenceEquals(null, book))
                return false;
            if (ReferenceEquals(this, book))
                return true;

            if (!book.Isbn.Equals(Isbn))
                return false;

            if (!book.Author.Equals(Author))
                return false;

            if (!book.Title.Equals(Title))
                return false;

            if (!book.Publisher.Equals(Publisher))
                return false;

            if (!book.Year.Equals(Year))
                return false;

            if (!book.Pages.Equals(Pages))
                return false;

            if (!book.Price.Equals(Price))
                return false;

            return true;
        }

        public Book(string isbn, string author, string title, string publisher, int year, int pages, decimal price)
        {
            Isbn = isbn;
            Author = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            Pages = pages;
            Price = price;
        }

        #region Checkers

        private bool IsValidIsbn(string isbn) // isbn code contains 13 digits and 4 seperators '-'. 13 + 4 == 17
        {
            return isbn.Length == 17 && Regex.IsMatch(isbn, @"978-\d{1,5}-\d{1,7}-\d{1,6}-\d");
        }

        private bool IsValidYear(int year) 
        {
            return year > 1900 && year <= DateTime.Now.Year;
        }

        public bool IsValidString(string str)
        {
            return !ReferenceEquals(null, str) && str.Length != 0;
        }

        #endregion

        #region ObjectMethods

        public override string ToString()
        {
            return $"{Isbn} \"{Title}\" {Author}, {Publisher}, {Year}, {Pages} pages, {Price:C}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            Book book = obj as Book;
            if (book == null)
                return false;

            return GetHashCode().Equals(book.GetHashCode());
        }

        #endregion
    }
}
