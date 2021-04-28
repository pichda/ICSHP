using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LigaMistru
{
    public partial class Form1 : Form
    {
        public Hraci hraci = new Hraci();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// zavrit formular tlacitko
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// vytvorit hrace tlacitko
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FormHrac fHrac = new FormHrac(this,false);
            fHrac.Show();
        }
        /// <summary>
        /// Odstranit hrace tlacitko
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                hraci.Vymaz(row.Index);
                dataGridView1.Rows.RemoveAt(row.Index);
            }
        }

        /// <summary>
        /// Upravit tlacitko
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (hraci.Pocet > 0 && dataGridView1.SelectedRows.Count > 0)
            {
                FormHrac fHrac = new FormHrac(this, true);
                fHrac.Show();
            }
        }
        /// <summary>
        /// zobraz nejlepsi kluby tlacitko
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (hraci.Pocet > 0 && dataGridView1.SelectedRows.Count > 0)
            {
                FormNejlepsiKluby fNejlepsiKluby = new FormNejlepsiKluby(this);
                fNejlepsiKluby.Show();
            }
        }
    }
}
