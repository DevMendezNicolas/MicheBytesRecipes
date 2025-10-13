using MicheBytesRecipes.Connections;
using MySql.Data.MySqlClient;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Helpers
{
    public class EmailService
    {
        private readonly string _emailFrom = "soporte.michebytes@hotmail.com";
        private readonly string _password = "TU_CONTRASEÑA_DE_APP"; // ⚠️ Contraseña de aplicación (no la real)
        private readonly string _smtpHost = "smtp.office365.com";
        private readonly int _smtpPort = 587;

        // 🔹 Método genérico para enviar emails con HTML
        public async Task<bool> EnviarEmailAsync(string to, string subject, string htmlBody, string plainTextBody)
        {
            try
            {
                using (var smtp = new SmtpClient(_smtpHost, _smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailFrom, _password);
                    smtp.EnableSsl = true;

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress(_emailFrom, "Michebytes");
                        message.To.Add(to);
                        message.Subject = subject;
                        message.Body = htmlBody;
                        message.IsBodyHtml = true;

                        await smtp.SendMailAsync(message);
                    }
                }

                MessageBox.Show("✅ Email enviado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al enviar el correo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // 🔑 Envío específico para recuperación con código
        public async void EnviarCodigoRecuperacion(string emailDestino, string codigo)
        {
            string subject = "Código de recuperación - Michebytes";

            string htmlBody = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
                        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                        .header {{ background: #007bff; color: white; padding: 20px; text-align: center; border-radius: 5px 5px 0 0; }}
                        .content {{ background: #f8f9fa; padding: 20px; border-radius: 0 0 5px 5px; }}
                        .code {{ font-size: 28px; color: #28a745; font-weight: bold; text-align: center; letter-spacing: 3px; }}
                        .footer {{ margin-top: 20px; padding-top: 20px; border-top: 1px solid #ddd; color: #666; text-align: center; font-size: 13px; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>🔑 Recuperación de Cuenta</h1>
                        </div>
                        <div class='content'>
                            <p>Hola,</p>
                            <p>Recibimos una solicitud para recuperar tu cuenta. Utilizá el siguiente código de verificación:</p>
                            <div class='code'>{codigo}</div>
                            <p>Este código vence en 10 minutos.</p>
                        </div>
                        <div class='footer'>
                            <p>Equipo <strong>Michebytes</strong></p>
                            <p><small>Este es un mensaje automático, por favor no responder.</small></p>
                        </div>
                    </div>
                </body>
                </html>";

            string plainTextBody = $"Tu código de recuperación es: {codigo}\n\nEste código vence en 10 minutos.";

            await EnviarEmailAsync(emailDestino, subject, htmlBody, plainTextBody);
        }

        // 🔹 Ejemplo de generador de código random (podés tenerlo en otra clase)
        public string GenerarCodigo()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); // Ej: 6 dígitos
        }
    

    /*private ConexionBD conexion = new ConexionBD();
    private readonly string _apiKey;
    private readonly string _emailFrom;

    public EmailService()
    {
        // TUS DATOS REALES - REEMPLAZA EL API KEY
        _apiKey = "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"; // TU API KEY DE SENDGRID
        _emailFrom = "soporte.michebytes@hotmail.com"; // Email verificado
    }

    // 🔹 Método genérico para enviar emails con SendGrid
    public async Task<bool> EnviarEmailAsync(string to, string subject, string htmlBody, string plainTextBody)
    {
        try
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(_emailFrom, "Michebytes");
            var toEmail = new EmailAddress(to);

            var msg = MailHelper.CreateSingleEmail(from, toEmail, subject, plainTextBody, htmlBody);
            var response = await client.SendEmailAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("✅ Email enviado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show($"❌ Error en el envío: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"❌ Error al enviar el correo: {ex.Message}", "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // 🔑 Envío específico para recuperación de contraseña
    public async void EnviarRecuperacionPassword(string emailDestino, string password)
    {
        string subject = "Recuperación de Contraseña - Michebytes";

        string htmlBody = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
                    .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                    .header {{ background: #007bff; color: white; padding: 20px; text-align: center; border-radius: 5px 5px 0 0; }}
                    .content {{ background: #f8f9fa; padding: 20px; border-radius: 0 0 5px 5px; }}
                    .password {{ font-size: 24px; color: #dc3545; font-weight: bold; text-align: center; }}
                    .footer {{ margin-top: 20px; padding-top: 20px; border-top: 1px solid #ddd; color: #666; text-align: center; font-size: 13px; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>
                        <h1>🔐 Recuperación de Contraseña</h1>
                    </div>
                    <div class='content'>
                        <p>Hola,</p>
                        <p>Recibimos una solicitud para recuperar tu contraseña. Aquí están tus datos:</p>
                        <p><strong>Email:</strong> {emailDestino}</p>
                        <p><strong>Contraseña:</strong></p>
                        <div class='password'>{password}</div>
                        <p>Por seguridad, te recomendamos cambiar tu contraseña después de iniciar sesión.</p>
                    </div>
                    <div class='footer'>
                        <p>Equipo <strong>Michebytes</strong></p>
                        <p><small>Este es un mensaje automático, por favor no responder.</small></p>
                    </div>
                </div>
            </body>
            </html>";

        string plainTextBody = $"Recuperación de Contraseña - Michebytes\n\nTu contraseña es: {password}\n\nPor seguridad, te recomendamos cambiarla al iniciar sesión.";

        bool exito = await EnviarEmailAsync(emailDestino, subject, htmlBody, plainTextBody);

        if (exito)
        {
            // Podés registrar en logs, base de datos, etc.
        }
    }*/

    }
}
