using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    // Pure join table/entity
    public class Enrollment
    {
        public long CourseId { get; set; }

        public long StudentId { get; set; }

        // Navigation Properties
        // EF is guessing that this corresponds to <PropertyName>Id
        public Course Course { get; set; }

        [ForeignKey(nameof(StudentId))] // No guessing
        public Student Student { get; set; }
    }
}