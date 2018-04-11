using System;
using System.IO;

namespace BookService.BookAdapters
{
    public class BookWriter : IDisposable
    {
        private readonly Stream _stream;

        /// <summary>
        /// Creates new BookWriter.
        /// </summary>
        /// <param name="stream">Stream to write in.</param>
        public BookWriter(Stream stream)
        {
            _stream = stream;
        }

        /// <summary>
        /// Writes fields of book in stream.
        /// </summary>
        /// <param name="book">Book to write in.</param>
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