using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Helpers;
using MicheBytesRecipes.Managers;
using MicheBytesRecipes.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Forms.AddReceta
{ 
    public partial class frmAgregarReceta : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        GestorCatalogo  gestorCatalogo = new GestorCatalogo();
        GestorIngredientes gestorIngredientes = new GestorIngredientes();
        public frmAgregarReceta(Usuario usuario)
        {
            InitializeComponent();
            this.FormClosed += (s, e) => GestorTemaAdmin.TemaCambiado -= ActualizarTema;


        }

        private void FrmAgregarReceta_Load(object sender, EventArgs e)
        {
            List<Ingrediente> ingredientes = gestorIngredientes.ObtenerIngredientes();
            clbIngredientes.DataSource = ingredientes;
            clbIngredientes.DisplayMember = "Nombre";
            clbIngredientes.ValueMember = "IngredienteId";
            List<Pais> paises = gestorCatalogo.ObtenerListaPaises();
            cboPais.DataSource = paises;
            cboPais.DisplayMember = "Nombre";
            cboPais.ValueMember = "PaisId";
            List<Categoria> categorias = gestorCatalogo.ObtenerListaCategorias();
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.SelectedIndex = 2;
            cboCategoria.ValueMember = "CategoriaId";
            cboDificultad.DataSource = Enum.GetValues(typeof(Dificultad));

            dtpTiempo.Format = DateTimePickerFormat.Custom;
            dtpTiempo.CustomFormat = "HH:mm:ss";
            dtpTiempo.ShowUpDown = true;
            dtpTiempo.Value = DateTime.Today.AddHours(1);
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
            btnCargar.Tag = "metricas";
        }

        //Botones 
        private void btnCargar_Click(object sender, EventArgs e)
        {
            //Crear una nueva receta
            Receta nuevaReceta = new Receta();
            if (Validaciones.ValidarReceta(txtNombre, txtDescripcion, txtInstrucciones, cboCategoria, cboPais, cboDificultad, dtpTiempo, pcbImagen, btnCargar, clbIngredientes, errorProvider1))
            {
                nuevaReceta.Nombre = Utilidades.CapitalizarPrimeraLetra(txtNombre.Text);
                nuevaReceta.Descripcion = txtDescripcion.Text;
                nuevaReceta.Instrucciones = txtInstrucciones.Text;
                nuevaReceta.TiempoPreparacion = dtpTiempo.Value.TimeOfDay;

                nuevaReceta.ImagenReceta = File.ReadAllBytes(openFileDialog1.FileName);// Imagen blob

                nuevaReceta.CategoriaId = Convert.ToInt32(cboCategoria.SelectedValue);
                nuevaReceta.PaisId = Convert.ToInt32(cboPais.SelectedValue);

                nuevaReceta.NivelDificultad = (Dificultad)cboDificultad.SelectedItem;

                nuevaReceta.UsuarioId = 1;

                nuevaReceta.FechaRegistro = DateTime.Now;

                //Obtener los IDs de los ingredientes seleccionados
                List<int> ingredientesIds = new List<int>();
                //Agregar los ingredientes seleccionados en el CheckedListBox a la receta
                foreach (Ingrediente ing in clbIngredientes.CheckedItems)
                {
                    ingredientesIds.Add(ing.IngredienteId);
                }

                //Guardar receta + ingrediente en un solo paso
                int recetaId = gestorReceta.AgregarReceta(nuevaReceta, ingredientesIds);

                if (recetaId > 0)
                {
                    MessageBox.Show("Receta cargada exitosamente");
                }

                LimpiarFormulario();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btnPais_Click(object sender, EventArgs e)
        {
            //Llamar al formulario de agregar pais
            frmAgregarPais frmAgregarPais = new frmAgregarPais();
            
            if(frmAgregarPais.ShowDialog() == DialogResult.OK)
            {
                List<Pais> paises = gestorCatalogo.ObtenerListaPaises();
                cboPais.DataSource = null; //Limpia el origen de datos
                cboPais.DataSource = paises; //Vuelve a asignar la lista actualizada
                cboPais.DisplayMember = "Nombre";
                //MessageBox.Show("Pais agregado a la lista.");
            }
        }
        private void btnAgregarIngrediente_Click(object sender, EventArgs e)
        {
            //llamAR AL FORMULARIO DE AGREGAR INGREDIENTE
            frmAgregarIngrediente frmAgregarIngrediente = new frmAgregarIngrediente();

            if (frmAgregarIngrediente.ShowDialog() == DialogResult.OK)
            {
                List<Ingrediente> ingredientes = gestorIngredientes.ObtenerIngredientes();
                clbIngredientes.DataSource = null; //Limpia el origen de datos
                clbIngredientes.DataSource = ingredientes; //Vuelve a asignar la lista actualizada
                clbIngredientes.DisplayMember = "Nombre"; 
                //MessageBox.Show("Ingrediente agregado a la receta.");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAgregarCategorias_Click(object sender, EventArgs e)
        {
            frmAgregarCategoria frmAgregarCategoria = new frmAgregarCategoria();
            if(frmAgregarCategoria.ShowDialog() == DialogResult.OK)
            {
                List<Categoria> categorias = gestorCatalogo.ObtenerListaCategorias();
                cboCategoria.DataSource = null;
                cboCategoria.DataSource = categorias;
                cboCategoria.DisplayMember = "Nombre";
            }
        }
        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Seleccionar Imagen";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pcbImagen.Image = Image.FromFile(openFileDialog1.FileName);
                pcbImagen.SizeMode = PictureBoxSizeMode.Zoom; //Ajusta la imagen al tamanio del PictureBox
            }
        }

        //metodo para limpiar el formulario
        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtInstrucciones.Clear();
            cboCategoria.SelectedIndex = 2;
            cboPais.SelectedIndex = 0;
            cboDificultad.SelectedIndex = 0;
            dtpTiempo.Value = DateTime.Today.AddHours(1);
            pcbImagen.Image = null;
            foreach (int i in clbIngredientes.CheckedIndices)
            {
                clbIngredientes.SetItemChecked(i, false);
            }
            errorProvider1.Clear();
        }


    }
}
                