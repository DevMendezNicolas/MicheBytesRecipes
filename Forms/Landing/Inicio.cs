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

namespace MicheBytesRecipes
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            //Redondeo de botones y paneles
            UiHelpers.SetRoundedButton(BtnIniciar, 25);
            UiHelpers.SetRoundedButton(BtnCrearCuenta, 25);

            //Aplicación del tema y color gradiente
            ThemeManager.ApplyTheme(this);
            UiHelpers.SetGradient(this, Color.FromArgb(0, 10, 20), Color.FromArgb(10, 30, 50), System.Drawing.Drawing2D.LinearGradientMode.Vertical);
        }
        // Dirige al login
        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //var frmLogin = new frmLogin();
            //frmLogin.FormClosed += (s, args) => this.Show(); // Vuelve a mostrar frmInicio si se cierra frmLogin
            //frmLogin.Show();
            frmLogin login = new frmLogin();
            login.Owner = this; // importante
            login.Show();
            this.Hide();

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

        
    }
}
