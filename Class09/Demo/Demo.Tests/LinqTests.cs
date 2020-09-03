using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.Tests
{
    public class LinqTests
    {
        [Fact]
        public void MapInLinqIsCalledSelect()
        {
            IEnumerable<Author> authors = new[]
            {
                new Author("Keith", "Dahlby"),
                new Author("Craig", "Barkley"),
                new SingleNameAuthor("Prince"),
            };

            // Act
            IEnumerable<string> names = authors.Select(author => author.FullName);

            // SQL : SELECT FirstName + ' ' + LastName AS Name From Authors
            IEnumerable<string> namesQuery =
                from a in authors
                select a.FullName;

            // Assert
            Assert.Equal(new[] { "Keith Dahlby", "Craig Barkley", "Prince" }, names);
            Assert.Equal(names, namesQuery);
        }

        [Fact]
        public void FilterInLinqIsCalledWhere()
        {
            IEnumerable<Author> authors = new Bag<Author>
            {
                new Author("Keith", "Dahlby"),
                new Author("Craig", "Barkley"),
                new Author("Kylo", "Ren"),
            };

            // Act
            // LINQ method syntax
            IEnumerable<string> names = authors
                .Where(author => author.FirstName.StartsWith("K"))
                .Select(author => author.FirstName);

            // Extension method allows this:
            //   Enumerable.Where(authors, a => ...)
            // to be called like this:
            //   authors.Where(a => ...)

            // Lambda expression or a delegate
            // (Author a) => a.FirstName == "Keith"
            // is a Func<Author, bool> = "function from Author to boolean"

            // SQL : SELECT FirstName From Authors WHERE FirstName LIKE 'K%'
            // LINQ Query syntax
            IEnumerable<string> namesQuery =
                from a in authors
                where a.FirstName.StartsWith("K")
                select a.FirstName;

            // Assert
            Assert.Equal(new[] { "Keith", "Kylo" }, names);
            Assert.Equal(names, namesQuery);
        }

        [Fact]
        public void ReduceInLinqIsCalledAggregate()
        {
            List<int> numbers = new List<int>
            {
                1,2,3,4,5,5,12,1235,5
            };

            numbers.Insert(8, 25);

            // numbers.reduce((acc, next) => acc + next, 0)
            int sum = numbers.Distinct().Aggregate(0, (acc, next) => acc + next);

            Assert.Equal(1287, sum);
        }

        [Fact]
        public void Can_group_by_Author()
        {
            Book[] books = new[]
            {
                new Book {Title = "HP 1", Author = "JKR" },
                new Book {Title = "HP 2", Author = "JKR" },
                new Book {Title = "HP 3", Author = "JKR" },
                new Book {Title = "HP 4", Author = "JKR" },
                new Book {Title = "HP 5", Author = "JKR" },
                new Book {Title = "HP 6", Author = "JKR" },
                new Book {Title = "HP 7", Author = "JKR" },
                new Book {Title = "LoTR1", Author = "JRRT" },
                new Book {Title = "LoTR2", Author = "JRRT" },
                new Book {Title = "LoTR3", Author = "JRRT" },
                new Book {Title = "The Hobbit", Author = "JRRT" },
                new Book {Title = "C# in Depth", Author = "Jon Skeet" },
            };

            var booksByAuthor =
                from book in books
                group book by book.Author into authorBooks
                // Grouping { Key, Values }
                // Grouping { JKR, Books = 1,2,3,5 }
                // Grouping { JRRT, Books = 1,2,3 }
                select new
                {
                    Author = authorBooks.Key, // Thing we grouped by
                    BookCount = authorBooks.Count(),
                    BookTitles = authorBooks.Select(book => book.Title).ToArray(),
                };

            // books.GroupBy(book => book.Author).Select(...)

            var booksByAuthorList = booksByAuthor.ToList();
            Assert.Equal(3, booksByAuthorList.Count);

            Assert.Equal("JKR", booksByAuthorList[0].Author);
            Assert.Equal(7, booksByAuthorList[0].BookCount);

            Assert.Equal("JRRT", booksByAuthorList[1].Author);
            Assert.Equal(4, booksByAuthorList[1].BookCount);
            Assert.Equal(new[] { "LoTR1", "LoTR2", "LoTR3", "The Hobbit" }, booksByAuthorList[1].BookTitles);
        }
    }

    internal class Author
    {
        public Author(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public virtual string FullName => $"{FirstName} {LastName}";
    }

    internal class SingleNameAuthor : Author
    {
        public SingleNameAuthor(string singleName) : base(singleName, "")
        {
        }

        public override string FullName => FirstName;
    }
}