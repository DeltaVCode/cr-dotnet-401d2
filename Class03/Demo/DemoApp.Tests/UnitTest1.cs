using System;
using System.IO;
using Xunit;

namespace DemoApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddTimestampToFile()
        {
            // Arrange
            string path = $"test{DateTime.Now.Ticks}.log";

            // Act
            Program.AddTimestampToFile(path);

            // Assert
            string[] lines = File.ReadAllLines(path);
            Assert.NotEmpty(lines);
            Assert.Matches(@"\d{4}-\d{2}-\d{2} \d\d:\d\d:\d\dZ", lines[0]);

            DateTime lineParsed = DateTime.Parse(lines[0]);
            Assert.NotEqual(DateTime.MinValue, lineParsed);

            // Act
            Program.AddTimestampToFile(path);

            string[] lines2 = File.ReadAllLines(path);
            Assert.Equal(lines.Length + 1, lines2.Length);

            Assert.Equal(lines[0], lines2[0]);

            int lastIndex = lines2.Length - 1;
            Assert.Matches(@"\d{4}-\d{2}-\d{2} \d\d:\d\d:\d\dZ", lines2[lastIndex]);

            DateTime lineParsed2 = DateTime.Parse(lines2[lastIndex]);
            Assert.NotEqual(DateTime.MinValue, lineParsed2);
        }
    }
}
