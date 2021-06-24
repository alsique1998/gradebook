using Xunit;

namespace GradeBook.Tests
{
  public class BookTests
  {
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
      // arrange
      var book = new Book("");
      book.AddGrade(54.8);
      book.AddGrade(56.2);
      book.AddGrade(22.5);
      
      // act
      var result = book.GetStatistics();

      // assert
      Assert.Equal(22.5, result.Low, 1);
      Assert.Equal(56.2, result.High, 1);
      Assert.Equal(44.5, result.Average, 1);
      Assert.Equal('F', result.Letter);
    }
  }
}
