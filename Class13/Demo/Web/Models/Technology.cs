using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Technology
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}