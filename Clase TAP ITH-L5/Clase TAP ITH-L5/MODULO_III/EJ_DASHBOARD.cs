using System;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5.MODULO_III
{
    public partial class EJ_DASHBOARD : Form
    {
        public EJ_DASHBOARD()
        {
            InitializeComponent();
        }

        private void UserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarMenu(false);
        }

        private void AdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OcultarMenu(true);
        }

        private void OcultarMenu(bool op)
        {
            anualToolStripMenuItem.Visible = op;
            comprasToolStripMenuItem.Visible = op;
            mensualToolStripMenuItem.Visible = op;
            empleadosToolStripMenuItem.Visible = op;
        }
    }
}
