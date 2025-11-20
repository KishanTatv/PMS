namespace PMS.Entity.Models
{
    public class JwtSettingDto
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public DateTime ExpiresIn { get; set; }
    }
}
