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
using MaterialSkin;
using MaterialSkin.Controls;

namespace MicheBytesRecipes
{
    public partial class Inicio : MaterialForm
    {
        public Inicio()
        {
            InitializeComponent();
            GestorGrafico.AplicarTema(this);

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

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
