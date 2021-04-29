using System;
using System.IO;
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
            FormHrac fHrac = new FormHrac(this, false);
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
            if (hraci.Size() > 0 && dataGridView1.SelectedRows.Count > 0)
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
            if (hraci.Size() > 0 && dataGridView1.SelectedRows.Count > 0)
            {
                FormNejlepsiKluby fNejlepsiKluby = new FormNejlepsiKluby(this);
                fNejlepsiKluby.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files (.txt)| *.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string line = "";
                FotbalovyKlubInfo fkInfo = new FotbalovyKlubInfo();

                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        // ulozeni v poradi $"{Jmeno};{Klub};{GolPocet}";
                        var parametryHrace = line.Split(';');

                        try
                        {
                            Hrac novyHrac = new Hrac(parametryHrace[0], (FotbalovyKlub)Enum.Parse(typeof(FotbalovyKlub), parametryHrace[1]), Convert.ToInt32(parametryHrace[2]));
                            hraci.Pridej(novyHrac);
                            dataGridView1.Rows.Add(new object[] { novyHrac.Jmeno, fkInfo.DejNazev(novyHrac.Klub), novyHrac.GolPocet });
                        }
                        catch (Exception)
                        {
                            throw new IOException("Tento soubor nelze nacist.");
                        }
                        
                    }
                   
                }
                sr.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (hraci.Size() > 0)
            {
                FormUlozeniHracu fUlozeni = new FormUlozeniHracu(this);
                fUlozeni.Show();
            }
        }
    }
}