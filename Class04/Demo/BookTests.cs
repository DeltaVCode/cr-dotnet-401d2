using System;
using Xunit;

namespace Demo
{
    public class BookTests
    {
        [Fact]
        public void Can_create_a_Book()
        {
            Book book1 = new Book("C# in Depth");
            Book book2 = new Book("C# out of Depth");

            Assert.Equal("C# in Depth", book1.Title);
            Assert.Equal("C# out of Depth", book2.Title);

            Assert.Equal("C# in Depth", book1.GetTitle());

            book1.Publisher = "O'Reilly";
            Assert.Equal("O'Reilly", book1.Publisher);

            book1.Author = new Author("Ben", "Something");
            string formattedBook = book1.FormatBookTitleAndAuthor();
            Assert.Equal("C# in Depth by Ben Something", formattedBook);
        }

        [Fact]
        public void Cannot_assign_null_Author()
        {
            // Arrange
            Book book = new Book("Test");

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                book.Author = null;
            });

            try
            {
                // Act
                book.Author = null;

                throw new InvalidOperationException("Setting Author should have thrown!");
            }
            catch (ArgumentNullException)
            {
                // Assert: we got here!
            }

        }
    }
}
