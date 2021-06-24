using System;
using System.Collections.Generic;

namespace GradeBook
{
  // Defining a delegation event
  public delegate void GradeAddedDelegate(object sender, EventArgs args);

  public class Book
  {
    public Book(string name) 
    {
      grades = new List<double>();
      this.Name = name;
    }

    private bool IsGradeValid(double grade)
    {
      return grade >= 0 && grade <= 100;
    }

    public void AddGrade(double grade)
    {
      if (IsGradeValid(grade))
      {
        this.grades.Add(grade);
        // OR -> grades.Add(grade);
        if(GradeAdded != null) GradeAdded(this, new EventArgs());
      }
      else throw new ArgumentException($"Cannot add {grade} - Invalid value.");
    }

    public void AddGrade(char letter)
    {
      switch(letter)
      {
        case 'A':
          AddGrade(90);
          break;
        
        case 'B':
          AddGrade(80);
          break;

        case 'C':
          AddGrade(70);
          break;
        
        case 'D':
          AddGrade(60);
          break;
        
        default:
          AddGrade(0);
          break;
      }
    }

    public Statistics GetStatistics()
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      foreach(var grade in grades)
      {
        if (IsGradeValid(grade) && grades.Count > 0)
        {
          result.Low = Math.Min(grade, result.Low);
          result.High = Math.Max(grade, result.High);
          result.Average += grade;
        }
        else throw new FormatException("Grades list either is empty or has invalid data.");
      }
      result.Average /= grades.Count;

      switch(result.Average)
      {
        case var avrg when avrg >= 90.0:
          result.Letter = 'A';
          break;
        
        case var avrg when avrg >= 80.0:
          result.Letter = 'B';
          break;

        case var avrg when avrg >= 70.0:
          result.Letter = 'C';
          break;

        case var avrg when avrg >= 60.0:
          result.Letter = 'D';
          break;
        
        default:
          result.Letter = 'F';
          break;
      }

      return result;
    }

    // Instantiating and making the event public
    public event GradeAddedDelegate GradeAdded;
    private List<double> grades;
    public string Name { get; set; }
  }
}