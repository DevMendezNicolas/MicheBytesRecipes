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

namespace MicheBytesRecipes
{
    public partial class Inicio : Form
    {
        private const string json_path = @"Data/inicioContenido.json";
        public Inicio()
        {
            InitializeComponent();

            //Redondeo de botones y paneles
            UiHelpers.SetRoundedButton(BtnIniciar, 25);
            UiHelpers.SetRoundedButton(BtnCrearCuenta, 25);
            ThemeManager.AplicarTema(this);
            UiHelpers.SetGradient(this, Color.FromArgb(0, 10, 20), Color.FromArgb(40, 70, 100), System.Drawing.Drawing2D.LinearGradientMode.Vertical);


            // Aplicar tema inicial
            ThemeManager.AplicarTema(this);

            // Cargar contenido JSON con manejo inteligente de temas
            CargarJson.CargarLabels(PanelMid, json_path);

            // Suscribirse al cambio de tema


        }
        // Dirige al login
        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //var frmLogin = new frmLogin();
            //frmLogin.FormClosed += (s, args) => this.Show(); // Vuelve a mostrar frmInicio si se cierra frmLogin
            //frmLogin.Show();
            var login = new frmLogin();
            login.Owner = this; // importante
            this.Hide();
            login.Show();

        }

        private void BtnCrearCuenta_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //var frmRegistro = new FrmRegister();
            //frmRegistro.FormClosed += (s, args) => this.Show(); // Vuelve a mostrar frmInicio si se cierra frmRegistro
            //frmRegistro.Show();
            var register = new FrmRegister();
            register.Owner = this;
            this.Hide();
            register.Show();

        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {

        }


        private void btnTheme_Click(object sender, EventArgs e)
        {
            if (!ThemeManager.EsTemaOscuro)
            {
                ThemeManager.CambiarTema();
                ThemeManager.AplicarTema(this);
                CargarJson.CargarLabels(PanelMid, json_path);
            }
            else
            {
                //Utilizar tema claro   
                ThemeManager.CambiarTema();
                ThemeManager.AplicarTema(this);
            }

            

        }

    }
}
