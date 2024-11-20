

//using System;
//using System.ComponentModel.DataAnnotations;

//namespace Prog6212Part2.Models
//{
//    public class LecturerClaim
//    {
//        [Key]
//        public int Id { get; set; }

//        [Required]
//        [Range(0, int.MaxValue, ErrorMessage = "Hourly rate must be a positive value.")]
//        public int HourlyRate { get; set; }

//        [Required]
//        [Range(0, int.MaxValue, ErrorMessage = "Hours worked must be a positive integer.")]
//        public int HoursWorked { get; set; }

//        [MaxLength(500)]
//        public string AdditionalNote { get; set; }

//        [Required]
//        [DataType(DataType.Date)]
//        [Display(Name = "Submission Date")]
//        [CustomValidation(typeof(LecturerClaim), nameof(ValidateDate))]
//        public DateTime DateSubmitted { get; set; }

//        public string DocumentPath { get; set; }

//        public bool? IsApproved { get; set; }
//        public string UserId { get; set; }

//        public decimal TotalAmount => HourlyRate * HoursWorked;


//              public string ReviewedBy { get; set; }  // To store the reviewer's name
//             public DateTime? ReviewedOn { get; set; }  // To store when the claim was reviewed
//        public static ValidationResult ValidateDate(DateTime date, ValidationContext context)
//        {
//            if (date > DateTime.Now)
//            {
//                return new ValidationResult("Submission date cannot be in the future.");
//            }
//            return ValidationResult.Success;
//        }
//    }
//}

using System;
using System.ComponentModel.DataAnnotations;

namespace Prog6212Part2.Models
{
    public class LecturerClaim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Hourly rate must be a positive value.")]
        public int HourlyRate { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Hours worked must be a positive integer.")]
        public int HoursWorked { get; set; }

        [MaxLength(500)]
        public string AdditionalNote { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Submission Date")]
        [CustomValidation(typeof(LecturerClaim), nameof(ValidateDate))]
        public DateTime DateSubmitted { get; set; }

        public string DocumentPath { get; set; }

        public bool? IsApproved { get; set; }
        public string UserId { get; set; }
        public decimal TotalAmount => HourlyRate * HoursWorked;

        public string ReviewedBy { get; set; }
        public DateTime? ReviewedOn { get; set; }

        // Check if the claim is valid based on conditions
        public bool IsValid => HourlyRate < 10000 && HoursWorked <= 25 && DateSubmitted <= DateTime.Now;

        public static ValidationResult ValidateDate(DateTime date, ValidationContext context)
        {
            if (date > DateTime.Now)
            {
                return new ValidationResult("Submission date cannot be in the future.");
            }
            return ValidationResult.Success;
        }
    }
}

