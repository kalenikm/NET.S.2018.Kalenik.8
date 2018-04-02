using System;
using System.Collections.Generic;

namespace BookService
{
    public class BookListService
    {
        private readonly List<Book> _books;

        /// <summary>
        /// Count of books.
        /// </summary>
        public int Count => _books.Count;

        /// <summary>
        /// Creates new BookListService.
        /// </summary>
        public BookListService()
        {
            _books = new List<Book>();
        }

        /// <summary>
        /// Loads books from storage to inner collection.
        /// </summary>
        /// <param name="storage">Storage to load from.</param>
        public void LoadBooks(IBookListStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException($"{nameof(storage)} is null.");

            _books.AddRange(storage.Load());
        }

        /// <summary>
        /// Saves books in storage from inner collection.
        /// </summary>
        /// <param name="storage"></param>
        public void SaveBooks(IBookListStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException($"{nameof(storage)} is null.");

            storage.Save(_books);
        }

        /// <summary>
        /// Adds book to sevice.
        /// </summary>
        /// <param name="book">Book to add.</param>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException($"{nameof(book)} is null.");

            if (_books.CheckBook(book))
                throw new ArgumentException($"This book {nameof(book)} is already exist.");

            _books.Add(book);
        }

        /// <summary>
        /// Removes book from service.
        /// </summary>
        /// <param name="book">Book to remove.</param>
        public void RemoveBook(Book book)
        {
            if(book == null)
                throw new ArgumentNullException($"{nameof(book)} is null.");

            if (_books.CheckBook(book))
                throw new ArgumentException($"This book {nameof(book)} is not found.");

            _books.Remove(book);
        }

        /// <summary>
        /// Finds book by tag in inner collection.
        /// </summary>
        /// <param name="tag">Tag to find by.</param>
        /// <param name="find">Value to find.</param>
        /// <returns>Found book or null.</returns>
        public Book FindBookByTag(BookTags tag, object find)
        {
            return _books.Find(tag, find.ToString());
        }

        /// <summary>
        /// Sorts inner collection of books by tag.
        /// </summary>
        /// <param name="tag">Tag to sort by.</param>
        public void SortBooksByTag(BookTags tag)
        {
            _books.Sort(tag);
        }

        /// <summary>
        /// Returns array of books from inner collection.
        /// </summary>
        /// <returns>Array of book.</returns>
        public Book[] GetBooks()
        {
            Book[] books = new Book[Count];
            _books.CopyTo(books);
            return books;
        }
    }
}