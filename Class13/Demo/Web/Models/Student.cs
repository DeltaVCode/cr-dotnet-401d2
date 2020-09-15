using System;
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
    }
}