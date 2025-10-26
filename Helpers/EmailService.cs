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
        // Configuración para Gmail
        private readonly string remitente = "soporte.michebytes@gmail.com";
        private readonly string contraseña = "tqqstyyjiyqwmelr"; // Contraseña de aplicación de Gmail
        private readonly string smtpHost = "smtp.gmail.com";
        private readonly int smtpPort = 587;

        private string ultimoCodigoGenerado;

        public string GenerarCodigo()
        {
            Random random = new Random();
            ultimoCodigoGenerado = random.Next(100000, 999999).ToString();
            return ultimoCodigoGenerado;
        }

        public string ObtenerUltimoCodigo()
        {
            return ultimoCodigoGenerado;
        }

        public async Task EnviarCodigoVerificacion(string destinatario)
        {
            string codigo = GenerarCodigo();

            string asunto = "🔐 Código de Verificación - MicheBytes";
            string cuerpoHtml = $@"
    <!DOCTYPE html>
    <html>
    <head>
        <meta charset='utf-8'>
        <style>
            body {{ 
                font-family: 'Segoe UI', Arial, sans-serif; 
                background-color: #f6f9fc; 
                margin: 0; 
                padding: 0; 
            }}
            .container {{ 
                max-width: 600px; 
                margin: 0 auto; 
                background: white; 
                border-radius: 12px; 
                box-shadow: 0 4px 12px rgba(0,0,0,0.1); 
                overflow: hidden;
            }}
            .header {{ 
                background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
                padding: 30px 20px; 
                text-align: center; 
                color: white;
            }}
            .logo {{ 
                font-size: 28px; 
                font-weight: bold; 
                margin-bottom: 10px;
            }}
            .content {{ 
                padding: 40px 30px; 
                color: #333;
            }}
            .code-container {{ 
                background: #f8f9fa; 
                border: 2px dashed #dee2e6; 
                border-radius: 8px; 
                padding: 20px; 
                text-align: center; 
                margin: 25px 0;
            }}
            .verification-code {{ 
                font-size: 32px; 
                font-weight: bold; 
                color: #28a745; 
                letter-spacing: 8px; 
                margin: 10px 0;
            }}
            .instructions {{ 
                color: #6c757d; 
                line-height: 1.6; 
                margin-bottom: 25px;
            }}
            .warning {{ 
                background: #fff3cd; 
                border: 1px solid #ffeaa7; 
                border-radius: 6px; 
                padding: 15px; 
                margin: 20px 0;
                color: #856404;
            }}
            .footer {{ 
                background: #f8f9fa; 
                padding: 20px; 
                text-align: center; 
                color: #6c757d; 
                font-size: 12px;
                border-top: 1px solid #e9ecef;
            }}
            .button {{ 
                display: inline-block; 
                background: #28a745; 
                color: white; 
                padding: 12px 30px; 
                text-decoration: none; 
                border-radius: 6px; 
                font-weight: bold; 
                margin: 10px 0;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='header'>
                <div class='logo'>🔐 MicheBytes</div>
                <h1 style='margin: 10px 0; font-size: 24px;'>Verificación de Seguridad</h1>
            </div>
            
            <div class='content'>
                <h2 style='color: #333; margin-bottom: 20px;'>Hola,</h2>
                
                <p class='instructions'>
                    Has solicitado restablecer tu contraseña. Para completar este proceso, 
                    utiliza el siguiente código de verificación:
                </p>
                
                <div class='code-container'>
                    <p style='margin: 0 0 10px 0; color: #6c757d; font-size: 14px;'>CÓDIGO DE VERIFICACIÓN</p>
                    <div class='verification-code'>{codigo}</div>
                    <p style='margin: 10px 0 0 0; color: #6c757d; font-size: 12px;'>
                        Válido por 10 minutos
                    </p>
                </div>
                
                <p class='instructions'>
                    Ingresa este código en la aplicación para continuar con el cambio de contraseña.
                </p>
                
                <div class='warning'>
                    <strong>⚠️ Importante:</strong><br>
                    • Este código es de un solo uso<br>
                    • No compartas este código con nadie<br>
                    • Si no solicitaste este cambio, ignora este mensaje
                </div>
                
                <p style='text-align: center; margin: 30px 0 10px 0;'>
                    <a href='#' class='button'>Ir a la Aplicación</a>
                </p>
            </div>
            
            <div class='footer'>
                <p style='margin: 0 0 10px 0;'>
                    <strong>Equipo MicheBytes</strong><br>
                    Soporte y desarrollo
                </p>
                <p style='margin: 0; font-size: 11px; color: #adb5bd;'>
                    Este es un mensaje automático, por favor no respondas a este correo.<br>
                    © 2025 MicheBytes. Todos los derechos reservados.
                </p>
            </div>
        </div>
    </body>
    </html>";

            try
            {
                using (SmtpClient smtp = new SmtpClient(smtpHost, smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(remitente, contraseña);
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    using (MailMessage mensaje = new MailMessage())
                    {
                        mensaje.From = new MailAddress(remitente, "Soporte MicheBytes 🔐");
                        mensaje.To.Add(destinatario);
                        mensaje.Subject = asunto;
                        mensaje.Body = cuerpoHtml;
                        mensaje.IsBodyHtml = true;
                        // Prioridad alta para emails de verificación
                        mensaje.Priority = MailPriority.High;

                        await smtp.SendMailAsync(mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error SMTP: {ex.Message}");
            }
        }
    }
}


