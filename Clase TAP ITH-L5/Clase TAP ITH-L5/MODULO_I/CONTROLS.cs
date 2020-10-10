using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5
{
    public partial class CONTROLS : Form
    {
        private MAIN _obj;
        private int op = 0;
        
        public CONTROLS()
        {
            InitializeComponent();
        }
        
        public CONTROLS(MAIN mAIN)
        {
            this._obj = mAIN;
            InitializeComponent();
        }

        private void CONTROLS_Load(object sender, EventArgs e)
        {
            timer1.Start();
            monthCalendar1.MaxDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now;

            object[] miLista = new object[] { "Merali", "Germán", "Gabriel", "Luis" };
            this.listBox1.Items.AddRange(miLista);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //SelectionRange sr = monthCalendar1.SelectionRange;
                MessageBox.Show(monthCalendar1.SelectionEnd.ToLongDateString());
            }
            else
            {
                MessageBox.Show(dateTimePicker1.Value.ToLongDateString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string nombre = string.Empty;

                switch (this.listBox1.SelectedIndex)
                {
                    case 0:
                        nombre = "Hola, soy " + this.listBox1.SelectedItem.ToString();
                        break;
                    case 1:
                        nombre = "¿Qué onda? Soy" + this.listBox1.SelectedItem.ToString();
                        break;
                }

                textBox1.Text += "\n\r\n\r" + nombre;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show(treeView1.SelectedNode.Text);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola humano, soy una máquina");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            //this._obj.Show();
        }

        private void cerrarVentanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this._obj.Show();
        }

        private void asignarFechaALabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
        }

        private void cambiarNombreALabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "¡Hola Mundo!";
        }

        private void opción1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1234");
        }

        private void opción2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡Buen fin de semana!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != string.Empty)
                {
                    double valor = 0;
                    string tbx = textBox2.Text;

                    switch (this.op)
                    {
                        case 1:
                            valor = Math.Sin(Double.Parse(tbx));
                            break;
                        case 2:
                            valor = Math.Asin(Double.Parse(tbx));
                            break;
                        case 3:
                            valor = Math.Sinh(Double.Parse(tbx));
                            break;
                        default:
                            break;
                    }

                    textBox3.Text += valor + "\n\r\n\r";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.op = 1;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.op = 2;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.op = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // Expresado en milisegundos
            toolStripStatusLabel3.Text = DateTime.Now.ToShortTimeString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string val = DateTime.Now.ToLongTimeString();
            string[] vals = val.Split(':');

            for (int i = 0; i < vals.Length; i++)
            {
                Console.WriteLine(vals[i]); // Recorro el arreglo contenido para ver su contenido
            }

            label2.Text = vals[2].Substring(0, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.FileName = string.Empty;
                sfd.Filter = "Archivos de Texto |*.txt, *.csv";
                sfd.Title = "Seleccione ubicación para guardado...";

                DialogResult dr = sfd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    //Console.WriteLine(saveFileDialog1.FileName);
                    File.WriteAllText(sfd.FileName, textBox3.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.FileName = string.Empty;
                ofd.Filter = "Archivos de Texto |*.txt;*.csv";
                ofd.Title = "Seleccione ubicación del archivo...";

                DialogResult dr = ofd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    string ruta = ofd.FileName;
                    //textBox1.Text = File.ReadAllText(ruta);

                    string[] lineas = File.ReadAllLines(ruta);

                    foreach (var item in lineas)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}
