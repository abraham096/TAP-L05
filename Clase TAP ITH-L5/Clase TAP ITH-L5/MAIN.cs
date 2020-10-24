using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5
{
    public partial class MAIN : Form
    {
        public MAIN()
        {
            InitializeComponent();
        }

        private void MAIN_Load(object sender, EventArgs e)
        {
            comboBox2.Sorted = true; // Muestra la lista ordenada
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = comboBox1.Text;
            MessageBox.Show(null, msg, "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CONTROLS ctrl = new CONTROLS(); // Tú lo puedes manipular
            //new CONTROLS().Visible = true; // Se utiliza una sola vez

            using (ctrl)
            {
                ctrl.Show();
                this.Hide();
            }

            /*
            int op = comboBox2.SelectedIndex;
            //MessageBox.Show(op.ToString());
            Console.WriteLine("SELECCIONASTE: " + op);

            try
            {
                switch (op)
                {
                    case 0:
                        new CONTROLS(this).Visible = true;
                        Console.WriteLine(comboBox2.SelectedItem.ToString());
                        break;
                    case 1:
                        new Form1().Visible = true;
                        Console.WriteLine(comboBox2.SelectedItem.ToString());
                        break;
                    default:
                        new Módulo_I.SPLASH().Visible = true;
                        Console.WriteLine(comboBox2.SelectedItem.ToString());
                        break;
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            */
        }
    }
}
