using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo
{
    public class Bag<T> : IEnumerable<T>
    {
        // Fields
        private T[] things = new T[2];

        private int count = 0;

        // Not a property because this is really an implementation detail
        //public T[] Things { get; set; }

        public void Add(T thing)
        {
            // Ran out of room!
            if (count >= things.Length)
            {
                Array.Resize(ref things, things.Length * 2);
            }

            things[count] = thing;
            count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return things[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}