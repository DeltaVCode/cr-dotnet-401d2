using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Course
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseCode { get; set; }

        [Column(TypeName = "money")] // or decimal(18,6)
        public decimal Price { get; set; }
    }
}