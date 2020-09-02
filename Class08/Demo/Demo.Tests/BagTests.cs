using Xunit;

namespace Demo.Tests
{
    public class BagTests
    {
        [Fact]
        public void BagStartsEmpty()
        {
            // Arrange
            Bag<string> bag = new Bag<string>();

            // Act

            // Assert
            Assert.Empty(bag);
            Assert.Equal(0, bag.Count);
        }

        [Fact]
        public void CanAddToBag()
        {
            // Arrange
            Bag<string> bag = new Bag<string>();

            // Act
            bag.Add("Keith");

            // Assert
            Assert.Equal(new[] { "Keith" }, bag);
            Assert.Equal(1, bag.Count);

            // Act
            bag.Add("Samantha");

            // Assert
            Assert.Equal(new[] { "Keith", "Samantha" }, bag);
            Assert.Equal(2, bag.Count);

            // Act
            bag.Add("Jordan");

            // Assert
            Assert.Equal(new[] { "Keith", "Samantha", "Jordan" }, bag);

            // Act
            bag.Add("Sara");

            // Assert
            Assert.Equal(new[] { "Keith", "Samantha", "Jordan", "Sara" }, bag);

            // Act
            bag.Add("Aaron");

            // Assert
            Assert.Equal(new[] { "Keith", "Samantha", "Jordan", "Sara", "Aaron" }, bag);
        }

        [Fact]
        public void CanRemoveFromBag()
        {
            // Arrange
            Bag<string> bag = new Bag<string>
            {
                "A",
                "B",
                "C",
            };

            // Act
            bool result = bag.RemoveAt(1);

            // Assert
            Assert.True(result);
            Assert.Equal(new[] { "A", "C" }, bag);
            Assert.Equal(2, bag.Count);
        }
    }
}