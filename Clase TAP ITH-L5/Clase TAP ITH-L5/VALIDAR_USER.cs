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
    public partial class VALIDAR_USER : Form
    {
        public VALIDAR_USER()
        {
            InitializeComponent();

            this.claseCifrado = new CifrarCadena();
        }

        private CifrarCadena claseCifrado;
        private string passPhrase = "¿Qué onda con el Sindicato del ITH?";


        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string passwd = textBox2.Text;

            if (user.Equals(string.Empty) || passwd.Equals(string.Empty))
            {
                MessageBox.Show("Por favor, ingrese todos los datos");
            }
            else
            {
                // VALIDAR LOS DATOS DEL USUARIO, CON BASE A LO QUE ALMACENÓ EN LA TABLA DE Usuarios

                // CIERRE DEL SEMESTRE 26 de enero

                string claveAdmin = "nBgAAZWy7ZOIRAqc6iNHS+AziMfmMsqo6pujtCoRv7L1t5GZ3KPHHLbsytmi9+tSx5OMN0VCCT70vJIfoS3Y79IJ/EEgrbBw0WHygZv03VuPWowXsdMiRzHHFQjiBbV+"; // SUPONIENDO QUE ÉSTA ES LA CADENA QUE EXTRAIGO DE UNA LIBRERÍA, O BIEN, DESDE LA BD's
                
                // hashing en erspecial ARGON2ID
                string cadenaDesencriptada = this.claseCifrado.Decrypt(claveAdmin, this.passPhrase);

                if (user.Equals("admin") && passwd.Equals(cadenaDesencriptada))
                {
                    cadenaDesencriptada = string.Empty;
                    MessageBox.Show("Has ingresado al Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
