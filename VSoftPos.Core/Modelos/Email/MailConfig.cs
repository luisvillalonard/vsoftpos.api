namespace Pos.Core.Modelos.Email
{
    public class MailConfig
    {
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public bool DefaultCredentials { get; set; }
        public string Email { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool SSL { get; set; }
    }
}
