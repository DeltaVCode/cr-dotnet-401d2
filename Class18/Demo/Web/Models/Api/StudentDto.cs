using System;
using System.Collections.Generic;

namespace Web.Models.Api
{
    public class StudentDto
    {
        public long Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SortName { get; set; }

        public List<StudentGradeDto> Grades { get; set; }
    }

    public class StudentGradeDto
    {
        public long CourseId { get; set; }
        public string CourseCode { get; set; }
        public string Technology { get; set; }
        public string Grade { get; set; }
    }
}