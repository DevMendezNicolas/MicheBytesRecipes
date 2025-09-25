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

            this.Hide(); // Oculta el formulario Inicio

            frmLogin login = new frmLogin();
            login.ShowDialog(); // Abre Login como modal

            //this.Show(); // Se ejecuta después de cerrar Login
            //this.Activate(); // Recupera el foco

        }

        private void BtnCrearCuenta_Click(object sender, EventArgs e)
        {

            FrmRegister register = new FrmRegister();
            register.Show();
            this.Hide();

        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {

        }

        
    }
}
