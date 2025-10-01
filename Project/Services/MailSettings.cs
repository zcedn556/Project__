namespace Project.Services
{
    public class MailSettings
    {
        public string Mail { get; set; } = string.Empty;
        public string DisplayName { get; set; } = "Cinema Project";
        public string Password { get; set; } = string.Empty;
        public string Host { get; set; } = "smtp.gmail.com";
        public int Port { get; set; } = 587;
    }
}
