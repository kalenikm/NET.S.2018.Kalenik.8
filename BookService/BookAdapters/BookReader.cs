using System;
using System.IO;

namespace BookService.BookAdapters
{
    public class BookReader : IDisposable
    {
        private readonly Stream _stream;

        /// <summary>
        /// Creates new BookReader.
        /// </summary>
        /// <param name="stream">Stream to read from.</param>
        public BookReader(Stream stream)
        {
            _stream = stream;
        }

        /// <summary>
        /// Reads fields of book from stream.
        /// </summary>
        /// <returns>Returns book from stream.</returns>
        public Book Read()
        {
            Book book = null;
            var br = new BinaryReader(_stream);

            if (br.PeekChar() != -1)
                book = new Book(br.ReadString(), br.ReadString(), br.ReadString(), br.ReadString(), br.ReadInt32(),
                    br.ReadInt32(), br.ReadDecimal());

            return book;
        }

        /// <summary>
        /// Checks end of stream.
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            return !(_stream.Length > _stream.Position);
        }

        public void Dispose()
        {
            _stream.Close();
        }
    }
}