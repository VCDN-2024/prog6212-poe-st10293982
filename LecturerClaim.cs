
//using System;
//using System.ComponentModel.DataAnnotations;

//namespace Prog6212Part2.Models
//{
//    public class LecturerClaim
//    {
//        [Key]
//        public int Id { get; set; }

//        // The hourly rate for the lecturer
//        [Required]
//        [Range(0, double.MaxValue, ErrorMessage = "Hourly rate must be a positive value.")]
//        public decimal HourlyRate { get; set; }

//        // The total number of hours worked
//        [Required]
//        [Range(0, 1000, ErrorMessage = "Hours worked must be a valid number.")]
//        public double HoursWorked { get; set; }

//        // Additional notes or comments provided by the lecturer
//        [MaxLength(500)]
//        public string AdditionalNote { get; set; }

//        // Date when the claim was submitted
//        [Required]
//        public DateTime DateSubmitted { get; set; }

//        // Whether the claim is approved (null: pending, true: approved, false: rejected)
//        public bool? IsApproved { get; set; }

//        // Path to the document uploaded with the claim (PDF, DOCX, XLSX)
//        [MaxLength(255)]
//        public string DocumentPath { get; set; }

//        // The user ID of the lecturer submitting the claim
//        public string UserId { get; set; }

//        // Calculated total amount for the claim (hours worked * hourly rate)
//        public decimal TotalAmount => (decimal)HoursWorked * HourlyRate;

//        public string ReviewedBy { get; set; }  // To store the reviewer's name
//        public DateTime? ReviewedOn { get; set; }  // To store when the claim was reviewed
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


              public string ReviewedBy { get; set; }  // To store the reviewer's name
             public DateTime? ReviewedOn { get; set; }  // To store when the claim was reviewed
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


