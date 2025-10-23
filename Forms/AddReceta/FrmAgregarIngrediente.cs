using MicheBytesRecipes.Classes;
using MicheBytesRecipes.Connections;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MicheBytesRecipes.Utilities;
using MicheBytesRecipes.Managers;

namespace MicheBytesRecipes.Forms.AddReceta
{
    public partial class FrmAgregarIngrediente : Form
    {
        GestorReceta gestorReceta = new GestorReceta();
        GestorIngredientes gestorIngredientes = new GestorIngredientes();
        GestorCatalogo gestorCatalogo = new GestorCatalogo();

        public FrmAgregarIngrediente()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validaciones.ValidarIngrediente(txtIngrediente, cboUnidad, cboTipo, errorProvider1))
            {
                Ingrediente nuevoIngrediente = new Ingrediente
                {
                    Nombre = Utilidades.CapitalizarPrimeraLetra(txtIngrediente.Text),
                    Unidad = (UnidadMedida)cboUnidad.SelectedItem,
                    Tipo = (TipoIngrediente)cboTipo.SelectedItem
                };

                gestorIngredientes.AgregarIngrediente(nuevoIngrediente);

                this.DialogResult = DialogResult.OK; //Cerrar el formulario con resultado OK
                this.Close();
            }

        }

        private void FrmAgregarIngrediente_Load(object sender, EventArgs e)
        {
            

            //Cargar las unidades de medida y tipos de ingredientes en los ComboBox
            var listaUnidades = gestorCatalogo.ObtenerListaUnidades();
            var listaTipos = gestorCatalogo.ObtenerListaTipos();

            CargarCombos(cboUnidad, listaUnidades, "Nombre", "UnidadMedidaId", "No se pudieron cargar las unidades de medida.");           
            CargarCombos(cboTipo, listaTipos, "Nombre", "TipoIngredienteId", "No se pudieron cargar los tipos de ingredientes.");

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarCombos<T>(ComboBox combo, List<T> lista, string displayMember, string valueMember, string mensajeError)
        //Uso una lista generica para poder reutilizar el metodo
        {
            if (lista != null && lista.Count > 0)
            {
                combo.DataSource = lista; //Asigno la lista al DataSource del ComboBox
                combo.DisplayMember = displayMember;//Propiedad que se muestra en el ComboBox
                //combo.ValueMember = valueMember; //Propiedad que se usa como valor (Id)
                combo.SelectedIndex = 0; //Selecciono el primer elemento por defecto
            }else
            {
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
