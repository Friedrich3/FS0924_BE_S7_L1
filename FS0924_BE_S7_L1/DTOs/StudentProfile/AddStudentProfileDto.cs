using System.ComponentModel.DataAnnotations;

namespace FS0924_BE_S7_L1.DTOs.StudentProfile
{
    public class AddStudentProfileDto
    {
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [StringLength(16)]
        public required string FiscalCode { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public required DateTime BirthDate { get; set; }
    }
}
