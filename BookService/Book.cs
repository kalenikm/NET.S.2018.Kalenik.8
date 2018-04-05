using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BookService
{
    public class Book : IComparable, IEquatable<Book>, IFormattable
    {
        private string isbn;
        private string author;
        private string title;
        private string publisher;
        private int year;
        private int pages;
        private decimal price;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">ISBN of book.</param>
        /// <param name="author">Book author.</param>
        /// <param name="title">Book title.</param>
        /// <param name="publisher">Book publisher.</param>
        /// <param name="year">Year of issue.</param>
        /// <param name="pages">Number of pages.</param>
        /// <param name="price">Book price.</param>
        public Book(string isbn, string author, string title, string publisher, int year, int pages, decimal price)
        {
            this.Isbn = isbn;
            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
            this.Year = year;
            this.Pages = pages;
            this.Price = price;
        }

        #region Properties

        public string Isbn
        {
            get
            {
                return this.isbn;
            }

            private set
            {
                if (!this.IsValidString(value))
                {
                    throw new ArgumentException($"{nameof(value)} is empty or null.");
                }

                if (!this.IsValidIsbn(value))
                {
                    throw new ArgumentException($"{nameof(value)} is incorrect. Check format of ISBN.");
                }

                this.isbn = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            private set
            {
                if (!this.IsValidString(value))
                {
                    throw new ArgumentException($"{nameof(value)} is empty or null.");
                }

                this.author = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (!this.IsValidString(value))
                {
                    throw new ArgumentException($"{nameof(value)} is empty or null.");
                }

                this.title = value;
            }
        }

        public string Publisher
        {
            get
            {
                return this.publisher;
            }

            private set
            {
                if (!this.IsValidString(value))
                {
                    throw new ArgumentException($"{nameof(value)} is empty or null.");
                }

                this.publisher = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            private set
            {
                if (!this.IsValidYear(value))
                {
                    throw new ArgumentException($"{nameof(value)} is incorrect.");
                }

                this.year = value;
            }
        }

        public int Pages
        {
            get
            {
                return this.pages;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} is incorrect. Number of pages can't be less then 0.");
                }

                this.pages = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (Math.Round(value, 2) <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} is incorrect. Price can't be less then 0.");
                }

                this.price = value;
            }
        }

        #endregion

        #region Interfaces

        public int CompareTo(object obj)
        {
            Book book = obj as Book;

            if (ReferenceEquals(book, null))
            {
                throw new ArgumentException($"{nameof(obj)} is not a Book.");
            }

            return string.Compare(book.Title, this.Title, StringComparison.Ordinal);
        }

        public bool Equals(Book book)
        {
            if (ReferenceEquals(null, book))
            {
                return false;
            }

            if (ReferenceEquals(this, book))
            {
                return true;
            }

            return book.Isbn.Equals(this.Isbn) && book.Author.Equals(this.Author) && book.Title.Equals(this.Title)
                   && book.Publisher.Equals(this.Publisher) && book.Year.Equals(this.Year) && book.Pages.Equals(this.Pages)
                   && book.Price.Equals(this.Price);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;
            if (format.Length > 7) throw new ArgumentException();

            format = format.ToUpper();

            if(!Regex.IsMatch(format, "(G|^I?A?T?P?Y?N?C?$)"))
                throw new ArgumentException("Wrong format.");

            string result = "";

            for (int i = 0; i < format.Length; i++)
            {
                switch (format[i])
                {
                    case 'G':
                        return ToString();
                    case 'I':
                        result += String.Format($"ISBN 13: {isbn.ToString(provider)}");
                        break;
                    case 'A':
                        result += author.ToString(provider);
                        break;
                    case 'T':
                        result += title.ToString(provider);
                        break;
                    case 'P':
                        result += String.Format($"\"{publisher.ToString(provider)}\"");
                        break;
                    case 'Y':
                        result += year.ToString(provider);
                        break;
                    case 'N':
                        result += String.Format($"P. {pages.ToString(provider)}");
                        break;
                    case 'C':
                        result += String.Format($"{price:C}", provider);
                        break;
                    default:
                        throw new ArgumentException("Invalid format.");
                }
                if (i != format.Length - 1)
                {
                    result += ", ";
                }
            }
            return result;
        }

        #endregion

        #region ObjectMethods

        public override string ToString()
        {
            return $"ISBN 13: {isbn}, {author}, {title}, \"{publisher}\", {year}, P. {pages}, {price:C}";
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            Book book = obj as Book;
            if (book == null)
            {
                return false;
            }

            return this.GetHashCode().Equals(book.GetHashCode());
        }

        #endregion

        #region Checkers

        private bool IsValidIsbn(string isbn) // isbn code contains 13 digits and 4 seperators '-'. 13 + 4 == 17
        {
            return isbn.Length == 17 && Regex.IsMatch(isbn, @"978-\d{1,5}-\d{1,7}-\d{1,6}-\d");
        }

        private bool IsValidYear(int year)
        {
            return year > 1900 && year <= DateTime.Now.Year;
        }

        private bool IsValidString(string str)
        {
            return !ReferenceEquals(null, str) && str.Length != 0;
        }

        #endregion
    }
}
