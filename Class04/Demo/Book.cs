using System;

namespace Demo
{
    public class Book
    {
        // Fields
        private readonly string title;
        private Author author;

        // Constructor
        public Book(string title)
        {
            this.title = title;
        }

        // Properties
        public string Title
        {
            get { return title; }
        }

        // Java has to do this because it doesn't have properties
        public string GetTitle()
        {
            return title;
        }

        // Automatic property has secret field
        public string Publisher { get; set; }

        public Author Author
        {
            get { return author; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                this.author = value;
            }
        }

        // Methods
        public string FormatBookTitleAndAuthor()
        {
            return $"{Title} by {Author.FirstName} {Author.LastName}";
        }
    }
}
