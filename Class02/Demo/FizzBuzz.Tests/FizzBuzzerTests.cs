using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzerTests
    {
        [Fact]
        public void IsDivisibleBy_returns_true_given_6_and_3()
        {
            // Arrange
            int number = 6;
            int divisor = 3;

            // Act
            bool result = FizzBuzzer.IsDivisibleBy(number, divisor);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsDivisibleBy_returns_false_given_6_and_4()
        {
            // Arrange
            int number = 6;
            int divisor = 4;

            // Act
            bool result = FizzBuzzer.IsDivisibleBy(number, divisor);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsDivisibleBy_returns_false_given_6_and_9()
        {
            // Arrange
            int number = 6;
            int divisor = 9;

            // Act
            bool result = FizzBuzzer.IsDivisibleBy(number, divisor);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(6, 0, false)]
        [InlineData(6, 1, true)]
        [InlineData(6, 2, true)]
        [InlineData(6, 3, true)]
        [InlineData(6, 4, false)]
        [InlineData(6, 9, false)]
        public void IsDivisibleBy_returns_expected_result(int number, int divisor, bool expected)
        {
            // Arrange
            // from theory parameters

            // Act
            bool result = FizzBuzzer.IsDivisibleBy(number, divisor);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(4, "4")]
        [InlineData(5, "Buzz")]
        [InlineData(6, "Fizz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(30, "FizzBuzz")]
        public void Convert_returns_expected_result(int number, string expected)
        {
            // Arrange
            // from Theory InlineData

            // Act
            string result = FizzBuzzer.Convert(number);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
