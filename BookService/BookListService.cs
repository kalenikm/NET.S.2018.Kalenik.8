using System;
using System.Collections.Generic;
using BookService.Interfaces;
using NLog;

namespace BookService
{
    public class BookListService
    {
        private readonly List<Book> _books;
        private ILogger _logger;

        /// <summary>
        /// Count of books.
        /// </summary>
        public int Count => _books.Count;

        /// <summary>
        /// Creates new BookListService.
        /// </summary>
        public BookListService()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _books = new List<Book>();
        }

        /// <summary>
        /// Creates new BookListService.
        /// </summary>
        public BookListService(ILogger logger)
        {
            this._logger = logger;
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
            _logger.Trace("Method SaveBook start.");

            if (storage == null)
            {
                _logger.Info("ArgumentNullException");
                throw new ArgumentNullException($"{nameof(storage)} is null.");
            }
                

            storage.Save(_books);

            _logger.Trace("Method SaveBook end.");
        }

        /// <summary>
        /// Adds book to sevice.
        /// </summary>
        /// <param name="book">Book to add.</param>
        public void AddBook(Book book)
        {
            _logger.Trace("Method AddBook start.");

            if (book == null)
            {
                _logger.Info("ArgumentNullException");
                throw new ArgumentNullException($"{nameof(book)} is null.");
            }


            if (_books.CheckBook(book))
            {
                _logger.Info("ArgumentException");
                throw new ArgumentException($"This book {nameof(book)} is already exist.");
            }
                

            _books.Add(book);

            _logger.Trace("Method AddBook end.");
        }

        /// <summary>
        /// Removes book from service.
        /// </summary>
        /// <param name="book">Book to remove.</param>
        public void RemoveBook(Book book)
        {
            _logger.Trace("Method RemoveBook start.");

            if (book == null)
            {
                _logger.Info("ArgumentNullException");
                throw new ArgumentNullException($"{nameof(book)} is null.");
            }

            if (!_books.CheckBook(book))
            {
                _logger.Info("ArgumentException");
                throw new ArgumentException($"This book is not found.");
            }
                

            _books.Remove(book);

            _logger.Trace("Method RemoveBook end.");
        }

        /// <summary>
        /// Finds book by tag in inner collection.
        /// </summary>
        /// <param name="tag">Tag to find by.</param>
        /// <param name="find">Value to find.</param>
        /// <returns>Found book or null.</returns>
        public Book FindBookByTag(BookTags tag, object find)
        {
            _logger.Trace("Method FindBookByTag start.");

            _logger.Trace("Method FindBookByTag end.");

            return _books.Find(tag, find.ToString());
        }

        /// <summary>
        /// Sorts inner collection of books by tag.
        /// </summary>
        /// <param name="tag">Tag to sort by.</param>
        public void SortBooksByTag(BookTags tag)
        {
            _logger.Trace("Method SortBooksByTag start.");

            _logger.Trace("Method SortBooksByTag end.");

            _books.Sort(tag);
        }

        /// <summary>
        /// Returns array of books from inner collection.
        /// </summary>
        /// <returns>Array of book.</returns>
        public Book[] GetBooks()
        {
            _logger.Trace("Method GetBooks start.");

            Book[] books = new Book[Count];
            _books.CopyTo(books);

            _logger.Trace("Method GetBooks end.");

            return books;
        }
    }
}