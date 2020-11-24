using System;
using LIBRERIA;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace Clase_TAP_ITH_L5.MODULO_II
{
    public partial class DROID : Form
    {
        public DROID()
        {
            InitializeComponent();
        }

        private ALGEBRA droid;
        private Thread proceso = null;
        private ThreadStart _subProcSec = null;

        private void DROID_Load(object sender, EventArgs e)
        {
            this._subProcSec = new ThreadStart(ProcesoSecundario_I);
        }

        private void CorrerHilo()
        {
            Thread.Sleep(9000); // TIEMPO EN Mili Segundos
            Console.WriteLine("MENSAJE: ¡Hola chicos!!");
            Console.WriteLine("EL HILO, HA TERMINADO");
        }

        private void ProcesoSecundario_I()
        {
            try
            {
                double cont = 0;
                
                for (int i = 0; i < 30; i++)
                {
                    Thread.Sleep(500); // Esperaremos medio segundo para que inice la siguiente transacción

                    cont += 0.5;
                    Console.WriteLine("Contador: " + cont);
                }

                MessageBox.Show("Hemos terminado =)");
            }
            catch (Exception)
            {
                //
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string ruta = Path.Combine(Environment.CurrentDirectory, @"MODULO_II\", "droids.txt");

            this.droid = new ALGEBRA();
            this.droid.Droids(ruta, textBox1);
        }

        [Obsolete]
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // FORMA PARA INICIALIZAR UN HILO
                // Creamos algo que se llama "delegado" que es, básicamente, un apuntador hacia una dirección en la memoria
                ThreadStart delegado = new ThreadStart(CorrerHilo);

                // Ahora sí, se crea la instancia del Hilo que acabamos de especificar
                Thread _hiloSecundario = new Thread(delegado)
                {
                    // Le asigno un nombre para Identificarlo
                    Name = "Clase TAP-L05"
                };

                // Como ya está creada la Instancia de mi Hilo, ahora, lo inicializo
                _hiloSecundario.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                // INTERRUMPE EL PROCESO ESPECIFICADO
                this.proceso.Suspend();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string texto = "LÍNEA 1\r\nLÍNEA 2\r\nLÍNEA 3";
            string[] lineas = texto.Split('\n');

            foreach (var item in lineas)
            {
                textBox1.Text += "\r\n" + item + "\r\n";
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                // INICIAMOS EL DELEGADO O SUBPROCESO _subProcSec
                this.proceso = new Thread(this._subProcSec)
                {
                    Name = "Mi Proceso Secundario"
                };

                proceso.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                // REANUDA EL PROCESO ESPECIFICADO
                this.proceso.Resume();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                // ABORTA EL PROCESO ESPECIFICADO
                this.proceso.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void DROID_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
