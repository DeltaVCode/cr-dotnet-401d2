using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CreateGrade
    {
        [Required]
        public long? CourseId { get; set; }

        [Required]
        public Grade? Grade { get; set; }
    }
}