using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;




namespace MicheBytesRecipes
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmHome());
            //Application.Run(new Inicio());
            //Application.Run(new frmLogin());
            //Application.Run(new frmMenuAdmin());
            //Application.Run(new Forms.AddReceta.FrmAgregarReceta());
            Application.Run(new Forms.Auth.FrmRegister());
        }
    }
}
