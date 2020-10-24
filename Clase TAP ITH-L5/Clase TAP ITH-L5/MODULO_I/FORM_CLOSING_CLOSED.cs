using System;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5.MODULO_I
{
    public partial class FORM_CLOSING_CLOSED : Form
    {
        private bool flag;

        public FORM_CLOSING_CLOSED()
        {
            InitializeComponent();
        }

        public bool Flag { get => flag; set => flag = value; }

        internal void FORM_CLOSING_CLOSED_Load(object sender, EventArgs e)
        {
            Flag = false;
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Flag = (textBox1.Text != string.Empty) ? true : false;
            button1.Enabled = Flag;
        }

        private void FORM_CLOSING_CLOSED_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Flag)
            {
                DialogResult dr = MessageBox.Show(this, "Está a punto de cerrar la ventana sin haber guardado los cambios\n\r\n\r¿Está seguro de hacerlo?", "¡Atención!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.No || dr == DialogResult.Cancel)
                {
                    e.Cancel = false; // e.Cancel me define el action que tomará el Form previo a cerrarse
                }
                else
                {
                    new MAIN().Visible = true;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "¿Desea ver el mensaje?", "Pregunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                button1.Enabled = true;
                MessageBox.Show("Hola Grupo L55!");
            }
            else
            {
                Flag = false;
                Console.WriteLine(dr);
            }
        }

        private void FORM_CLOSING_CLOSED_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "¿Desea cerrar definitivamente el programa o volver al MAIN?\n\r\n\rYes - Cierra el Programa DEFINITIVAMENTE\r\nNo - Regresar al MAIN", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                new MAIN().Visible = true; // Suponiendo que quiero que me regrese al MAIN
            }
        }
    }
}
