using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Managers;
using MicheBytesRecipes.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.AddReceta
{
    public partial class frmModificarReceta : Form
    {
        private Receta receta;
        private Usuario usuarioLog;
        private string nuevaRuta = string.Empty; // Variable para almacenar la nueva ruta de la imagen
        GestorReceta gestorReceta = new GestorReceta();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();
        GestorIngredientes gestorIngredientes = new GestorIngredientes();


        public frmModificarReceta(Receta receta, Usuario usuarioLog)
        {
            InitializeComponent();
            this.receta = receta;
            this.usuarioLog = usuarioLog;
            this.FormClosed += (s, e) => GestorTemaAdmin.TemaCambiado -= ActualizarTema;

        }
        private void FrmModificarReceta_Load(object sender, EventArgs e)
        {
            dtpTiempo.Format = DateTimePickerFormat.Custom;
            dtpTiempo.CustomFormat = "HH:mm:ss";
            dtpTiempo.ShowUpDown = true;
            CargarControles();
            if (receta != null)
            {
                CargarDatosReceta();
            }
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtInstrucciones.ScrollBars = ScrollBars.Vertical;

            AsignarTags();
            GestorTemaAdmin.AplicarTema(this);

        }
        public void ActualizarTema()
        {
            GestorTemaAdmin.AplicarTema(this);
            this.Refresh();
        }

        private void AsignarTags()
        {
            btnImagen.Tag = "importar";
            btnCancelar.Tag = "cerrar";
            btnModificar.Tag = "metricas";
        }
        private void CargarDatosReceta()
        {
            if (receta != null)
            {
                txtNombre.Text = receta.Nombre;
                txtDescripcion.Text = receta.Descripcion;
                txtInstrucciones.Text = receta.Instrucciones;
                dtpTiempo.Value = DateTime.Today.Add(receta.TiempoPreparacion);

                cboPais.SelectedValue = receta.PaisId;
                cboCategoria.SelectedValue = receta.CategoriaId;
                cboDificultad.SelectedItem = receta.NivelDificultad;

                if (receta.ImagenReceta != null && receta.ImagenReceta.Length > 0)
                {
                    using (var ms = new MemoryStream(receta.ImagenReceta))
                    {
                        pcbImagen.Image = Image.FromStream(ms);
                        pcbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pcbImagen.Image = null;
                }
            }
            MarcarIngredientesSeleccionados(); // Marcar los ingredientes seleccionados en el CheckedListBox
        }
        private void MarcarIngredientesSeleccionados() //Para la documentacion este metodo fue creado con la ayuda de ChatGPT
        {
            if (receta.Ingredientes == null) return;

            //Obtenemos los ID de los ingredientes de la receta
            var ingredientesRecetaIds = new HashSet<int>(receta.Ingredientes.Select(i => i.IngredienteId)); // HashSet para busquedas rapidas

            //Recorremos los items del CheckedListBox y marcamos los que estan en la receta
            for (int i = 0; i < clbIngredientes.Items.Count; i++)
            {
                // Obtenemos el ingrediente del item actual
                var ingrediente = (Ingrediente)clbIngredientes.Items[i];
                // Si el ID del ingrediente esta en la lista de la receta, lo marcamos
                if (ingredientesRecetaIds.Contains(ingrediente.IngredienteId))
                {
                    clbIngredientes.SetItemChecked(i, true);
                }
            }
        }

        public void CargarControles()
        {
            //Cargar ComboBox Paises
            cboPais.DataSource = gestorCatalogo.ObtenerListaPaises();
            cboPais.DisplayMember = "Nombre"; //Propiedad que se muestra en el ComboBox
            cboPais.ValueMember = "PaisId"; //Propiedad que se usa como valor (Id)

            //Cargar ComboBox Categorias
            cboCategoria.DataSource = gestorCatalogo.ObtenerListaCategorias();
            cboCategoria.DisplayMember = "Nombre"; //Propiedad que se muestra en el ComboBox
            cboCategoria.ValueMember = "CategoriaId"; //Propiedad que se usa como valor (Id)

            // Cargar ComboBox de Dificultad
            cboDificultad.DataSource = Enum.GetValues(typeof(Dificultad));

            // Cargar CheckedListBox de Ingredientes
            var todosLosIngredientes = gestorIngredientes.ObtenerIngredientes();
            clbIngredientes.DataSource = todosLosIngredientes;
            clbIngredientes.DisplayMember = "Nombre";
            clbIngredientes.ValueMember = "IngredienteId";
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Validaciones.ValidarReceta(txtNombre, txtDescripcion, txtInstrucciones, cboCategoria, cboPais, cboDificultad, dtpTiempo, pcbImagen, btnModificar, clbIngredientes, errorProvider1))
            {
                GuardarCambios();
            }
        }
       
        private void GuardarCambios()
        {
            try
            {
                receta.Nombre = txtNombre.Text.Trim();
                receta.Descripcion = txtDescripcion.Text.Trim();
                receta.Instrucciones = txtInstrucciones.Text.Trim();
                receta.TiempoPreparacion = dtpTiempo.Value.TimeOfDay;

                receta.PaisId = (int)cboPais.SelectedValue;
                receta.CategoriaId = (int)cboCategoria.SelectedValue;
                receta.NivelDificultad = (Dificultad)cboDificultad.SelectedItem;

                // Imagen solo si cambio
                if (pcbImagen.Image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var bmpTemp = new Bitmap(pcbImagen.Image))
                        {
                            bmpTemp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        }

                        receta.ImagenReceta = ms.ToArray();
                    }
                }
                else
                {
                    receta.ImagenReceta = null;
                }

                // Actualizar ingredientes seleccionados
                var ingredientesSeleccionados = clbIngredientes.CheckedItems.Cast<Ingrediente>().Select(i => i.IngredienteId).ToList();

                // Llamar al gestor para actualizar la receta en la base de datos
                bool exito = gestorReceta.ModificarReceta(receta, ingredientesSeleccionados, usuarioLog.UsuarioId);

                if (exito)
                {
                    MessageBox.Show("Receta modificada exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al modificar la receta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnImagen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Seleccionar Imagen";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pcbImagen.Image = Image.FromFile(openFileDialog1.FileName);
                pcbImagen.SizeMode = PictureBoxSizeMode.Zoom; //Ajusta la imagen al tamanio del PictureBox
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPais_Click(object sender, EventArgs e)
        {                        
            frmAgregarPais frmAgregarPais = new frmAgregarPais();

            if (frmAgregarPais.ShowDialog() == DialogResult.OK)
            {
                List<Pais> paises = gestorCatalogo.ObtenerListaPaises();
                cboPais.DataSource = null; //Limpia el origen de datos
                cboPais.DataSource = paises; //Vuelve a asignar la lista actualizada
                cboPais.DisplayMember = "Nombre";
            }
        }

        private void btnAgregarCategorias_Click(object sender, EventArgs e)
        {
            frmAgregarCategoria frmAgregarCategoria = new frmAgregarCategoria();
            if (frmAgregarCategoria.ShowDialog() == DialogResult.OK)
            {
                List<Categoria> categorias = gestorCatalogo.ObtenerListaCategorias();
                cboCategoria.DataSource = null;
                cboCategoria.DataSource = categorias;
                cboCategoria.DisplayMember = "Nombre";
            }
        }

        private void btnAgregarIngrediente_Click(object sender, EventArgs e)
        {
            frmAgregarIngrediente frmAgregarIngrediente = new frmAgregarIngrediente();

            if (frmAgregarIngrediente.ShowDialog() == DialogResult.OK)
            {
                List<Ingrediente> ingredientes = gestorIngredientes.ObtenerIngredientes();
                clbIngredientes.DataSource = null; //Limpia el origen de datos
                clbIngredientes.DataSource = ingredientes; //Vuelve a asignar la lista actualizada
                clbIngredientes.DisplayMember = "Nombre";
            }
        }
    }
    
}
