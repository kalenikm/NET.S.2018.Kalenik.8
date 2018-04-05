using System;
using NUnit.Framework;

namespace BookService.Tests
{
    [TestFixture]
    public class BookTests
    {
        private readonly Book book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826,
            59.99m);

        [TestCase("atp", ExpectedResult = "Jeffrey Richter, CLR via C#, \"Microsoft Press\"")]
        [TestCase("ipyc", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, \"Microsoft Press\", 2012, 59,99 р.")]
        [TestCase("atn", ExpectedResult = "Jeffrey Richter, CLR via C#, P. 826")]
        [TestCase("", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826, 59,99 р.")]
        public string Book_ToString_IFormattable(string format)
        {
            return book.ToString(format);
        }

        [TestCase("atap")]
        [TestCase("iipyc")]
        [TestCase("catn")]
        public void Book_ToString_Exception_WrongFormat(string format)
        {
            Assert.Catch<ArgumentException>(() => book.ToString(format));
        }
    }
}
