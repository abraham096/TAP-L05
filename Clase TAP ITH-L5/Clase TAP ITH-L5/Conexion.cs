using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Clase_TAP_ITH_L5.MODULO_III
{
    class Conexion
    {
        public Conexion(string db, string server)
        {
            // CONSTRUCTOR DE LA CLASE
            this.bd = db;
            this.servidor = server;
        }

        // ATRIBUTOS DE LA CONEXIÓN
        private string passwd = "";
        private string usuario = "root";
        private string bd = string.Empty;
        private MySqlConnection con = null;
        private string servidor = string.Empty;
        private bool Conectar()
        {
            bool flag = true;

            try
            {
                string conexion = "datasource=" + this.servidor + ";username=" + this.usuario + ";password=" + this.passwd + ";database=" + this.bd + ";";

                con = new MySqlConnection()
                {
                    ConnectionString = conexion
                };

                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR AL ABRIR LA CONEXIÓN: " + ex.Message);
                flag = false;
            }

            return flag;
        }

        internal bool AbrirConexion()
        {
            return this.Conectar();
        }

        internal int PrevenirSQLInjection()
        {
            int rows = 0;

            try
            {
                string sql = @"INSERT INTO empleados([nombreEmpleado], [correoEmpleado], [RFC]) VALUES(@nombre, @correo, @rfc);";

                if (this.Conectar())
                {
                    MySqlCommand cmd = new MySqlCommand(sql, this.con);
                    cmd.Parameters.AddWithValue("@nombre", "Felipe Ferras Gómez");
                    cmd.Parameters.AddWithValue("@correo", "felipe@ferras.com");
                    cmd.Parameters.AddWithValue("@rfc", "FEGA123456GMO");

                    rows = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR en SQLInjection: " + ex.Message);
            }

            return rows;
        }

        /**
         * ÉSTE MÉTODO, ES EXLUSIVO PARA EJECUTAR DELETE Y ALTER
         */
        internal bool EjecutaQuery(string sql)
        {
            bool flag = true;

            try
            {
                if (this.AbrirConexion())
                {
                    // CREAMOS EL OBJETO QUE NOS PERMITIRÁ EJECUATAR LAS INSTRUCCIONES QUE RECIBE
                    MySqlCommand cmd = new MySqlCommand(sql, this.con);

                    // EJECUTAMOS EL COMANDO ANTERIOR
                    /*
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    */
                    
                    // USE mysql; UPDATE users SET passwordUser = '' WHERE 1 > 0;
                    int status = cmd.ExecuteNonQuery();
                    Console.WriteLine("FILAS AFECTADAS: {0}", status);
                }
            }
            catch (Exception ex)
            {
                flag = false;
                Console.WriteLine("ERROR Ejecutar Query: " + ex.Message);
            }

            return flag;
        }

        internal DataTable RegresaDT(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                if (Conectar())
                {
                    MySqlCommand cmd = new MySqlCommand(sql, this.con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    da.Dispose();
                    this.con.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR DT: " + ex.Message);
            }

            return dt;
        }

        internal MySqlConnection RegresarConexion()
        {
            AbrirConexion();
            return this.con;
        }

        /**
         * ÉSTE MÉTODO, ES EXCLUSIVO PARA CUANDO REQUIERES QUE RETORNE VALOR
         */
        internal LinkedList<string> EjecutaQueryLL(string sql)
        {
            LinkedList<string> valores = new LinkedList<string>();

            try
            {
                if (this.AbrirConexion())
                {
                    // CREAMOS EL OBJETO QUE NOS PERMITIRÁ EJECUATAR LAS INSTRUCCIONES QUE RECIBE
                    MySqlCommand cmd = new MySqlCommand(sql, this.con);

                    // EJECUTAMOS EL COMANDO ANTERIOR
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        string valor = dr.GetValue(0) + "#" + dr.GetString("Nombre") + "#" + dr.GetString("Correo") + "#" + dr.GetString("RFC");

                        valores.AddLast(valor);
                    }

                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR Ejecutar Query: " + ex.Message);
            }

            return valores;
        }
    }
}
