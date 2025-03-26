namespace FS0924_BE_S7_L1.Settings
{
    public class Jwt
    {
        public required string SecurityKey { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required int ExpiresInMinutes { get; set; }
    }
}
