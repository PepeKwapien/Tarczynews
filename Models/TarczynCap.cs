using System.ComponentModel.DataAnnotations;

namespace Tarczynews.Models
{
    public class TarczynCap
    {
        public TarczynCap() { }
        public TarczynCap(TarczynCap anotherCap) {
            Id = Guid.NewGuid();
            Copy(anotherCap);
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number needs to be greater than 0")]
        public int Number { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Your city name is too long")]
        public string? City { get; set; }
        public string? Message { get; set; }
        public TarczynewsUser Owner { get; set; }

        public void Copy(TarczynCap anotherCap)
        {
            Number = anotherCap.Number;
            City = anotherCap.City;
            Message = anotherCap.Message;
        }
    }
}
