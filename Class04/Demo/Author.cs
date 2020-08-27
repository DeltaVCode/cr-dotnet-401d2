using System;

namespace Demo
{
    public class Author
    {
        // Constructor!
        public Author(string firstName, string lastName)
        {
            if (firstName == null)
                throw new ArgumentNullException(nameof(firstName));
            if (lastName == null)
                throw new ArgumentNullException(nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; } // private readonly set
        public string LastName { get; }
    }
}
