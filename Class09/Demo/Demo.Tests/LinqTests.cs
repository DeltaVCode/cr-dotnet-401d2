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
            int sum = numbers.Aggregate(0, (acc, next) => acc + next);

            Assert.Equal(1297, sum);
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