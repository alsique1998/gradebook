using System;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      System.Console.WriteLine("Let's compute some grades.");
      System.Console.WriteLine("Enter the book's name:");
      var bookName = System.Console.ReadLine();
      if (bookName.Length > 0)
      {
        var book = new Book(bookName);
        var done = false;

        // Subscribing to GradeAdded event and delegating it to OnGradeAdded
        book.GradeAdded += OnGradeAdded;
        
        while (!done)
        {
          System.Console.WriteLine("Enter a grade or 'q' to quit:");
          var userInput = System.Console.ReadLine();
          if (userInput != "q" && double.TryParse(userInput, out double result))
          {
            var grade = double.Parse(userInput);
            try
            {
              book.AddGrade(grade);
            }
            catch(ArgumentException ex)
            {
              System.Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
              System.Console.WriteLine(ex.Message);
            }
            finally
            {
              System.Console.WriteLine("---");
            }
          }
          else done = true;
        }
        var stats = book.GetStatistics();
        System.Console.WriteLine($"For the book named {book.Name}");
        System.Console.WriteLine($"The lowest grade is {stats.Low}");
        System.Console.WriteLine($"The highest grade is {stats.High}");
        System.Console.WriteLine($"The average grade is {stats.Average:N1}");
        System.Console.WriteLine($"The letter grade is {stats.Letter}");
      }
    }

    // Creating a child method to propagate a parent event
    static void OnGradeAdded(object sender, EventArgs e)
    {
      System.Console.WriteLine("A grade was added");
    }
  }
}
