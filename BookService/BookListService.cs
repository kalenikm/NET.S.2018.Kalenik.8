using System;
using System.Collections.Generic;

namespace BookService
{
    public class BookListService
    {
        private readonly List<Book> _books;

        public int Count => _books.Count;

        public BookListService()
        {
            _books = new List<Book>();
        }

        public void LoadBooks(IBookListStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException($"{nameof(storage)} is null.");

            _books.AddRange(storage.Load());
        }

        public void SaveBooks(IBookListStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException($"{nameof(storage)} is null.");

            storage.Save(_books);
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException($"{nameof(book)} is null.");

            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if(book == null)
                throw new ArgumentNullException($"{nameof(book)} is null.");

            _books.Remove(book);
        }

        //public Book FindBookByTag()
        //{

        //}

        //public void SortBooksByTag()
        //{
            
        //}

        public Book[] GetBooks()
        {
            Book[] books = new Book[Count];
            _books.CopyTo(books);
            return books;
        }
    }
}