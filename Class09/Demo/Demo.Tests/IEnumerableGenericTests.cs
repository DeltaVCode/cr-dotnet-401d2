using System.Collections.Generic;
using Xunit;

namespace Demo.Tests
{
    public class IEnumerableGenericTests
    {
        [Fact]
        public void ArrayIsIEnumerable()
        {
            int[] numbers = new int[] { 1, 2, 3 };

            AssertAllNotZero(numbers);

            ManuallyEnumerate(numbers);
        }

        private void ManuallyEnumerate(IEnumerable<int> sequence)
        {
            IEnumerator<int> enumerator = sequence.GetEnumerator();
            while (enumerator.MoveNext())
            {
                int number = enumerator.Current;
                Assert.NotEqual(0, number);
            }
        }

        private static void AssertAllNotZero(IEnumerable<int> sequence)
        {
            foreach (int n in sequence)
            {
                Assert.NotEqual(0, n);
            }
        }

        [Fact]
        public void ListIsIEnumerable()
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            // numbers.Add("3"); // Compiler error now!

            ManuallyEnumerate(numbers);

            // This will pass because the loop can only find numbers
            AssertAllNotZero(numbers);
        }

        [Fact]
        public void LinkedListIsIEnumerable()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);

            ManuallyEnumerate(list);

            AssertAllNotZero(list);

            Assert.Equal(new[] { 1, 2 }, list);
        }

        [Fact]
        public void HashSetIsIEnumerable()
        {
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(1); // HashSet prevents duplicates

            // but is still IEnumerable<>
            ManuallyEnumerate(set);

            AssertAllNotZero(set);

            Assert.Equal(new[] { 1, 2 }, set);
        }
    }
}