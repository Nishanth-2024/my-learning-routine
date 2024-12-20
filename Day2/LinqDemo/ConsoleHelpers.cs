using System;
using System.Collections.Generic;
using System.Linq;

static class ConsoleHelpers
{
    private static string spacer = new string(' ', 4);
    public static void Separator(string? title = null, bool isMainTitle = true)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine();
            return;
        }

        ConsoleColor originalColor = Console.ForegroundColor;
        ConsoleColor originalBgColor = Console.BackgroundColor;

        var newBGColor = isMainTitle ? ConsoleColor.DarkCyan : ConsoleColor.Black;
        var newFGColor = isMainTitle ? ConsoleColor.Black : ConsoleColor.DarkCyan;

        var setNewColor = () =>
        {
            Console.ForegroundColor = newFGColor;
            Console.BackgroundColor = newBGColor;
        };
        var setOriginalColor = () =>
        {
            Console.ForegroundColor = originalColor;
            Console.BackgroundColor = originalBgColor;
        };

        /*var newBGColor = ConsoleColor.Yellow;*/

        if (isMainTitle)
        {
            string separatorString = new string('*', title.Count() + 8);

            setOriginalColor(); Console.WriteLine();
            setNewColor(); Console.Write(separatorString);
            setOriginalColor(); Console.WriteLine();
            setNewColor(); Console.Write($"{spacer}{title}{spacer}"); setOriginalColor(); Console.WriteLine();
            setNewColor(); Console.Write(separatorString);
            setOriginalColor(); Console.WriteLine();
        }
        else
        {
            Console.WriteLine("\t");
            setNewColor();
            Console.Write(title);
            setOriginalColor();
            Console.WriteLine();
        }
    }

    public static void printEnumerable<T>(IEnumerable<T> collection, bool separateLine = true)
    {
        if (collection.Count() == 0)
        {
            Console.WriteLine("Empty List");
            return;
        }
        foreach (T? item in collection)
        {
            if (separateLine)
            {
                if (item is ConsolePrintable) {
                    (item as ConsolePrintable)?.printToConsole();
                } else {
                    Console.WriteLine($"{spacer}{item}");
                }
            } else {
                if (item == null)
                {
                    Console.Write($"{spacer}EMPTY ITEM");
                } else {
                    Console.Write($"{spacer}{item}");
                }
            }
        }
        Console.WriteLine();
    }

    public static void printGroup<T>(IEnumerable<IGrouping<string, T>> bookGroup)
    {
        foreach (IGrouping<string, T> group in bookGroup)
        {
            Console.WriteLine($"Group Key: {group.Key}");
            foreach (T? book in group)
            {
                Console.WriteLine($"\t - {book}");
            }
        }
    }
}