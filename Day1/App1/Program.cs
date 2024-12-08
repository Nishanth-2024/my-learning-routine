using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Arbitary Class containing the Entry Point for the Program
/// </summary>
class Program
{

  /// <summary>
  /// Delegate that represents the Callback Function passed to `MultiplicationTableWithCallback` method
  /// Delegate is a Reference Type - During Runtime, Delegate is converted into a Class
  /// </summary>
  /// <param name="number">Number on which Multiplication is performed</param>
  /// <param name="row">number representing row of the multiplication table</param>
  /// <param name="result">Result of multiplication between Number and row</param>
  delegate void MulCallback(int number, int row, int result);

  /// <summary>
  /// Entry point for the Console Application
  /// </summary>
  /// <param name="args">Arguments for the program</param>
  static void Main(string[] args)
  {
    int number = 5, rows = 10;
    Spacer();
    Console.WriteLine($"Multiplication Table on {number} for {rows} rows");
    Spacer();
    CallBackDemo1(number, rows);
    Spacer();
    CallBackDemo2(number, rows);
    Spacer();
    YieldDemo1(number, rows);
    Spacer();
    YieldDemo2(number, rows);
  }

  private static void Spacer()
  {
    // Console.WriteLine("----------------------------------------------------------------------");
    Console.WriteLine(string.Concat(Enumerable.Repeat("-", 72)));
  }

  #region Demo - Callback
  private static void CallBackDemo1(int number, int rows)
  {
    Console.WriteLine("Callback that prints the result");
    MulCallback clbk1 = (int num, int row, int result) => Console.WriteLine($"\t{row} times {num} equals to {result}");
    MultiplicationTableWithCallback(number, rows, clbk1);
  }
  private static void CallBackDemo2(int number, int rows)
  {
    Console.WriteLine("Callback that modifies/updates something on caller's scope");
    int[] mularray = new int[rows];
    MulCallback clbk2 = (int num, int row, int result) => mularray[row-1] = result;
    MultiplicationTableWithCallback(number, rows, clbk2);
    for (int i = 0; i < rows; i++)
    {
      Console.WriteLine($"\t{i} times {number} equals to {mularray[i]}");
    }
  }

  /// <summary>
  /// This method performs muliplication on `number` for `rows` and pass result back to callback
  /// </summary>
  /// <param name="number">Number on which Multiplication is performed</param>
  /// <param name="rows">number of rows in the multiplication table</param>
  /// <param name="callback">Callback Function executed on the number and row</param>
  private static void MultiplicationTableWithCallback(int number, int rows, MulCallback callback)
  {
    for (int i = 1; i <= rows; ++i)
    {
      var result = number * i;
      callback(number, i, result);
    }
  }
  #endregion

  #region Demo - Yield / Generator Functions
  private static void YieldDemo1(int number, int rows)
  {
    Console.WriteLine("Yield Result for Multiplication Operation into an IEnumerable<int>");
    var res = MultiplicationTableWithYieldResult(number, rows);
    for (int i = 0; i < rows; i++)
    {
      Console.WriteLine($"\t{i} times {number} equals to {res.ElementAt(i)}");
    }
  }
  private static void YieldDemo2(int number, int rows)
  {
    Console.WriteLine("Yield Result for Multiplication Operation into an IEnumerable of tuple");
    var resArr = MultiplicationTableWithYieldTuple(number, rows);
    foreach (var item in resArr)
    {
      Console.WriteLine($"\t{item.Item2} times {item.Item1} equals to {item.Item3}");
    }
  }

  /// <summary>
  /// This method performs muliplication on `number` for `rows` and yields results for each row as it is calculated
  /// </summary>
  /// <param name="number">Number on which Multiplication is performed</param>
  /// <param name="rows">number of rows in the multiplication table</param>
  /// <returns>result</returns>
  private static IEnumerable<int> MultiplicationTableWithYieldResult(int number, int rows)
  {
    // Console.WriteLine($"Multiplication Table on {number} for {rows} rows");
    for (int i = 0; i < rows; ++i)
    {
      yield return number * i;
    }
  }

  /// <summary>
  /// This method performs muliplication on `number` for `rows` and yields number, row and result for each row as it is calculated
  /// </summary>
  /// <param name="number">Number on which Multiplication is performed</param>
  /// <param name="rows">number of rows in the multiplication table</param>
  /// <returns>(int number, int row, int result)</returns>
  private static IEnumerable<(int, int, int)> MultiplicationTableWithYieldTuple(int number, int rows)
  {
    // Console.WriteLine($"Multiplication Table on {number} for {rows} rows");
    for (int i = 0; i < rows; ++i)
    {
      yield return (number, i, number * i);
    }
  }
  #endregion
}
