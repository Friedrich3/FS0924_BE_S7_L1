namespace FS0924_BE_S7_L1.DTOs.Account
{
    public class LoginRequestDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
