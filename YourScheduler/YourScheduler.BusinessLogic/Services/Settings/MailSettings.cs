namespace YourScheduler.BusinessLogic.Services.Settings
{
    public class MailSettings
    {
        public string MailAddress { get; } = null!;
        public string DisplayName { get; } = null!;
        public string Password { get; } = null!;
        public string Host { get; } = null!;
        public int Port { get; }
    }
}