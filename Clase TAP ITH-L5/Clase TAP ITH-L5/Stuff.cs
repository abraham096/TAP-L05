using System;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5
{
    public class Stuff
    {
        public void LimpiarForm(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox tbx)
                {
                    tbx.Text = string.Empty;
                }
                else if (control is ComboBox cbx)
                {
                    cbx.SelectedIndex = 0;
                }
                else if (control is CheckBox chbx)
                {
                    chbx.Checked = false;
                }
                else if (control is ListBox lbx)
                {
                    lbx.ClearSelected();
                }
                else if (control is DataGridView dgv)
                {
                    dgv.Rows.Clear();
                    dgv.Refresh();
                }
                else if (control is RichTextBox rtbx)
                {
                    rtbx.Text = string.Empty;
                }
                else if (control is NumericUpDown nud)
                {
                    nud.Value = (decimal) 0;
                }
                else if (control is DateTimePicker dtp)
                {
                    dtp.Value = DateTime.Now;
                }
                else if (control is ProgressBar pbx)
                {
                    pbx.Value = 0;
                }
                else if (control is MaskedTextBox mtbx)
                {
                    mtbx.Text = string.Empty;
                }
            }
        }
    }
}