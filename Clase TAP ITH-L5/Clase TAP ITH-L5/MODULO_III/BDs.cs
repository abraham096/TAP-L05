using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5.MODULO_III
{
    public partial class BDs : Form
    {
        public BDs()
        {
            InitializeComponent();
        }

        private bool flag = false;
        Conexion con = new Conexion("tap-l05", "localhost");

        private void LimpiaDGV()
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void LlenaDGV(string sql)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, this.con.RegresarConexion());
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(new object[] { dr.GetUInt32(0), dr.GetString("Nombre"), dr.GetString("Correo"), dr.GetString("RFC") });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR LLENADO: " + ex.Message);
            }
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals(string.Empty) || textBox2.Text.Equals(string.Empty) || textBox3.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Llene todos los campos");
                }
                else
                {
                    /**
                     * PARA INSERTAR ALGÚN VALOR EN UNA TABLA, ES NECESARIO LO SIGUIENTE:
                     * 
                     * INSERT INTO Tabla(campo1,campo2,campo-n) VALUES(valor1, valor2, valorn);
                     * 
                     * INSERT INTO --> ES EL COMANDO DE INSERCIÓN
                     * Tabla --> Nombre de la tabla en donde se almacenarán los campos
                     * Campos --> Son los campos en donde se insertarán los valores deseados.
                     * Todos los valores son sensitivos, ya que no hacen diferencia entre String, Enteros, Fecha, Hora, etc.
                     */
                    string insercion = "INSERT INTO empleados(Nombre, Correo, RFC) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "');";

                    Console.WriteLine(insercion);

                    MySqlCommand cmd = new MySqlCommand(insercion, con.RegresarConexion());

                    MySqlDataReader myReader = cmd.ExecuteReader();
                    Console.WriteLine("Inserción Exitosa");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR DE INSERCIÓN: " + ex.Message);
            }
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            if (!this.flag)
            {
                this.flag = con.AbrirConexion();
                MessageBox.Show("La conexión, ha sido abierta");
            }
            else
            {
                this.flag = false;
                MessageBox.Show("La conexión, ha sido cerrada ;(");
            }
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            try
            {
                /**
                 * PROCEDIMIENTO PARA LEER LOS DATOS DE UNA TABLA
                 * 
                 * SELECT CAMPO(S) FROM Tabla WHERE Condicion;
                 * 
                 * SELECT --> Selecciona el dato, o los datos, que quiera obtener
                 * CAMPO(S) --> Puede ser uno, varios o todos los campos de una tabla específica
                 * FROM --> Indica la tabla desde donde buscará los campos
                 * WHERE --> Indica una condición en caso de ser necesario hacerlo
                 * Condición --> Especifica una condición lógica
                 */

                string leerTabla = "SELECT * FROM empleados;";
                //string leerTabla = "SELECT * FROM empleados WHERE RFC LIKE 'DURA830819FB9';";

                MySqlCommand cmd = new MySqlCommand(leerTabla, con.RegresarConexion());
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows) // VALIDAMOS QUE SE HAYA CREADO EL ARRAY
                {
                    /*
                    // POR LO GENERAL, SE UTILIZA CUANDO SE TRATA DE UNA CONSULTA SENCILLA
                    if (dr.Read())
                    {
                        cont++;
                        Console.WriteLine("IF\nLínea " + cont + "-> Nombre: " + dr.GetValue(0) + "\nRFC: " + dr.GetString(1) + "\nCorreo: " + dr.GetValue(2));
                    }
                    */

                    // POR LO GENERAL, SE UTILIZA CUANDO NECESITAMOS RECORRER TODA LA TABLA
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(new object[] { dr.GetUInt32(0), dr.GetString("Nombre"), dr.GetString("Correo"), dr.GetString("RFC") });
                    }
                }

                dr.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR en Lectura de Datos: " + ex.Message);
            }
        }

        private void BDs_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BDs_Load(object sender, EventArgs e)
        {
            LlenaDGV("SELECT * FROM empleados;");
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = dataGridView1.CurrentRow.Index;
                textBox1.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR DGV: " + ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals(string.Empty) || textBox2.Text.Equals(string.Empty) || textBox3.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Llene todos los campos");
                }
                else
                {
                    int index = dataGridView1.CurrentRow.Index;
                    object id = dataGridView1.Rows[index].Cells[0].Value;

                    if (index >= 0)
                    {
                        string actualizar = "UPDATE empleados SET Nombre = '" + textBox1.Text + "', Correo = '" + textBox2.Text + "', RFC = '" + textBox3.Text + "' WHERE idEmpleado = " + id + ";";

                        MySqlCommand cmd = new MySqlCommand(actualizar, this.con.RegresarConexion());
                        MySqlDataReader dr = cmd.ExecuteReader();

                        string msg = (dr.RecordsAffected > 0) ? "Actualización realizada con éxito" : "Algo salió mal en la actualización ;(";

                        MessageBox.Show(msg);

                        LimpiaDGV();
                        LlenaDGV("SELECT * FROM empleados;");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR UPDATE: " + ex.Message);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
