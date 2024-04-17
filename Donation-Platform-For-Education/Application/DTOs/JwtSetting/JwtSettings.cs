namespace Donation_Platform_For_Education.Application.DTOs.JwtSetting
{
    public class JwtSettings
    {
        public string SigningKey { get; set; }
        public string Issuer { get; set; }
        public string Audiance { get; set; }
        public int AccessTokeExpiryMinutes { get; set; }
        public int RefreshTokenExpiryMinutes { get; set; }
    }
}
