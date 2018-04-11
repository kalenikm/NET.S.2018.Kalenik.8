using System.Collections.Generic;

namespace BookService.Interfaces
{
    public interface IBookListStorage
    {
        void Save(IEnumerable<Book> books);
        List<Book> Load();
    }
}