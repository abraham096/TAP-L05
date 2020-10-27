using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5.MODULO_I
{
    public partial class OTROS_WF : Form
    {
        public OTROS_WF()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value += 2;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BTN1 IPB FOWF: " + ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value -= 10;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void ProgressBar1_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void ProgressBar1_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Status: " + checkBox2.Checked);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valor = Decimal.Parse("1.5");
                numericUpDown1.Value += (decimal) 1.5; // cast
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown1.Value -= (decimal)1.5;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OTROS_WF_Load(object sender, EventArgs e)
        {
        }

        private void TextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            string exp = @"[A-Z]{4}[\d]{6}[A-Z]{5}[A-Z0-9]{3}";
            Regex expr = new Regex(exp);
            bool flag = expr.IsMatch(textBox2.Text);

            label2.Visible = !flag;
            button5.Enabled = flag;
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            // EXPRESIONES REGULARES
            /**
             * +   Una o más coincidencias de un caracter
             * *   Ninguna o más coincidencias de un caracter
             * \w  Define una letra entre 0-9a-zA-Z
             * \d  Define un número entre 0 y 9
             * 0-9 Define un número entre 0 y 9
             * a-z Define una letra entre a-z
             * A-Z Define una letra entre A-Z
             * ?   Indica que un caracter puede estar o no estar
             * .   Indica que la expresión debe contener un punto
             * |   Es un operador de tipo OR
             * ()  Sólo sirve para realizar declaraciones
             * []  Se debe cumplir lo que esté contenido dentro 
             * {}  Especifica la cantidad de veces que un patrón debe coincidir, con base al número que contenga
             */
            // "DURA 030819 FB9"
            string expresion = @"[A-Z]{4}\d{6}[\w]{3}";
            //string expresion = @"\w{4}\d{6}[0-9A-Z]{3}";
            Regex expr = new Regex(expresion);
            bool flag = expr.IsMatch(textBox1.Text);

            Console.WriteLine(flag);
            label2.Visible = !flag;
            button5.Enabled = flag;
        }
    }
}
