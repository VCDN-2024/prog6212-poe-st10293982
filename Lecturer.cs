
using System.ComponentModel.DataAnnotations;

namespace Prog6212Part2.Models
{
    public class Lecturer
    {
        [Key]
        public string UserId { get; set; } // Matches with Identity User ID

        [Required]
        public string FullName { get; set; }

        [Required]
        [Phone]
        public string ContactNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
