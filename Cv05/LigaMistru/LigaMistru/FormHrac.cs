using System;
using System.Drawing;
using System.Windows.Forms;

namespace LigaMistru
{
    public partial class FormHrac : Form
    {
        public Form1 f1;

        FotbalovyKlubInfo fkInfo = new FotbalovyKlubInfo();

        public FormHrac(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
            comboBox1.Items.AddRange(fkInfo.NazvyKlubu);
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
                Hrac hrac = new Hrac(textBox1.Text,
                    fkInfo.DejKlub(comboBox1.GetItemText(comboBox1.SelectedItem))
                    ,Int32.Parse(textBox2.Text));
                
                f1.hraci.Pridej(hrac);
                f1.dataGridView1.Rows.Add(new object[] { hrac.Jmeno, hrac.Klub, hrac.GolPocet });

                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}