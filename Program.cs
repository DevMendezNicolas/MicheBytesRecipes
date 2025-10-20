using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicheBytesRecipes.Forms.Auth;





namespace MicheBytesRecipes
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inicio());
            //Application.Run(new frmLogin());
            //Application.Run(new Forms.Admin.GestionUsuarios());
            //Application.Run(new frmMenuAdmin());

            //Application.Run(new Forms.AddReceta.FrmAgregarReceta());
            //Application.Run(new Forms.Auth.FrmRegister());
            //Application.Run(new Forms.Admin.frmBuscarUsuario());
            

        }
    }
}
