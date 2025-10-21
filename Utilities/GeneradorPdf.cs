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
 
                    // 🏷️ TÍTULO CENTRADO CON LÍNEA DECORATIVA
                    var titulo = new Paragraph(nombreReceta.ToUpper(), fuenteTitulo)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 6f
                    };
                    doc.Add(titulo);

                    // Línea decorativa debajo del título
                    var lineaTitulo = new LineSeparator(1f, 40f, colorPrincipal, Element.ALIGN_CENTER, -2);
                    doc.Add(new Chunk(lineaTitulo));

                    // 📋 PANEL DE INFORMACIÓN PRINCIPAL
                    PdfPTable tablaInfo = new PdfPTable(2)
                    {
                        WidthPercentage = 85,
                        SpacingBefore = 15f,
                        SpacingAfter = 15f
                    };
                    tablaInfo.SetWidths(new float[] { 1f, 1f });

                    // Fondo suave y bordes redondeados simulados con padding
                    BaseColor fondoInfo = new BaseColor(255, 247, 240); // color crema suave

                    // 🧩 Función para agregar filas estilizadas
                    void AddInfo(string emoji, string label, string value)
                    {
                        var cellLabel = new PdfPCell(new Phrase($"{emoji} {label.ToUpper()}", fuenteSubtitulo))
                        {
                            Border = Rectangle.NO_BORDER,
                            BackgroundColor = fondoInfo,
                            Padding = 6f,
                            PaddingLeft = 10f
                        };

                        var cellValue = new PdfPCell(new Phrase(value ?? "-", fuenteTexto))
                        {
                            Border = Rectangle.NO_BORDER,
                            BackgroundColor = fondoInfo,
                            Padding = 6f,
                            PaddingLeft = 10f
                        };

                        tablaInfo.AddCell(cellLabel);
                        tablaInfo.AddCell(cellValue);
                    }

                    // Agregar información con íconos
                    AddInfo("📂", "Categoría", categoria);
                    AddInfo("🌎", "País", pais);
                    AddInfo("⚙️", "Dificultad", dificultad);
                    AddInfo("⏱️", "Tiempo de preparación", $"{tiempoPreparacion.TotalMinutes} minutos");

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

                    // 🧾 BLOQUE DE DESCRIPCIÓN CON ESTILO TARJETA
                    PdfPTable tablaDescripcion = new PdfPTable(1)
                    {
                        WidthPercentage = 85,
                        SpacingBefore = 10f,
                        SpacingAfter = 20f
                    };

                    // Colores suaves coherentes con el diseño general
                    BaseColor fondoDescripcion = new BaseColor(255, 250, 245); // color cálido
                    BaseColor bordeDescripcion = new BaseColor(240, 90, 40);   // naranja principal

                    // 📄 Título de la sección
                    PdfPCell celdaTitulo = new PdfPCell(new Phrase("🧾 DESCRIPCIÓN", fuenteSubtitulo))
                    {
                        BackgroundColor = bordeDescripcion,
                        Border = Rectangle.NO_BORDER,
                        Padding = 8f,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    celdaTitulo.Phrase.Font.Color = BaseColor.WHITE; // Texto blanco sobre fondo naranja

                    // 📃 Texto descriptivo
                    PdfPCell celdaTexto = new PdfPCell(new Phrase(descripcion ?? "Sin descripción disponible.", fuenteTexto))
                    {
                        BorderColor = bordeDescripcion,
                        BackgroundColor = fondoDescripcion,
                        BorderWidth = 1f,
                        Padding = 10f,
                    };

                    tablaDescripcion.AddCell(celdaTitulo);
                    tablaDescripcion.AddCell(celdaTexto);
                    doc.Add(tablaDescripcion);


                    // 🍽️ Ingredientes (versión estética mejorada)
                    doc.Add(new Paragraph("\nIngredientes", fuenteSubtitulo)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingBefore = 10f,
                        SpacingAfter = 10f
                    });

                    if (ingredientes != null && ingredientes.Count > 0)
                    {
                        // Creamos tabla con 2 columnas para mejor disposición visual
                        PdfPTable tablaIngredientes = new PdfPTable(2)
                        {
                            WidthPercentage = 90,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            SpacingAfter = 15f
                        };
                        tablaIngredientes.DefaultCell.Border = Rectangle.NO_BORDER;
                        tablaIngredientes.SetWidths(new float[] { 0.05f, 0.95f });

                        // Estilo base
                        BaseColor colorFondoIngrediente = new BaseColor(250, 245, 240);
                        BaseColor colorBorde = new BaseColor(230, 230, 230);
                        var fuenteIngredienteNegrita = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);

                        foreach (var ing in ingredientes)
                        {
                            // Viñeta o ícono tipo punto naranja
                            PdfPCell cellIcono = new PdfPCell(new Phrase("•", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD, new BaseColor(240, 90, 40))))
                            {
                                Border = Rectangle.NO_BORDER,
                                VerticalAlignment = Element.ALIGN_MIDDLE,
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                PaddingTop = 3f,
                                PaddingBottom = 3f
                            };

                            // Nombre del ingrediente con fondo suave
                            PdfPCell cellTexto = new PdfPCell(new Phrase(ing, fuenteIngredienteNegrita))
                            {
                                BackgroundColor = colorFondoIngrediente,
                                BorderColor = colorBorde,
                                BorderWidth = 0.5f,
                                Padding = 8f,
                                VerticalAlignment = Element.ALIGN_MIDDLE,
                                MinimumHeight = 25f
                            };

                            tablaIngredientes.AddCell(cellIcono);
                            tablaIngredientes.AddCell(cellTexto);
                        }

                        doc.Add(tablaIngredientes);
                    }
                    else
                    {
                        var sinIngredientes = new Paragraph("No se registraron ingredientes.", fuenteTexto)
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 10f
                        };
                        doc.Add(sinIngredientes);
                    }


                    //doc.Add(new Paragraph("\nInstrucciones", fuenteSubtitulo) { SpacingBefore = 10f, SpacingAfter = 5f });
                    //doc.Add(new Paragraph(instrucciones ?? "Sin instrucciones.", fuenteTexto));
                    // 🍳 BLOQUE DE INSTRUCCIONES CON ESTILO TARJETA
                    PdfPTable tablaInstrucciones = new PdfPTable(1)
                    {
                        WidthPercentage = 85,
                        SpacingBefore = 10f,
                        SpacingAfter = 15f
                    };

                    BaseColor fondoInstrucciones = new BaseColor(255, 255, 250); // fondo cálido claro
                    BaseColor bordeInstrucciones = new BaseColor(240, 90, 40);   // naranja principal

                    // 🔹 Título con fondo naranja
                    PdfPCell celdaTituloInstr = new PdfPCell(new Phrase("🍳 INSTRUCCIONES", fuenteSubtitulo))
                    {
                        BackgroundColor = bordeInstrucciones,
                        Border = Rectangle.NO_BORDER,
                        Padding = 8f,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    celdaTituloInstr.Phrase.Font.Color = BaseColor.WHITE;

                    // 📖 Texto de las instrucciones
                    PdfPCell celdaTextoInstr = new PdfPCell(new Phrase(instrucciones ?? "Sin instrucciones disponibles.", fuenteTexto))
                    {
                        BorderColor = bordeInstrucciones,
                        BackgroundColor = fondoInstrucciones,
                        BorderWidth = 1f,
                        Padding = 10f,
                        HorizontalAlignment = Element.ALIGN_JUSTIFIED
                    };

                    tablaInstrucciones.AddCell(celdaTituloInstr);
                    tablaInstrucciones.AddCell(celdaTextoInstr);

                    doc.Add(tablaInstrucciones);


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

