using System;
using BankService;
using BookService;
using BookService.Format;
using NLog;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            BookListService service = new BookListService(LogManager.GetCurrentClassLogger());
            service.AddBook(new Book("978-5-9909805-1-8", "S. McConnell", "Code Complete", "BHV", 2017, 914, 9.50m));
            service.AddBook(new Book("978-5-496-01649-0", "C. Тепляков", "Паттерны проектирования на платформе .NET", "ПИТЕР", 2015, 320, 12.70m));
            service.AddBook(new Book("978-5-459-00435-9", "E. Freeman", "Head First Design Patterns", "O'Reilly Media", 2009, 688, 23.99m));
            service.SaveBooks(new BookListStorage("books.bin"));

            Console.WriteLine(service.GetBooks()[0].ToString("atn"));
            Console.WriteLine(service.GetBooks()[0].ToString("atn", new BookProvider()));

            BookListService service2 = new BookListService();
            Console.WriteLine(service2.Count);
            service2.LoadBooks(new BookListStorage("books.bin"));
            Console.WriteLine(service2.Count);
            foreach (var item in service2.GetBooks())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            service2.SortBooksByTag(BookTags.Title);
            foreach (var item in service2.GetBooks())
            {
                Console.WriteLine(item);
            }

            var book = service2.GetBooks()[2];
            service2.RemoveBook(book);
            Console.WriteLine();

            foreach (var item in service2.GetBooks())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine(service2.FindBookByTag(BookTags.Title, "Code Complete")?.ToString() ?? "Not found.");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Bank bank = new Bank();
            BankAccount baccount = new BankAccount("Mike", "Smit", "Base");
            bank.NewAccount(baccount);
            baccount = new BankAccount("Eric", "Freeman", "Platinum");
            bank.NewAccount(baccount);
            baccount = new BankAccount("Berta", "Jhons", "Gold");
            bank.NewAccount(baccount);

            BankStorage storage = new BankStorage("bank.bin");
            bank.SaveAccounts(storage);

            bank = new Bank();
            bank.LoadAccounts(storage);
            BankAccount account = bank.GetAccount(1);
            if (account != null)
            {
                Console.WriteLine(account);
                account.Refill(100);
                Console.WriteLine(account);
                account.Withdraw(20);
                Console.WriteLine(account);
            }
            account = bank.GetAccount(2);
            if (account != null)
            {
                Console.WriteLine(account);
                account.Refill(500);
                Console.WriteLine(account);
                account.Withdraw(300);
                Console.WriteLine(account);
            }

        }
    }
}
