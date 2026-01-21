using Microsoft.Extensions.Options;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Interfaces;
using Pos.Core.Modelos;
using Pos.Core.Modelos.Email;
using System.Net;
using System.Net.Mail;

namespace Pos.Infraestructure.Services
{
    public class MailService : IMailService
    {
        private readonly AppSettingsModel _mailSettings;
        public MailService(IOptions<AppSettingsModel> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var client = new SmtpClient()
                {
                    EnableSsl = _mailSettings.MailConfig.SSL,
                    UseDefaultCredentials = _mailSettings.MailConfig.DefaultCredentials,
                    Credentials = new NetworkCredential(_mailSettings.MailConfig.Email, _mailSettings.MailConfig.Password),
                    Host = _mailSettings.MailConfig.Host,
                    Port = _mailSettings.MailConfig.Port
                };
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                    | SecurityProtocolType.Tls11
                    | SecurityProtocolType.Tls12
                    | SecurityProtocolType.Tls13;


                // Create email message
                MailMessage mailMessage = new()
                {
                    From = new MailAddress(_mailSettings.MailConfig.Email),
                    Subject = mailRequest.Subject,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(mailRequest.ToEmail);

                //var builder = new BodyBuilder();
                //if (mailRequest.Attachments != null)
                //{
                //    byte[] fileBytes;
                //    foreach (var file in mailRequest.Attachments)
                //    {
                //        if (file.Length > 0)
                //        {
                //            using (var ms = new MemoryStream())
                //            {
                //                file.CopyTo(ms);
                //                fileBytes = ms.ToArray();
                //            }
                //            builder.Attachments.Add(file.FileName, fileBytes, MimeKit.ContentType.Parse(file.ContentType));
                //        }
                //    }
                //}
                //builder.HtmlBody = mailRequest.Body;
                //mailMessage.Body = builder.ToString();

                mailMessage.Body = mailRequest.Body;

                // Send email
                await Task.Run(() => client.Send(mailMessage));
            }
            catch (Exception) { }
        }

        public void Correo_Nuevo_Usuario(Usuario usuario, string clave)
        {
            if (_mailSettings != null)
            {
                // Envio el correo con la clave del usuario
                try
                {
                    if (usuario.Correo != null)
                    {
                        // Envio el correo
                        var mailRequest = new MailRequest()
                        {
                            ToEmail = usuario.Correo,
                            Subject = "Creación de Usuario en Sistema Alquiler de Vehículos.",
                            Body = $"<p>Ha realizado su registro en ${_mailSettings.MailConfig.DisplayName} de forma exitosa. </p>" +
                                    $"<br />" +
                                    $"<ul>" +
                                    $"<li>Su usuario es: {usuario.Acceso}</li>" +
                                    $"<li>Su clave temporal es: {clave}</li>" +
                                    $"</ul>" +
                                    $"<br />" +
                                    $"<p>Para completar su ingreso al sistema deberá ir al sistema y establecer su nueva contraseña haciendo click en el siguiente enlace: <a href='{_mailSettings.AllowedOrigins.First()}/login'>Completar acceso al sistema</a></p>"
                        };

                        SendEmailAsync(mailRequest).RunSynchronously();
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
