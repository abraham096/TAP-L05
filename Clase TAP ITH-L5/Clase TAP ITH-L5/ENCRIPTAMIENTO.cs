using System;
using System.IO;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5.MODULO_III
{
    public partial class ENCRIPTAMIENTO : Form
    {
        public ENCRIPTAMIENTO()
        {
            InitializeComponent();
        }

        private CifrarCadena encrypt;
        private string passPhrase = "TAP L05";

        private void Button1_Click(object sender, EventArgs e)
        {
            string cadena = textBox1.Text;
            textBox2.Text = encrypt.Encrypt(cadena, passPhrase);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string cadena = textBox2.Text;
            textBox1.Text = encrypt.Decrypt(cadena, passPhrase);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.Filter = "Archivos de Texto|*.txt";
            openFileDialog1.Title = "Seleccione el archivo a Encriptar";

            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                try
                {
                    AddEncryption(openFileDialog1.FileName);
                    textBox3.Text = File.ReadAllText(@openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("EXCEPTION ON File Encrypt Load: " + ex.Message);
                }
            }

            openFileDialog1.Dispose();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.Filter = "Archivos de Texto|*.txt";
            openFileDialog1.Title = "Seleccione el archivo a Desencriptar";

            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                try
                {
                    RemoveEncryption(openFileDialog1.FileName);
                    textBox3.Text = File.ReadAllText(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("EXCEPTION ON File Decrypt Load: " + ex.Message);
                }
            }

            openFileDialog1.Dispose();
        }

        // Encrypt a file.
        public static void AddEncryption(string FileName)
        {

            File.Encrypt(FileName);
        }

        // Decrypt a file.
        public static void RemoveEncryption(string FileName)
        {
            File.Decrypt(FileName);
        }
        private void ENCRIPTAMIENTO_Load(object sender, EventArgs e)
        {
            this.encrypt = new CifrarCadena();
        }
    }
}
