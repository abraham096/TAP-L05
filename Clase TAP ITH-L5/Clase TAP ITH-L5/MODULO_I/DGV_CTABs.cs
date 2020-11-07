using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_TAP_ITH_L5.MODULO_I
{
    public partial class DGV_CTABs : Form
    {
        public DGV_CTABs()
        {
            InitializeComponent();
        }

        private void DGV_CTABs_Load(object sender, EventArgs e)
        {
            try
            {
                object[] lista = new object[] { "Jaime Maussan", "56", "40" };
                dataGridView1.Rows.Add(lista);

                dataGridView1.Rows.Add();
                dataGridView1.Rows[1].Cells[0].Value = "Guilerlmo Prádes";
                dataGridView1.Rows[1].Cells[1].Value = "68";
                dataGridView1.Rows[1].Cells[2].Value = "6";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                if (dataGridView1.CurrentCell.ColumnIndex < 2)
                {
                    tabControl1.SelectTab(0);
                }
                else
                {
                    tabControl1.SelectTab(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();
                tsmi.Text = tabControl1.SelectedTab.Text;

                mENÚToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmi });

                mENÚToolStripMenuItem.DropDownItems.RemoveAt(0);
            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}
