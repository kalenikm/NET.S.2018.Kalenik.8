using System;
using System.IO;

namespace BookService
{
    public class BookReader : IDisposable
    {
        private readonly Stream _stream;

        public BookReader(Stream stream)
        {
            _stream = stream;
        }

        public Book Read()
        {
            Book book = null;
            var br = new BinaryReader(_stream);

            if (br.PeekChar() != -1)
                book = new Book(br.ReadString(), br.ReadString(), br.ReadString(), br.ReadString(), br.ReadInt32(),
                    br.ReadInt32(), br.ReadDecimal());

            return book;
        }

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