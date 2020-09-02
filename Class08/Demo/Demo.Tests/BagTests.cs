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

            // Act
            bag.Add("Samantha");

            // Assert
            Assert.Equal(new[] { "Keith", "Samantha" }, bag);

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
    }
}