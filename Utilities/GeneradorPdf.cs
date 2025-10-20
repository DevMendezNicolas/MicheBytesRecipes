using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

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

        public static void ExportarPDF(DataGridView dgv, string titulo = "Reporte", bool landscapeIfManyColumns = true)
        {
            try
            {
                // Ruta destino
                string carpetaDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string carpetaDestino = Directory.Exists(carpetaDescargas) ? carpetaDescargas : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Reportes");
                if (!Directory.Exists(carpetaDestino)) Directory.CreateDirectory(carpetaDestino);

                string nombreArchivo = $"{SanitizarArchivo(titulo)}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string archivoPDF = Path.Combine(carpetaDestino, nombreArchivo);

                // Determinar orientación
                int visibleCols = dgv.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible);
                bool useLandscape = landscapeIfManyColumns && visibleCols > 6;
                Rectangle pageSize = useLandscape ? PageSize.A4.Rotate() : PageSize.A4;

                using (var fs = new FileStream(archivoPDF, FileMode.Create, FileAccess.Write, FileShare.None))
                using (var doc = new Document(pageSize, 20f, 20f, 60f, 40f)) // márgenes superiores/inferiores
                {
                    var writer = PdfWriter.GetInstance(doc, fs);
                    var footer = new PdfHeaderFooter(titulo); // header+footer configurable
                    writer.PageEvent = footer;

                    doc.Open();

                    // Fuentes reutilizables
                    var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    var fuenteSub = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.DARK_GRAY);
                    var fuenteHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                    var fuenteCelda = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                    // Título y subtítulo (fecha y conteo)
                    var pTitulo = new Paragraph(titulo, fuenteTitulo) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 6f };
                    doc.Add(pTitulo);
                    var pSub = new Paragraph($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}    Filas: {dgv.Rows.Count - (dgv.AllowUserToAddRows ? 1 : 0)}", fuenteSub) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 10f };
                    doc.Add(pSub);

                    // Preparar tabla
                    PdfPTable tabla;
                    var columnasVisibles = dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
                    if (columnasVisibles.Count == 0)
                    {
                        doc.Add(new Paragraph("No hay columnas visibles para exportar.", fuenteSub));
                        doc.Close();
                        return;
                    }
                    tabla = new PdfPTable(columnasVisibles.Count) { WidthPercentage = 100f, SpacingBefore = 6f };

                    // Calcular anchos relativos basados en ancho de columnas del DataGridView
                    float totalAncho = columnasVisibles.Sum(c => Math.Max(1, c.Width));
                    float[] proporciones = columnasVisibles.Select(c => Math.Max(1, c.Width) / totalAncho).ToArray();
                    tabla.SetWidths(proporciones);

                    // Encabezados
                    foreach (var col in columnasVisibles)
                    {
                        var celHeader = new PdfPCell(new Phrase(col.HeaderText, fuenteHeader))
                        {
                            BackgroundColor = new BaseColor(230, 230, 230),
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 6f,
                            BorderWidth = 0.5f
                        };
                        tabla.AddCell(celHeader);
                    }

                    // Filas: alternado de color y truncado / wrap controlado
                    bool alternar = false;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;
                        alternar = !alternar;
                        BaseColor rowColor = alternar ? BaseColor.WHITE : new BaseColor(245, 245, 245);

                        foreach (var col in columnasVisibles)
                        {
                            var cell = row.Cells[col.Index];
                            string texto = cell?.Value?.ToString() ?? string.Empty;
                            var pdfCell = new PdfPCell(new Phrase(texto, fuenteCelda))
                            {
                                BackgroundColor = rowColor,
                                Padding = 5f,
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                VerticalAlignment = Element.ALIGN_MIDDLE,
                                BorderWidth = 0.3f
                            };
                            tabla.AddCell(pdfCell);
                        }
                    }

                    doc.Add(tabla);
                    doc.Close();
                }

                // Abrir PDF si existe
                if (File.Exists(archivoPDF))
                {
                    try
                    {
                        var psi = new ProcessStartInfo
                        {
                            FileName = archivoPDF,
                            UseShellExecute = true
                        };
                        Process.Start(psi);
                        MessageBox.Show($"PDF generado correctamente:\n{archivoPDF}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"PDF generado en:\n{archivoPDF}\n\nPero no se pudo abrir: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string SanitizarArchivo(string s)
        {
            foreach (var c in Path.GetInvalidFileNameChars()) s = s.Replace(c, '_');
            return s.Replace(" ", "_");
        }

        // Clase para Header y Footer
        public class PdfHeaderFooter : PdfPageEventHelper
        {
            private readonly string _titulo;
            private PdfTemplate _totalPages;
            private BaseFont _bf;

            public PdfHeaderFooter(string titulo)
            {
                _titulo = titulo;
            }

            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                _totalPages = writer.DirectContent.CreateTemplate(50, 50);
                _bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                var cb = writer.DirectContent;
                int pageN = writer.PageNumber;
                string footerText = $"Página {pageN} de ";
                float len = _bf.GetWidthPoint(footerText, 9);

                // Footer: número de página a la derecha, fecha a la izquierda
                cb.BeginText();
                cb.SetFontAndSize(_bf, 9);
                cb.SetTextMatrix(document.Left, document.Bottom - 20);
                cb.ShowText($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}");
                cb.EndText();

                cb.BeginText();
                cb.SetFontAndSize(_bf, 9);
                cb.SetTextMatrix(document.Right - 100, document.Bottom - 20);
                cb.ShowText(footerText);
                cb.EndText();

                cb.AddTemplate(_totalPages, document.Right - 100 + len, document.Bottom - 20);
            }

            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                _totalPages.BeginText();
                _totalPages.SetFontAndSize(_bf, 9);
                _totalPages.SetTextMatrix(0, 0);
                _totalPages.ShowText($"{writer.PageNumber - 1}");
                _totalPages.EndText();
            }
        }

        public static void ExportarRecetaAPdf(string nombreReceta,string descripcion,string instrucciones,byte[] imagenReceta,List<string> ingredientes,string pais,string categoria,string dificultad,TimeSpan tiempoPreparacion)
        {
            try
            {
                // 📂 Crear carpeta de destino (Descargas o Escritorio)
                string carpetaDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string carpetaDestino = Directory.Exists(carpetaDescargas)
                    ? carpetaDescargas
                    : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RecetasPDF");

                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                string nombreArchivo = $"{SanitizarArchivo(nombreReceta)}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string rutaPdf = Path.Combine(carpetaDestino, nombreArchivo);

                using (var fs = new FileStream(rutaPdf, FileMode.Create, FileAccess.Write, FileShare.None))
                using (var doc = new Document(PageSize.A4, 50f, 50f, 60f, 50f))
                {
                    var writer = PdfWriter.GetInstance(doc, fs);
                    writer.PageEvent = new PdfHeaderFooter(nombreReceta);
                    doc.Open();

                    // 🎨 Fuentes y colores
                    BaseColor colorPrincipal = new BaseColor(240, 90, 40); // naranja suave
                    BaseColor colorSecundario = new BaseColor(80, 80, 80);
                    BaseColor colorFondo = new BaseColor(250, 250, 250);

                    var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, colorPrincipal);
                    var fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13, colorSecundario);
                    var fuenteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);
                    var fuenteIngrediente = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.DARK_GRAY);

                    // 🏷️ Título centrado
                    var titulo = new Paragraph(nombreReceta, fuenteTitulo)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 12f
                    };
                    doc.Add(titulo);

                    // 📋 Panel de información principal (categoría, país, dificultad, tiempo)
                    PdfPTable tablaInfo = new PdfPTable(2)
                    {
                        WidthPercentage = 90,
                        SpacingAfter = 12f
                    };
                    tablaInfo.DefaultCell.Border = Rectangle.NO_BORDER;
                    tablaInfo.SetWidths(new float[] { 1f, 1f });

                    void AddInfo(string label, string value)
                    {
                        var cellLabel = new PdfPCell(new Phrase(label + ":", fuenteSubtitulo))
                        {
                            Border = Rectangle.NO_BORDER,
                            PaddingBottom = 5f
                        };
                        var cellValue = new PdfPCell(new Phrase(value ?? "-", fuenteTexto))
                        {
                            Border = Rectangle.NO_BORDER,
                            PaddingBottom = 5f
                        };
                        tablaInfo.AddCell(cellLabel);
                        tablaInfo.AddCell(cellValue);
                    }

                    AddInfo("Categoría", categoria);
                    AddInfo("País", pais);
                    AddInfo("Dificultad", dificultad);
                    AddInfo("Tiempo de preparación", $"{tiempoPreparacion.TotalMinutes} minutos");

                    doc.Add(tablaInfo);

                    // 🖼️ Imagen centrada
                    if (imagenReceta != null && imagenReceta.Length > 0)
                    {
                        try
                        {
                            var img = iTextSharp.text.Image.GetInstance(imagenReceta);
                            img.Alignment = Element.ALIGN_CENTER;
                            img.ScaleToFit(400f, 300f);
                            img.SpacingAfter = 15f;
                            img.BorderWidth = 1f;
                            img.BorderColor = new BaseColor(200, 200, 200);
                            doc.Add(img);
                        }
                        catch
                        {
                            doc.Add(new Paragraph("(No se pudo cargar la imagen)", fuenteTexto) { Alignment = Element.ALIGN_CENTER });
                        }
                    }

                    // 🧾 Descripción con fondo gris claro
                    PdfPTable tablaDescripcion = new PdfPTable(1) { WidthPercentage = 90, SpacingAfter = 15f };
                    PdfPCell celdaDescTitulo = new PdfPCell(new Phrase("Descripción", fuenteSubtitulo))
                    {
                        BackgroundColor = new BaseColor(240, 240, 240),
                        Border = Rectangle.NO_BORDER,
                        Padding = 6f
                    };
                    PdfPCell celdaDescTexto = new PdfPCell(new Phrase(descripcion ?? "Sin descripción disponible.", fuenteTexto))
                    {
                        Border = Rectangle.NO_BORDER,
                        Padding = 8f
                    };
                    tablaDescripcion.AddCell(celdaDescTitulo);
                    tablaDescripcion.AddCell(celdaDescTexto);
                    doc.Add(tablaDescripcion);

                    // 🍽️ Ingredientes
                    doc.Add(new Paragraph("Ingredientes", fuenteSubtitulo) { SpacingAfter = 5f });
                    if (ingredientes != null && ingredientes.Count > 0)
                    {
                        var lista = new List(List.UNORDERED, 8f);
                        lista.SetListSymbol("• ");
                        foreach (var ing in ingredientes)
                            lista.Add(new ListItem(ing, fuenteIngrediente));
                        doc.Add(lista);
                    }
                    else
                    {
                        doc.Add(new Paragraph("No se registraron ingredientes.", fuenteTexto));
                    }

                    doc.Add(new Paragraph("\nInstrucciones", fuenteSubtitulo) { SpacingBefore = 10f, SpacingAfter = 5f });
                    doc.Add(new Paragraph(instrucciones ?? "Sin instrucciones.", fuenteTexto));

                    // 🧾 Línea divisoria y pie
                    var linea = new LineSeparator(1f, 100f, colorPrincipal, Element.ALIGN_CENTER, -2);
                    doc.Add(new Chunk(linea));
                    doc.Add(new Paragraph($"PDF generado el {DateTime.Now:dd/MM/yyyy HH:mm}", FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 9, BaseColor.GRAY))
                    {
                        Alignment = Element.ALIGN_RIGHT
                    });

                    doc.Close();
                }

                // ✅ Abrir el PDF al finalizar
                if (File.Exists(rutaPdf))
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = rutaPdf,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                    MessageBox.Show($"PDF generado correctamente:\n{rutaPdf}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar PDF de la receta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // HAY QUE PROBARLO

    }
}

