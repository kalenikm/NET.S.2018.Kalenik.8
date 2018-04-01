using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookService;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService service = new BookListService();
            service.AddBook(new Book("978-5-9909805-1-8", "S. McConnell", "Code Complete", "BHV", 2017, 914, 9.50m));
            service.AddBook(new Book("978-5-496-01649-0", "C. Тепляков", "Паттерны проектирования на платформе .NET", "ПИТЕР", 2015, 320, 12.70m));
            service.AddBook(new Book("978-5-459-00435-9", "E. Freeman", "Head First Design Patterns", "O'Reilly Media", 2009, 688, 23.99m));
            service.SaveBooks(new BookListStorage("books.bin"));

            BookListService service2 = new BookListService();
            Console.WriteLine(service2.Count);
            service2.LoadBooks(new BookListStorage("books.bin"));
            Console.WriteLine(service2.Count);
            foreach (var item in service2.GetBooks())
            {
                Console.WriteLine(item);
            }
            var book = service2.GetBooks()[1];
            service2.RemoveBook(book);
            Console.WriteLine();
            foreach (var item in service2.GetBooks())
            {
                Console.WriteLine(item);
            }
        }
    }
}
