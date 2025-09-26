using MicheBytesRecipes.Classes.Recetas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MicheBytesRecipes
{
    internal static class Validaciones
    {
        public static bool ValidarReceta(TextBox txtNombre, TextBox txtDescripcion, TextBox txtInstrucciones, ComboBox cboCategoria, ComboBox cboPais, ComboBox cboDificultad, DateTimePicker dtpTiempo, string imagenPath, Button cmdCargarImagen, CheckedListBox clbIngrediente, ErrorProvider errorProvider)
        {
            // Validar que los campos no esten vacios
            bool esValido = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "Debe ingresar un nombre.");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errorProvider.SetError(txtDescripcion, "Debe ingresar una descripcion.");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtInstrucciones.Text))
            {
                errorProvider.SetError(txtInstrucciones, "Debe ingresar instrucciones.");
                esValido = false;
            }
            if (cboCategoria.SelectedIndex == -1)
            {
                errorProvider.SetError(cboCategoria, "Debe seleccionar una categoria.");
                esValido = false;
            }
            if (cboPais.SelectedIndex == -1)
            {
                errorProvider.SetError(cboPais, "Debe seleccionar un pais.");
                esValido = false;
            }
            if (cboDificultad.SelectedIndex == -1)
            {
                errorProvider.SetError(cboDificultad, "Debe seleccionar una dificultad.");
                esValido = false;
            }
            if (dtpTiempo.Value.TimeOfDay.TotalMinutes < 1)
            {
                errorProvider.SetError(dtpTiempo, "El tiempo de preparacion debe ser mayor a 0 minutos.");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(imagenPath) || !File.Exists(imagenPath))
            {
                errorProvider.SetError(cmdCargarImagen, "Debe seleccionar una imagen.");
                esValido = false;
            }
            else
            {
                try
                {
                    using (var img = Image.FromFile(imagenPath)) { }
                }
                catch
                {
                    errorProvider.SetError(cmdCargarImagen, "El archivo seleccionado no es una imagen valida.");
                    esValido = false;
                }
                
            }
            if(clbIngrediente.CheckedItems.Count == 0)
            {
                errorProvider.SetError(clbIngrediente, "Debe agregar al menos un ingrediente.");
                esValido = false;
            }
            return esValido;
        }
        public static bool ValidarIngrediente(TextBox txtNombre, ComboBox cboTipo, ComboBox cboMedida, ErrorProvider errorProvider)
        {
            bool esValido = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "Debe ingresar un nombre.");
                esValido = false;
            }
            if (cboTipo.SelectedIndex == -1)
            {
                errorProvider.SetError(cboTipo, "Debe seleccionar un tipo de origen.");
                esValido = false;
            }
            if(cboMedida.SelectedIndex == -1)
            {
                errorProvider.SetError(cboMedida, "Debe seleccionar una unidad de medida.");
                esValido = false;
            }
            return esValido;
        }
        public static bool ValidarPais(TextBox txtPais, ErrorProvider errorProvider)
        {
            bool esValido = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtPais.Text))
            {
                errorProvider.SetError(txtPais, "Debe ingresar un nombre de pais.");
                esValido = false;
            }
            return esValido;
        }
        public static bool ValidarCategoria(TextBox txtNombre, TextBox txtdescripcion, ErrorProvider errorProvider)
        {
            bool esValido = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "Debe ingresar un nombre");
                esValido = false;
            }
            return esValido;
        }
    }
    
}

