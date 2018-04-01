using System;
using System.IO;

namespace BookService
{
    public class BookWriter : IDisposable
    {
        private readonly Stream _stream;

        public BookWriter(Stream stream)
        {
            _stream = stream;
        }

        public void Write(Book book)
        {
            if (book == null)
                throw new ArgumentNullException($"{nameof(book)} is null.");

            var bw = new BinaryWriter(_stream);
            bw.Write(book.Isbn);
            bw.Write(book.Author);
            bw.Write(book.Title);
            bw.Write(book.Publisher);
            bw.Write(book.Year);
            bw.Write(book.Pages);
            bw.Write(book.Price);
        }

        public void Dispose()
        {
            _stream.Close();
        }
    }
}