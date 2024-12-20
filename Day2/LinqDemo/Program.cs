using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        ConsoleHelpers.Separator("Query Expression - Preparation Vs Execution");
        QueryPreparationVsExecution();

        ConsoleHelpers.Separator("PracticeExample1");
        PracticeExample1();

        ConsoleHelpers.Separator("PracticeExample2");
        PracticeExample2();
    }

    private static void QueryPreparationVsExecution()
    {
        // 1. Instantiate List
        List<int> someIntegerList = new();
        ConsoleHelpers.Separator("Source Integers During Instantiation", false);
        ConsoleHelpers.printEnumerable(someIntegerList, false);
        // 2. prepare a Linq Query with Query Expression
        IEnumerable<int> evenIntegersQuery =
            from intVal in someIntegerList
            where intVal % 2 == 0
            select intVal;
        ConsoleHelpers.Separator($"evenIntegersQuery", false);
        Console.WriteLine(evenIntegersQuery);
        ConsoleHelpers.Separator("Queried Even Integers", false);
        ConsoleHelpers.printEnumerable(evenIntegersQuery, false);
        // 3. prepare sample data
        someIntegerList.AddRange([1, 23, 45, 26, 78, 99, 256]);
        ConsoleHelpers.Separator("Source Integers after adding a range of values", false);
        ConsoleHelpers.printEnumerable(someIntegerList, false);
        ConsoleHelpers.Separator(
            "Queried Even Integers with same query expression `evenIntegersQuery`",
            false
        );
        ConsoleHelpers.printEnumerable(evenIntegersQuery, false);
    }

    private static void PracticeExample1()
    {
        // 1. Instantiate List
        List<Book> books = Book.PrepareSampleBooks();
        List<Book> allBooks = (from book in books select book).ToList();
        List<Book> allBooks1 = books.Where(_ => true).ToList();

        List<Book> booksFromAuthorA1 = (
            from book in books
            where book.Author == "A1"
            select book
        ).ToList();
        ConsoleHelpers.Separator("Books Fromm Author A1", false);
        ConsoleHelpers.printEnumerable(booksFromAuthorA1);

        List<Book> booksFromAuthorA1OrderedbyPrice = (
            from book in books
            where book.Author == "A1"
            orderby book.Price
            select book
        ).ToList();
        ConsoleHelpers.Separator("Books from Author A1 Ordered by Price", false);
        ConsoleHelpers.printEnumerable(booksFromAuthorA1OrderedbyPrice);

        List<Book> booksFromAuthorA1_OrderedbyPriceDescendingOrder = (
            from book in books
            where book.Author == "A1"
            orderby book.Price descending
            select book
        ).ToList();
        ConsoleHelpers.Separator("Books from Author A1 Ordered by Price Descending", false);
        ConsoleHelpers.printEnumerable(booksFromAuthorA1_OrderedbyPriceDescendingOrder);

        List<IGrouping<string, Book>> groupedByAuthor = (
            from book in books
            group book by $"Author: {book.Author}" into bookGroup
            select bookGroup
        ).ToList();
        ConsoleHelpers.Separator("Books grouped by author ", false);
        ConsoleHelpers.printGroup(groupedByAuthor);
    }

    private static void PracticeExample2()
    {
        (List<Book> books1, List<Book> books2, List<string> authors, List<string> publishers) =
            Book.PrepareSampleBooks2();

        IEnumerable<Book> booksUniqueToBook1 = books1.Except(books2);
        ConsoleHelpers.Separator("Books unique to books1 ", false);
        ConsoleHelpers.printEnumerable(booksUniqueToBook1.ToList());

        IEnumerable<Book> booksUniqueToBook2 = books2.Except(books1);
        ConsoleHelpers.Separator("Books unique to books2 ", false);
        ConsoleHelpers.printEnumerable(booksUniqueToBook2.ToList());

        IEnumerable<Book> booksInBoth = books1.Intersect(books2);
        ConsoleHelpers.Separator("Books in both books1 and books2", false);
        ConsoleHelpers.printEnumerable(booksInBoth.ToList());
    }
}
