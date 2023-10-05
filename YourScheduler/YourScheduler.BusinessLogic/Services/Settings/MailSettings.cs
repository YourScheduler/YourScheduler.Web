namespace YourScheduler.BusinessLogic.Services.Settings
{
    public class MailSettings
    {
        public string MailAddress { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Host { get; set; } = null!;
        public int Port { get; set; }
    }
}
