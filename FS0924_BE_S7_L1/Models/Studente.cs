using System.ComponentModel.DataAnnotations;

namespace FS0924_BE_S7_L1.Models
{
    public class Studente
    {
        [Key]
        public Guid Id { get; set; }
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

    }
}
