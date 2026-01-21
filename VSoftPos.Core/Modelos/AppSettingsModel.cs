using Pos.Core.Modelos.Email;

namespace Pos.Core.Modelos
{
    public class AppSettingsModel
    {
        public string[] AllowedOrigins { get; set; } = null!;
        public MailConfig MailConfig { get; set; } = null!;
    }
}
