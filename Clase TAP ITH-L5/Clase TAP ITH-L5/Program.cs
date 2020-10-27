using System;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new CONTROLS());
            Application.Run(new MODULO_I.DGV_CTABs());
        }
    }
}
