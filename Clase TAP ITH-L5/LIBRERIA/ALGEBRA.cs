/**
 * IMPORTAMOS LAS LIBRERÍAS QUE ESTÁN EN EL DIRECTORIO 'REFERENCES'
 */
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LIBRERIA
{
    public class ALGEBRA
    {
        public string Hola()
        {
            return "Hola Mundo";
        }

        public double Suma(double x, double y)
        {
            return x + y;
        }

        public double Resta(double x, double y)
        {
            return x - y;
        }

        public double Producto(double x, double y)
        {
            return x * y;
        }

        public double Division(double x, double y)
        {
            return x / y;
        }

        public void Droids(string ruta, TextBox tbx)
        {
            try
            {
                string exp = @"TC-[0-9]{2}";
                string exp2 = @"[0-9|A-Z]{2}-3PO";
                string lineas = File.ReadAllText(ruta);

                Regex reg = new Regex(exp);
                MatchCollection coincidencias = reg.Matches(lineas);

                if (coincidencias.Count > 0)
                {
                    tbx.Text += "ANDROIDES DE LA SERIE '3PO' ENCONTRADOS: " + coincidencias.Count;

                    foreach (var item in coincidencias)
                    {
                        tbx.Text += item + "\r\n";
                    }

                    reg = new Regex(exp2);
                    coincidencias = reg.Matches(lineas);

                    tbx.Text += "ANDROIDES DE LA SERIE 'TC-XZ' ENCONTRADOS: " + coincidencias.Count;

                    foreach (var item in coincidencias)
                    {
                        tbx.Text += item + "\r\n";
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
