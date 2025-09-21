using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicheBytesRecipes.Helpers
{
    public class CueProvider
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        public static void SetCue(TextBox control, string cueText)
        {
            const int EM_SETCUEBANNER = 0x1501;
            SendMessage(control.Handle, EM_SETCUEBANNER, 0, cueText);
            
        }

    }
}
