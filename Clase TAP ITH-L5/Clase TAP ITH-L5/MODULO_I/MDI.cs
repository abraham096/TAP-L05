using System;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5.MODULO_I
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        MAIN _main;
        Form[] _obj;
        EVENTOS _evento;
        CONTROLS _controles;

        // EVENTOS PROPIOS

        internal void FinalizaMDI(int op)
        {
            _obj[op].Dispose();
        }

        private void InicializaMDI(Form f)
        {
            f.MdiParent = this;
            f.Show();
        }

        // ACTIONS DEL MENUBAR

        private void CerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "¿Desea cerrar la sesión?", "Pregunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                this.Hide();
                _main.Show();
            }
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "¿Desea cerrar el programa?", "¡Atención!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _main = new MAIN();
            _obj[_obj.Length] = _main;

            InicializaMDI(_main);
        }

        private void EventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _evento = new EVENTOS();
            _obj[_obj.Length] = _evento;

            InicializaMDI(_evento);
        }

        private void ControelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controles = new CONTROLS();
            _obj[_obj.Length] = _controles;

            InicializaMDI(_controles);
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _obj = new Form[] { };
        }
    }
}
