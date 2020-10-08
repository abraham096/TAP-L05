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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string nombre = "SIITH - ";


        /** ^_^ EVENTOS DE LA CLASE ^_^  **/

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label3.Text = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = nombre + textBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            this.Text = nombre + "Pantalla Principal";
        }

        private void tabControl1_MouseHover(object sender, EventArgs e)
        {
            this.Text = nombre + "Pasaste el mouse por encima del TabControl";
        }
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            bool b = (textBox2.Text != textBox3.Text) ? true : false;

            label4.Visible = b;
            button1.Enabled = !b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Habilitar(false, null);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar(true, radioButton1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar(true, radioButton2);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar(true, radioButton3);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            HabilitaBtn(true);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            HabilitaBtn(false);
        }

        /** ^_^ MÉTODOS PROPIOS DE LA CLASE ^_^  **/

        private void Habilitar(bool v, RadioButton rb)
        {
            textBox1.ReadOnly = v;
            textBox1.Multiline = v;

            /*
             * ScrollBars ---> Es un objeto que define las barras de navegación del Objeto al que pertenezca
             * sc ---> Es el nombre con que se le asigna al objeto anterior
             * (v) ---> Indica una condición de tipo IF
             *  ? Como es una condición, devolverá el valor que cumpla con la condición
             *  : ---> El primero, devuelve un valor cualquiera, en caso de que sea TRUE. Y, bisceversa
             */
            ScrollBars sb = (v) ? ScrollBars.Both : ScrollBars.None;
            
            textBox1.ScrollBars = sb;

            if (rb != null)
            {
                textBox1.Text = nombre + "Hoy es " + DateTime.Now.Day + " y es de \n\r\n\r" + rb.Text;
            }
        }

        private void HabilitaBtn(bool v)
        {
            button1.Enabled = v;
        }
    }

    public class Ejemplo
    {
        public Ejemplo()
        {
            // 
        }
    }
}

