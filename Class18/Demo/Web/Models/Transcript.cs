namespace Web.Models
{
    public class Transcript
    {
        public long StudentId { get; set; }
        public long CourseId { get; set; }

        // "Payload" of our non-pure join table
        public Grade Grade { get; set; }

        // Navigation Properties
        public Student Student { get; set; }

        public Course Course { get; set; }
    }

    public enum Grade
    {
        A,
        B,
        C,
        D,
        F,
    }
}