using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Student
    {
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        // Reverse Navigation Property
        public List<Enrollment> Enrollments { get; set; }

        public List<Transcript> Transcripts { get; set; }
    }
}