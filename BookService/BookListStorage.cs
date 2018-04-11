using System;
using System.Collections.Generic;
using System.IO;
using BookService.BookAdapters;
using BookService.Interfaces;

namespace BookService
{
    public class BookListStorage : IBookListStorage
    {
        private readonly string _filename;

        /// <summary>
        /// Creates new storage.
        /// </summary>
        /// <param name="filename">File for storage.</param>
        public BookListStorage(string filename)
        {
            _filename = filename;
        }

        /// <summary>
        /// Saves <paramref name="books"/> to file.
        /// </summary>
        /// <param name="books">Collection of books to save.</param>
        public void Save(IEnumerable<Book> books)
        {
            if(books == null)
                throw new ArgumentNullException($"{nameof(books)} is null.");

            using (var bw = new BookWriter(new FileStream(_filename, FileMode.Create)))
            {
                foreach (var book in books)
                {
                    bw.Write(book);
                }
            }
        }

        /// <summary>
        /// Loads books from file.
        /// </summary>
        /// <returns>Returns collection of books.</returns>
        public List<Book> Load()
        {
            List<Book> books = new List<Book>();

            using (var bw = new BookReader(new FileStream(_filename, FileMode.OpenOrCreate)))
            {
                while (!bw.IsEnd())
                {
                    Book book = bw.Read();
                    books.Add(book);
                }
            }

            return books;
        }
    }
}