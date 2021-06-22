using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("Abner's Grade Book");
      book.AddGrade(2.5);
      book.AddGrade(6.8);
      book.AddGrade(3.9);
      book.AddGrade(4.1);
      var stats = book.GetStatistics();
      System.Console.WriteLine($"The lowest grade is {stats.Low}");
      System.Console.WriteLine($"The highest grade is {stats.High}");
      System.Console.WriteLine($"The average grade is {stats.Average}");
    }
  }
}
