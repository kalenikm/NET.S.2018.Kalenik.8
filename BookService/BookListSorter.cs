using System;
using System.Collections.Generic;

namespace BookService
{
    public enum BookTags
    {
        Title,
        Author,
        Year,
        Publisher,
        Pages,
        Price
    }
    public static class BookListSorter
    {
        /// <summary>
        /// Sorts list of books by tag.
        /// </summary>
        /// <param name="books">List of books to sort.</param>
        /// <param name="tag">Tag to sort by.</param>
        public static void Sort(this List<Book> books, BookTags tag)
        {
            switch (tag)
            {
                case BookTags.Title:
                    books.SortByTitle();
                    break;
                case BookTags.Author:
                    books.SortByAuthor();
                    break;
                case BookTags.Year:
                    books.SortByYear();
                    break;
                case BookTags.Publisher:
                    books.SortByPublisher();
                    break;
                case BookTags.Pages:
                    books.SortByPages();
                    break;
                case BookTags.Price:
                    books.SortByPrice();
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private static void Swap(List<Book> list, int a, int b)
        {
            var buff = list[a];
            list[a] = list[b];
            list[b] = buff;
        }

        private static void SortByTitle(this List<Book> books)
        {
            for (var i = 0; i < books.Count; i++)
            for (var j = 0; j < books.Count - i - 1; j++)
                if (string.Compare(books[j].Title, books[j + 1].Title, StringComparison.Ordinal) > 0)
                    Swap(books, j, j + 1);
        }

        private static void SortByAuthor(this List<Book> books)
        {
            for (var i = 0; i < books.Count; i++)
            for (var j = 0; j < books.Count - i - 1; j++)
                if (string.Compare(books[j].Author, books[j + 1].Author, StringComparison.Ordinal) > 0)
                    Swap(books, j, j + 1);
        }

        private static void SortByYear(this List<Book> books)
        {
            for (var i = 0; i < books.Count; i++)
            for (var j = 0; j < books.Count - i - 1; j++)
                if (books[j].Year > books[j + 1].Year)
                    Swap(books, j, j + 1);
        }

        private static void SortByPublisher(this List<Book> books)
        {
            for (var i = 0; i < books.Count; i++)
            for (var j = 0; j < books.Count - i - 1; j++)
                if (string.Compare(books[j].Publisher, books[j + 1].Publisher, StringComparison.Ordinal) > 0)
                    Swap(books, j, j + 1);
        }

        private static void SortByPages(this List<Book> books)
        {
            for (var i = 0; i < books.Count; i++)
            for (var j = 0; j < books.Count - i - 1; j++)
                if (books[j].Pages > books[j + 1].Pages)
                    Swap(books, j, j + 1);
        }

        private static void SortByPrice(this List<Book> books)
        {
            for (var i = 0; i < books.Count; i++)
            for (var j = 0; j < books.Count - i - 1; j++)
                if (books[j].Price > books[j + 1].Price)
                    Swap(books, j, j + 1);
        }
    }
}