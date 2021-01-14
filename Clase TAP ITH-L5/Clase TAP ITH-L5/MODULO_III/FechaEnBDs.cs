using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5.MODULO_III
{
    public partial class FechaEnBDs : Form
    {
        public FechaEnBDs()
        {
            InitializeComponent();
        }

        private Conexion con;

        private void Button1_Click(object sender, EventArgs e)
        {
            bool flag = this.con.AbrirConexion();
            DateTime fecha = dateTimePicker1.Value;

            if (flag)
            {
                string sql = "INSERT INTO Ejemplo(fecha) VALUES('" + fecha.ToString("yyyy-MM-dd H:mm:ss") + "');";

                Console.WriteLine(sql);
                bool status = con.EjecutaQuery(sql);

                if (status)
                {
                    llenaTBx();
                }
                else
                {
                    MessageBox.Show("Error en la inserción");
                }
            }
             else
            {
                MessageBox.Show("Conexión no establecida");
            }
        }

        private void llenaTBx()
        {
            bool flag = this.con.AbrirConexion();

            if (flag)
            {
                string sql = "SELECT * FROM Ejemplo;";

                /**
                 * PARA EL CASO DE QUE NECESITEMOS REGRESAR Y RECORRER UN DataTable
                DataTable dt = con.RegresaDT(sql);

                foreach (DataRow fila in dt.Rows)
                {
                    foreach (DataColumn columna in dt.Columns)
                    {
                        textBox1.Text += fila[columna].ToString() + "\r\n";
                    }
                }
                */

                try
                {
                    string[] vals = con.regresaValores(sql);
                    
                    foreach (var item in vals)
                    {
                        textBox1.Text += item + "\r\n";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("###: " + ex.Message);
                }
            }
        }

        private void FechaEnBDs_Load(object sender, EventArgs e)
        {
            this.con = new Conexion("tap-l05", "localhost");
            llenaTBx();
        }
    }
}
