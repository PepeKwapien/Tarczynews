using System.ComponentModel.DataAnnotations;

namespace Tarczynews.Models
{
    public class TarczynCap
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string? City { get; set; }
        public string? Message { get; set; }
    }
}
