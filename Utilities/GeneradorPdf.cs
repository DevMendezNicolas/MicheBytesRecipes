using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Utilities
{
    public class GeneradorPdf
    {
        private class PdfFooter : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);
                string footerText = $"PDF generado el {DateTime.Now:dd/MM/yyyy HH:mm:ss}";

                ColumnText.ShowTextAligned(
                    writer.DirectContent,
                    Element.ALIGN_RIGHT,
                    new Phrase(footerText, FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12, BaseColor.GRAY)),
                    document.PageSize.GetRight(40),
                    document.PageSize.GetBottom(30),
                    0
                );
            }
        }

        public static void ExportarPDF(DataGridView dgv, string titulo = "Reporte")
        {
            try
            {
                // Obtener carpeta Descargas
                string carpetaDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string carpetaDestino;

                // Verificar si existe la carpeta Downloads, si no usar Escritorio/Reportes
                if (Directory.Exists(carpetaDescargas))
                {
                    carpetaDestino = carpetaDescargas;
                }
                else
                {
                    // Crear carpeta Reportes en el Escritorio
                    string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    carpetaDestino = Path.Combine(escritorio, "Reportes");

                    if (!Directory.Exists(carpetaDestino))
                        Directory.CreateDirectory(carpetaDestino);
                }

                // Nombre de archivo con fecha y hora
                string nombreArchivo = $"{titulo.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string archivoPDF = Path.Combine(carpetaDestino, nombreArchivo);

                // Crear documento PDF
                Document doc = new Document(PageSize.A4, 10, 10, 10, 50); // margen inferior más grande para footer
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(archivoPDF, FileMode.Create));

                writer.PageEvent = new PdfFooter();

                doc.Open();

                // Agregar título
                Paragraph parTitulo = new Paragraph(titulo)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 10f
                };
                doc.Add(parTitulo);

                // Contar columnas visibles
                int columnasVisibles = 0;
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Visible) columnasVisibles++;
                }

                PdfPTable tabla = new PdfPTable(columnasVisibles);

                // Encabezados en negrita
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Visible)
                    {
                        PdfPCell celdaEncabezado = new PdfPCell(new Phrase(col.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                        {
                            BackgroundColor = BaseColor.LIGHT_GRAY,
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                        tabla.AddCell(celdaEncabezado);
                    }
                }

                // Filas
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            if (dgv.Columns[celda.ColumnIndex].Visible)
                                tabla.AddCell(celda.Value?.ToString() ?? "");
                        }
                    }
                }

                doc.Add(tabla);
                doc.Close();

                MessageBox.Show($"PDF generado correctamente en:\n{archivoPDF}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

