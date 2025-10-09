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
        private ConexionBD conexion = new ConexionBD();
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
        }







        /*public EmailService()
        {
            // TUS DATOS REALES - REEMPLAZA EL API KEY
            _apiKey = "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"; // TU API KEY DE SENDGRID
            _emailFrom = "soporte.michebytes@hotmail.com"; // Email verificado
        }

        public async Task<bool> EnviarEmailAsync(string to, string subject, string body)
        {
            try
            {
                var client = new SendGridClient(_apiKey);
                var from = new EmailAddress(_emailFrom, "Michebytes");
                var toEmail = new EmailAddress(to);

                var msg = MailHelper.CreateSingleEmail(from, toEmail, subject,
                    "Tu contraseña es: tucontraPrueba", // Versión texto plano
                    body); // Versión HTML

                var response = await client.SendEmailAsync(msg);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("✅ Email enviado correctamente");
                    return true;
                }
                else
                {
                    MessageBox.Show($"❌ Error en el envío: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error: {ex.Message}");
                return false;
            }
        }

        public async void EnviarRecuperacionPassword(string emailDestino, string password)
        {
            string subject = "Recuperación de Contraseña - Michebytes";

            string body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
                        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                        .header {{ background: #007bff; color: white; padding: 20px; text-align: center; }}
                        .content {{ background: #f8f9fa; padding: 20px; border-radius: 5px; margin: 20px 0; }}
                        .password {{ font-size: 24px; color: #dc3545; font-weight: bold; text-align: center; }}
                        .footer {{ margin-top: 20px; padding-top: 20px; border-top: 1px solid #ddd; color: #666; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>🔐 Michebytes</h1>
                        </div>
                        
                        <h2>Recuperación de Contraseña</h2>
                        <p>Hola,</p>
                        <p>Aquí están tus datos de acceso solicitados:</p>
                        
                        <div class='content'>
                            <p><strong>Email:</strong> {emailDestino}</p>
                            <p><strong>Contraseña:</strong></p>
                            <div class='password'>{password}</div>
                        </div>
                        
                        <p>Por seguridad, te recomendamos cambiar tu contraseña después de iniciar sesión.</p>
                        
                        <div class='footer'>
                            <p>Saludos,<br><strong>Equipo Michebytes</strong></p>
                            <p><small>Este es un mensaje automático, por favor no responder.</small></p>
                        </div>
                    </div>
                </body>
                </html>";

            bool exito = await EnviarEmailAsync(emailDestino, subject, body);

            if (exito)
            {
                // Guardar log o realizar otras acciones
            }
        }*/
    }
}
