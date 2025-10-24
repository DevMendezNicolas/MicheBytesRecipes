using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicheBytesRecipes.Forms.Auth;
using MicheBytesRecipes.Helpers;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using Newtonsoft.Json;
using MicheBytesRecipes.Utilities;
using System.Windows.Media.Media3D;
using MaterialSkin;
using MaterialSkin.Controls;
using MicheBytesRecipes.Gestores;


namespace MicheBytesRecipes
{
    public partial class frmInicio : MaterialSkin.Controls.MaterialForm
    {
        private const string json_path = @"DatosJson/inicioContenido.json";
        public frmInicio()
        {
            InitializeComponent();

            GestorMaterialSkin.TemaClaro(this);

            CargarJson.CargarLabelsDesdeJson(PanelMid, json_path);

        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            var login = new frmLogin();
            login.Owner = this; // importante
            this.Hide();
            login.Show();

        }

        private void BtnCrearCuenta_Click(object sender, EventArgs e)
        {
            var register = new frmRegistrar();
            register.Owner = this;
            this.Hide();
            register.Show();

        }

        private void lblBullet_Click(object sender, EventArgs e)
        {

        }
    }
}
