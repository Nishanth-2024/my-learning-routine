using System;
using System.Collections.Generic;

interface ConsolePrintable
{
  void printToConsole();
}

partial class Book: ConsolePrintable
{

  private ConsoleColor originalColor;
  private ConsoleColor originalBgColor;
  private ConsoleColor newBGColor;
  private ConsoleColor newFGColor;
  private void setNewConsoleColor ()
  {
      Console.ForegroundColor = newFGColor;
      Console.BackgroundColor = newBGColor;
  }
  private void resetConsoleColors ()
  {
      Console.ForegroundColor = originalColor;
      Console.BackgroundColor = originalBgColor;
  }
  public Book()
  {
    originalColor = Console.ForegroundColor;
    originalBgColor = Console.BackgroundColor;
    // newBGColor = ConsoleColor.Black;
    newBGColor = originalBgColor;
    newFGColor = ConsoleColor.DarkCyan;
  }
  internal string Title { get; set; } = string.Empty;
  internal string Author { get; set; } = string.Empty;
  internal string Publisher { get; set; } = string.Empty;
  internal int Price { get; set; } = 0;

  public override string ToString()
  {
    string separator = ",\t";
    return $"Title: {Title}{separator}Author: {Author}{separator}Publisher: {Publisher}{separator}Price: {Price}";
  }

  public void printToConsole()
  {
    Console.WriteLine();
    setNewConsoleColor(); Console.Write("Title: ");
    resetConsoleColors(); Console.Write(Title + "\t");

    setNewConsoleColor(); Console.Write("Author: ");
    resetConsoleColors(); Console.Write(Author + "\t");

    setNewConsoleColor(); Console.Write("Publisher: ");
    resetConsoleColors(); Console.Write(Publisher + "\t");

    setNewConsoleColor(); Console.Write("Price: ");
    resetConsoleColors(); Console.Write(Price + "\t");
  }

  public static List<Book> PrepareSampleBooks()
  {
    return new List<Book>() {
        new Book { Title = "T1", Author = "A1", Price = 1200, Publisher = "P3" },
        new Book { Title = "T2", Author = "A2", Price = 1700, Publisher = "P4" },
        new Book { Title = "T3", Author = "A1", Price = 3400, Publisher = "P2" },
        new Book { Title = "T4", Author = "A2", Price = 5200, Publisher = "P3" },
        new Book { Title = "T5", Author = "A1", Price = 2900, Publisher = "P3" },
        new Book { Title = "T6", Author = "A2", Price = 7800, Publisher = "P3" },
        new Book { Title = "T7", Author = "A3", Price = 1500, Publisher = "P1" },
      };
  }

  public static (List<Book>, List<Book>, List<string>, List<string>) PrepareSampleBooks2()
  {

    var commonBooks = new List<Book>() {
      new Book { Title = "T1-1", Author = "A1", Price = 1900, Publisher = "P1" },
      new Book { Title = "T1-2", Author = "A1", Price = 1300, Publisher = "P1" },
      new Book { Title = "T2-1", Author = "A2", Price = 2800, Publisher = "P2" },
      new Book { Title = "T2-2", Author = "A2", Price = 2700, Publisher = "P2" },
      new Book { Title = "T3-1", Author = "A3", Price = 4000, Publisher = "P1" },
      new Book { Title = "T3-2", Author = "A3", Price = 3880, Publisher = "P2" },
      new Book { Title = "T4-1", Author = "A4", Price = 4420, Publisher = "P3" },
      new Book { Title = "T4-2", Author = "A4", Price = 4840, Publisher = "P3" },
    };
    List<Book> books1 = [
      // Both B1 and B2
      .. commonBooks,
      // Only B1
      new Book { Title = "T5-1", Author = "A5", Price = 5800, Publisher = "P1" },
      new Book { Title = "T5-2", Author = "A5", Price = 5330, Publisher = "P2" },
      new Book { Title = "T6-1", Author = "A6", Price = 6190, Publisher = "P3" },
      new Book { Title = "T6-2", Author = "A6", Price = 3307, Publisher = "P4" },
      new Book { Title = "T7-1", Author = "A7", Price = 6480, Publisher = "P5" },
      new Book { Title = "T7-2", Author = "A7", Price = 6110, Publisher = "P6" },
      // Only B1 along with Author
      new Book { Title = "B1-T1", Author = "B1-A1", Price = 5880, Publisher = "P1" },
      new Book { Title = "B1-T2", Author = "B1-A1", Price = 5100, Publisher = "P2" },
      new Book { Title = "B1-T3", Author = "B1-A2", Price = 6100, Publisher = "P3" },
      new Book { Title = "B1-T4", Author = "B1-A2", Price = 6100, Publisher = "P4" },
      new Book { Title = "B1-T5", Author = "B1-A3", Price = 6100, Publisher = "P5" },
      new Book { Title = "B1-T6", Author = "B1-A3", Price = 6100, Publisher = "P6" },
    ];

    List<Book> books2 = [
      // Both B1 and B2
      .. commonBooks,
      // Only B2
      new Book { Title = "T5-3", Author = "A5", Price = 5100, Publisher = "P1" },
      new Book { Title = "T5-4", Author = "A5", Price = 5200, Publisher = "P2" },
      new Book { Title = "T6-3", Author = "A6", Price = 6100, Publisher = "P3" },
      new Book { Title = "T6-4", Author = "A6", Price = 5900, Publisher = "P4" },
      new Book { Title = "T7-3", Author = "A7", Price = 6200, Publisher = "P5" },
      new Book { Title = "T7-4", Author = "A7", Price = 6100, Publisher = "P6" },
      // Only B2 along with Author
      new Book { Title = "B2-T1", Author = "B2-A1", Price = 5100, Publisher = "P1" },
      new Book { Title = "B2-T2", Author = "B2-A1", Price = 5200, Publisher = "P2" },
      new Book { Title = "B2-T3", Author = "B2-A2", Price = 6100, Publisher = "P3" },
      new Book { Title = "B2-T4", Author = "B2-A2", Price = 5900, Publisher = "P4" },
      new Book { Title = "B2-T5", Author = "B2-A3", Price = 6200, Publisher = "P5" },
      new Book { Title = "B2-T6", Author = "B2-A3", Price = 6100, Publisher = "P6" },
    ];

    var authors = new List<string> {
      "A1", "A2", "A3", "A4", "A5", "A6", "A7",
      "B1-A1", "B1-A2", "B1-A3",
      "B2-A1", "B2-A2", "B2-A3"
    };

    var publishers = new List<string> { "P1", "P2", "P3", "P4", "P5", "P6" };

    return (books1, books2, authors, publishers);
  }
}