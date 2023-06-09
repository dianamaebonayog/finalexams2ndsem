using System.ComponentModel.DataAnnotations;

namespace BonayogDianaFinalExam.Manage
{
    public class UserDto
    {
        public Guid? Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Make { get; set; }
        [Required]
        public string? Manufacturer { get; set; }
        [Required]
        public int? Year { get; set; }
    }
}