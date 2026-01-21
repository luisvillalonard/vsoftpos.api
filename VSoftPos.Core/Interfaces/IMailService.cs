using Pos.Core.Entidades.Seguridad;
using Pos.Core.Modelos.Email;

namespace Pos.Core.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        void Correo_Nuevo_Usuario(Usuario usuario, string newPass);
    }
}
