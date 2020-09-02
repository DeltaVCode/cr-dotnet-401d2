using System.Collections;
using Xunit;

namespace Demo.Tests
{
    public class IEnumerableTests
    {
        [Fact]
        public void ArrayIsIEnumerable()
        {
            int[] numbers = new int[] { 1, 2, 3 };

            AssertAllNotZero(numbers);

            ManuallyEnumerate(numbers);
        }

        private void ManuallyEnumerate(IEnumerable sequence)
        {
            IEnumerator enumerator = sequence.GetEnumerator();
            while (enumerator.MoveNext())
            {
                object number = enumerator.Current;
                Assert.NotEqual(0, number);
            }
        }

        private static void AssertAllNotZero(IEnumerable sequence)
        {
            foreach (int n in sequence)
            {
                Assert.NotEqual(0, n);
            }
        }

        [Fact]
        public void ArrayListIsIEnumerable()
        {
            ArrayList numbers = new ArrayList();
            numbers.Add(1);
            numbers.Add(2);
            // numbers.Add("3"); // Legal! But not great!

            ManuallyEnumerate(numbers);

            // This will fail because the loop assumes only numbers
            AssertAllNotZero(numbers);
        }
    }
}