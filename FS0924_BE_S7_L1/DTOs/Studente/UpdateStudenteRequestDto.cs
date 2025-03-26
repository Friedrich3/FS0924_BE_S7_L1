using System.ComponentModel.DataAnnotations;
using FS0924_BE_S7_L1.Models;
using FS0924_BE_S7_L1.DTOs.StudentProfile;

namespace FS0924_BE_S7_L1.DTOs.Studente
{
    public class UpdateStudenteRequestDto
    {
        [Required]
        [StringLength(50)]
        public required string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public required string Cognome { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public required string Email { get; set; }

        public  required AddStudentProfileDto? StudentProfile { get; set; }
    }
}
