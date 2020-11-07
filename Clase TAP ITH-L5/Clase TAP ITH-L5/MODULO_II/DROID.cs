using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5.MODULO_II
{
    public partial class DROID : Form
    {
        public DROID()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Texto|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string exp = @"TC-[0-9]{2}";
                    string exp2 = @"[0-9|A-Z]{2}-3PO";
                    string lineas = File.ReadAllText(ofd.FileName);
                    
                    Regex reg = new Regex(exp);
                    MatchCollection coincidencias = reg.Matches(lineas);

                    if (coincidencias.Count > 0)
                    {
                        textBox1.Text += "ANDROIDES DE LA SERIE '3PO' ENCONTRADOS: " + coincidencias.Count;

                        foreach (var item in coincidencias)
                        {
                            textBox1.Text += item + "\r\n";
                        }

                        reg = new Regex(exp2);
                        coincidencias = reg.Matches(lineas);

                        textBox1.Text += "ANDROIDES DE LA SERIE 'TC-XZ' ENCONTRADOS: " + coincidencias.Count;

                        foreach (var item in coincidencias)
                        {
                            textBox1.Text += item + "\r\n";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: "+  ex.Message);
                }
            }

            ofd.Dispose();
        }
    }
}
