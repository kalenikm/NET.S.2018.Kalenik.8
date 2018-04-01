using System;
using System.Collections.Generic;
using System.Globalization;

namespace BookService
{
    public static class BookListSearcher
    {
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

        public static Book FindByTitle(this List<Book> books, string find)
        {
            foreach (var book in books)
            {
                if (book.Title.Equals(find, StringComparison.InvariantCultureIgnoreCase))
                    return book;
            }
            return null;
        }

        public static Book FindByAuthor(this List<Book> books, string find)
        {
            foreach (var book in books)
            {
                if (book.Author.Equals(find, StringComparison.InvariantCultureIgnoreCase))
                    return book;
            }
            return null;
        }

        public static Book FindByYear(this List<Book> books, string find)
        {
            foreach (var book in books)
            {
                if (book.Year.ToString().Equals(find, StringComparison.InvariantCultureIgnoreCase))
                    return book;
            }
            return null;
        }

        public static Book FindByPublisher(this List<Book> books, string find)
        {
            foreach (var book in books)
            {
                if (book.Publisher.Equals(find, StringComparison.InvariantCultureIgnoreCase))
                    return book;
            }
            return null;
        }

        public static Book FindByPages(this List<Book> books, string find)
        {
            foreach (var book in books)
            {
                if (book.Pages.ToString().Equals(find, StringComparison.InvariantCultureIgnoreCase))
                    return book;
            }
            return null;
        }

        public static Book FindByPrice(this List<Book> books, string find)
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