using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Helpers
{
    public class UiHelpers
    {
        /// <summary>
        /// Aplica un gradiente a un control en su evento Paint
        /// </summary>
        /// <param name="control">Control al que aplicar el gradiente</param>
        /// <param name="color1">Color inicial del gradiente</param>
        /// <param name="color2">Color final del gradiente</param>
        /// <param name="mode">Dirección del gradiente</param>
        public static void SetGradient(Control control, Color color1, Color color2, LinearGradientMode mode = LinearGradientMode.Vertical)
        {
            control.Paint += (s, e) =>
            {
                Rectangle rect = control.ClientRectangle;
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, mode))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };

            // Forzar repaint para que se vea al instante
            control.Invalidate();
        }

        /// Redondea un botón existente.
        /// </summary>
        /// <param name="btn">Botón a redondear</param>
        /// <param name="radius">Radio de las esquinas</param>
        /// <param name="borderColor">Color del borde (opcional, null = sin borde)</param>
        /// <param name="borderWidth">Grosor del borde</param>
        public static void SetRoundedButton(Button btn, int radius, Color? borderColor = null, int borderWidth = 1)
        {
            btn.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = btn.ClientRectangle;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    btn.Region = new Region(path); // Redondeo de esquinas

                    // Opcional: dibujar borde
                    if (borderColor.HasValue)
                    {
                        using (Pen pen = new Pen(borderColor.Value, borderWidth))
                            e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            btn.Invalidate(); // Fuerza repaint
        }

        /// <summary>
        /// Redondea un TextBox existente.
        /// Nota: Funciona mejor con BorderStyle = None
        /// </summary>
        /// <param name="textBox">TextBox a redondear</param>
        /// <param name="radius">Radio de las esquinas</param>
        /// <param name="borderColor">Color del borde (opcional)</param>
        /// <param name="borderWidth">Grosor del borde</param>
        /// <summary>
        /// Redondea un TextBox existente.
        /// Funciona correctamente en controles existentes del diseñador.
        /// Nota: BorderStyle debe ser None.
        /// </summary>
        public static void SetRoundedTextBox(TextBox textBox, int radius)
        {
            if (textBox.BorderStyle != BorderStyle.None)
                textBox.BorderStyle = BorderStyle.None;

            var rect = new Rectangle(0, 0, textBox.Width, textBox.Height);
            using (var path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                textBox.Region = new Region(path);
            }
        }

        /// <summary>
        /// Redondea un panel existente.
        /// </summary>
        public static void SetRoundedPanel(Panel panel, int radius)
        {
            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = panel.ClientRectangle;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    panel.Region = new Region(path);

                    using (SolidBrush brush = new SolidBrush(panel.BackColor))
                        e.Graphics.FillPath(brush, path);
                }
            };
            panel.Invalidate();
        }




    }
}
