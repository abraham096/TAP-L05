using System;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5
{
    public partial class EVENTOS : Form
    {
        public EVENTOS()
        {
            InitializeComponent();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = false;
            ofd.FileName = string.Empty;
            ofd.Title = "Abrir Archivo";
            ofd.Filter = "Archivos de Texto|*.txt;*.csv";

            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string arch = File.ReadAllText(ofd.FileName); // Lee todas las líneas del archivo y las almacena en un string

                Console.WriteLine("####### ARCHIVO EN UN SOLO string #######\n\r\n\r" + arch);

                string[] lineas = File.ReadAllLines(ofd.FileName, Encoding.UTF8); // Lee línea por línea todo el archivo y las almacena en un array de tipo string

                int x = 0;
                Console.WriteLine("####### ARCHIVO LÍNEA POR LÍNEA #######");

                foreach (var item in lineas) // Definimos la variable como 'var' debido a que acepta cualquier Input
                    // Es necesario especificarle a qué arreglo ingresará, con la palabra reservada 'in'
                {
                    x++;
                    textBox5.Text = "Línea " + x + ": " + item + "\n\r";
                }
            }
        }

        private void EVENTOS_Load(object sender, EventArgs e)
        {
            textBox7.Text = "El KeyPress - Es cuando apenas presiono la tecla\n\r\n\rEl KeyDown - Es cuando la tecla, ya está abajo\n\r\n\rEl KeyUp es cuando suelto la tecla";
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ACCEDEMOS A LEER EL CÓDIGO DE LA TECLA PRESIONADA
            try
            {
                if (!char.IsDigit(e.KeyChar)) // VERIFICAMOS QUE SEA UN DÍGITO
                {
                    e.Handled = true; // PERMITIMOS SU ESCRITURA
                }
                else
                {
                    e.Handled = false; // ELIMINAMOS EL VALOR INGRESADO
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR KP: " + ex.Message);
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            textBox5.Text = string.Empty;
            textBox5.Text = e.KeyValue.ToString();
        }

        private void textBox9_KeyUp(object sender, KeyEventArgs e)
        {
            textBox5.Text = string.Empty;
            textBox5.Text = e.KeyCode.ToString();
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox4_MouseHover(object sender, EventArgs e)
        {
            label7.Visible = true;
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            validaNumero();
        }

        private void validaNumero()
        {
            if (!(textBox6.Text.Length > 4))
            {
                MessageBox.Show("La longitud no debe ser menor a 4 caracteres");
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            validaNumero();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(maskedTextBox1.Text);
        }
    }
}
