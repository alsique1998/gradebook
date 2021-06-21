using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Book
  {
    public Book(string name) 
    {
      grades = new List<double>();
      this.name = name;
    }


    public void AddGrade(double grade)
    {
      this.grades.Add(grade);
      // OR -> grades.Add(grade);
    }

    public void ShowStatistics()
    {
      var sum = 0.0;
      var lowGrade = double.MaxValue;
      var highGrade = double.MinValue;

      foreach(var grade in grades)
      {
        lowGrade = Math.Min(grade, lowGrade);
        highGrade = Math.Min(grade, highGrade);
        sum += grade;
      }
      var average = sum / grades.Count;
      System.Console.WriteLine($"The lowest grade is {lowGrade}");
      System.Console.WriteLine($"The highest grade is {highGrade}");
      System.Console.WriteLine($"The average grade is {average}");
    }

    private List<double> grades;
    private string name;
  }
}