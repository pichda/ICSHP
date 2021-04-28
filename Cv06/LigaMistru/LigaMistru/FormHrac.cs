using System;
using System.Drawing;
using System.Windows.Forms;

namespace LigaMistru
{
    public partial class FormHrac : Form
    {
        public Form1 f1;
        public bool jeUprava;

        private DataGridViewRow selectedRow;

        private FotbalovyKlubInfo fkInfo = new FotbalovyKlubInfo();

        public FormHrac(Form1 f1, bool jeUprava)
        {
            InitializeComponent();
            this.f1 = f1;
            this.jeUprava = jeUprava;
            comboBox1.Items.AddRange(fkInfo.NazvyKlubu);

            if (jeUprava)
            {
                textBox1.Text = f1.dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); // jmeno hrace
                comboBox1.SelectedIndex = comboBox1.FindStringExact(f1.dataGridView1.SelectedRows[0].Cells[1].Value.ToString());  // klub
                textBox2.Text = f1.dataGridView1.SelectedRows[0].Cells[2].Value.ToString(); // goly

                selectedRow = f1.dataGridView1.SelectedRows[0]; // prevence proti uživateli, který může změnit označený řádek a
                //pak by se upravil jiny objekt v poli, jelikož se využívá selectedRow.Index
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.Red;
            }
            else if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.Red;
            }
            else if (comboBox1.SelectedItem == null)
            {
                comboBox1.BackColor = Color.Red;
            }
            else
            {
                int goly = Int32.Parse(textBox2.Text);
                String jmeno = textBox1.Text;
                FotbalovyKlub klub = fkInfo.DejKlub(comboBox1.GetItemText(comboBox1.SelectedItem));

                if (jeUprava)
                {
                    f1.dataGridView1.Rows[selectedRow.Index].Selected = true;

                    f1.hraci.Uprav(selectedRow.Index, jmeno, goly, klub);

                    f1.dataGridView1.SelectedRows[0].Cells[0].Value = jmeno;
                    f1.dataGridView1.SelectedRows[0].Cells[1].Value = fkInfo.DejNazev(klub);
                    f1.dataGridView1.SelectedRows[0].Cells[2].Value = goly;
                }
                else
                {
                    Hrac hrac = new Hrac(jmeno, klub, goly);

                    f1.hraci.Pridej(hrac);
                    f1.dataGridView1.Rows.Add(new object[] { hrac.Jmeno, fkInfo.DejNazev(hrac.Klub), hrac.GolPocet });
                }

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// kontrola nepovolených znaků pro góly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}