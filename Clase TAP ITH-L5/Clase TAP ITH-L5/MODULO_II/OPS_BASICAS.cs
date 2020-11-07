using System;
using LIBRERIA;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5.MODULO_II
{
    public partial class OPS_BASICAS : Form
    {
        public OPS_BASICAS()
        {
            InitializeComponent();
        }

        private ALGEBRA operaciones;

        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                try
                {
                    this.operaciones = new ALGEBRA();
                    double a = Double.Parse(textBox1.Text);
                    double b = Double.Parse(textBox2.Text);

                    if (radioButton1.Checked)
                    {
                        textBox3.Text = this.operaciones.Suma(a, b).ToString();
                    }
                    else if (radioButton2.Checked)
                    {
                        textBox3.Text = this.operaciones.Resta(a, b).ToString();
                    }
                    else if (radioButton3.Checked)
                    {
                        textBox3.Text = this.operaciones.Producto(a, b).ToString();
                    }
                    else if (radioButton4.Checked)
                    {
                        textBox3.Text = this.operaciones.Division(a, b).ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
            }
        }
    }
}
