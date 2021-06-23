using System;
using Xunit;

namespace GradeBook.Tests
{
  public class TypeTests
  {
    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
      var x = GetInt();
      SetInt(ref x);
      Assert.Equal(42, x);
    }

    [Fact]
    public void CanSetNameFromReference()
    {
      var book1 = GetBook("Book 1");
      var book2 = GetBook("Book 2");
      SetName(book1, "New book 1 name");

      Assert.Equal("New book 1 name", book1.Name);
    }

    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
      string name = "Abner";
      string changedName = MakeUpperCase(name);

      Assert.Equal("ABNER", changedName);
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
      var book1 = GetBook("Book 1");
      var book2 = GetBook("Book 2");

      Assert.Equal("Book 1", book1.Name);
      Assert.Equal("Book 2", book2.Name);
      Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVariablesCanReferenceSameObject()
    {
      var book1 = GetBook("Book 1");
      var book2 = book1;

      Assert.Same(book1, book2);
      Assert.True(Object.ReferenceEquals(book1, book2));
    }

    private Book GetBook(string name)
    {
      return new Book(name);
    }

    private void SetName(Book book, string name)
    {
      book.Name = name;
    }

    private int GetInt()
    {
      return 3;
    }

    private void SetInt(ref int x)
    {
      x = 42;
    }

    private string MakeUpperCase(string parameter)
    {
      return parameter.ToUpper();
    }
  }
}
