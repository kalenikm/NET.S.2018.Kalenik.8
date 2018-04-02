using System;
using System.Collections.Generic;
using System.Globalization;

namespace BookService
{
    public static class BookListSearcher
    {

        /// <summary>
        /// Checks same <paramref name="book"/> in list <paramref name="books"/>
        /// </summary>
        /// <param name="books">List of books.</param>
        /// <param name="book">Book to find.</param>
        /// <returns></returns>
        public static bool CheckBook(this List<Book> books, Book book)
        {
            foreach (Book b in books)
            {
                if (b.Equals(book))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Finds book in list of books by tag.
        /// </summary>
        /// <param name="books">List of books.</param>
        /// <param name="tag">Tag to find by.</param>
        /// <param name="find">Value of tag.</param>
        /// <returns>Returns found book.</returns>
        public static Book Find(this List<Book> books, BookTags tag, string find)
        {
            switch (tag)
            {
                case BookTags.Title:
                    return books.FindByTitle(find);
                case BookTags.Author:
                    return books.FindByAuthor(find);
                case BookTags.Year:
                    return books.FindByYear(find);
                case BookTags.Publisher:
                    return books.FindByPublisher(find);
                case BookTags.Pages:
                    return  books.FindByPages(find);
                case BookTags.Price:
                    return books.FindByPrice(find);
                default:
                    throw new ArgumentException();
            }
        }

        private static Book FindByTitle(this List<Book> books, string find)
        {
            foreach (var book in books)
            {
                if (book.Title.Equals(find, StringComparison.InvariantCultureIgnoreCase))
                    return book;
            }
            return null;
        }

        private static Book FindByAuthor(this List<Book> books, string find)
        {
            foreach (var book in books)
            {
                if (book.Author.Equals(find, StringComparison.InvariantCultureIgnoreCase))
                    return book;
            }
            return null;
        }

        private static Book FindByYear(this List<Book> books, string find)
        {
            foreach (var book in books)
            {
                if (book.Year.ToString().Equals(find, StringComparison.InvariantCultureIgnoreCase))
                    return book;
            }
            return null;
        }

        private static Book FindByPublisher(this List<Book> books, string find)
        {
            foreach (var book in books)
            {
                if (book.Publisher.Equals(find, StringComparison.InvariantCultureIgnoreCase))
                    return book;
            }
            return null;
        }

        private static Book FindByPages(this List<Book> books, string find)
        {
            foreach (var book in books)
            {
                if (book.Pages.ToString().Equals(find, StringComparison.InvariantCultureIgnoreCase))
                    return book;
            }
            return null;
        }

        private static Book FindByPrice(this List<Book> books, string find)
        {
            foreach (var book in books)
            {
                if (book.Price.ToString(CultureInfo.InvariantCulture).Equals(find, StringComparison.InvariantCultureIgnoreCase))
                    return book;
            }
            return null;
        }
    }
}