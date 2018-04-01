using System;
using System.Collections.Generic;
using System.IO;

namespace BookService
{
    public interface IBookListStorage
    {
        void Save(IEnumerable<Book> books);
        List<Book> Load();
    }
    public class BookListStorage : IBookListStorage
    {
        private readonly string _filename;

        public BookListStorage(string filename)
        {
            _filename = filename;
        }

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