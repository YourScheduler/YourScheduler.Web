namespace YourScheduler.BusinessLogic.Services.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = default!;

        public string Issuer { get; set; } = default!;
    }
}
