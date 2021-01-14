using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;

namespace Clase_TAP_ITH_L5.MODULO_III
{
    public partial class EJ_CONEXION : Form
    {
        public EJ_CONEXION()
        {
            InitializeComponent();
        }
        
        private bool flag;
        private string id;
        private Stuff stuff;
        private Conexion con;

        private void LlenaDGV()
        {
            try
            {
                LinkedList<string> lista = con.EjecutaQueryLL("SELECT * FROM empleados WHERE statusEmpleado = 1 ORDER BY Nombre;");

                foreach (var item in lista)
                {
                    string[] vals = item.ToString().Split('#');

                    dataGridView1.Rows.Add(new object[] { vals[0], vals[1], vals[2], vals[3] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void LimpiarForma()
        {
            this.flag = false;
            stuff.LimpiarForm(groupBox1);
            stuff.LimpiarForm(groupBox2);

            LlenaDGV();
            button1.Text = "Guardar Empleado";
        }

        private void EjecutarQuery(string sql)
        {
            if (con.AbrirConexion())
            {
                if (con.EjecutaQuery(sql))
                {
                    LimpiarForma();

                    MessageBox.Show(this, "Todas las operaciones fueron realizadas exitósamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Ocurrió un error al momento de ejecutar la operación\nValide los datos que ingresó", "Error de Inserción", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Conexión fallida");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(string.Empty) || textBox2.Text.Equals(string.Empty) || textBox3.Text.Equals(string.Empty))
            {
                MessageBox.Show("Llene todos los campos");
            }
            else
            {
                string sql = (this.flag) ? "UPDATE empleados SET Nombre = '" + textBox1.Text + "', Correo = '" + textBox2.Text + "', RFC = '" + textBox3.Text + "' WHERE idEmpleado = " + this.id : "INSERT INTO empleados(Nombre, Correo, RFC) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";

                EjecutarQuery(sql);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Al realizar ésta operación, el empleado será dado de baja\n\n¿Está seguro de continuar?", "¡Atención!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                string sql = "UPDATE empleados SET statusEmpleado = 0 WHERE idEmpleado = " + this.id;

                EjecutarQuery(sql);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Al realizar ésta operación, el empleado será eliminado DEFINITVAMENTE\n\n¿Está seguro de continuar?", "¡Atención!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                string sql = "DELETE empleados WHERE idEmpleado = " + this.id;
                EjecutarQuery(sql);
            }
        }

        private void EJ_CONEXION_Load(object sender, EventArgs e)
        {
            stuff = new Stuff();
            con = new Conexion("tap-l05", "localhost");

            //LlenaDGV();
            try
            {
                var flag = con.RegresarConexion(); // flag --> Es una bandera

                if (flag == null)
                {
                    // MENSAJE DE FALTA DE CONEXIÓN  / CONEXIÓN NO REALIZADA
                    MessageBox.Show("Conexión no establecida");
                }
                else
                {
                    DataTable dt = con.RegresaDT("SELECT * FROM empleados;");
                    dataGridView1.DataSource = dt;

                    dt.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR LOAD: " + ex.Message);
            }
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                this.flag = true;
                button1.Text = "Modificar Datos";
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR DGV: " + ex.Message);
            }
        }
    }
}