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

        /// Redondea un botón existente.
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


        // Redondea un TextBox

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


        // Redondea un panel

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
