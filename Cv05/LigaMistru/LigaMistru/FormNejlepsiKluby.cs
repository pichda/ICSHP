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
    public partial class FormNejlepsiKluby : Form
    {
        public Form1 f1;

        FotbalovyKlubInfo fkInfo = new FotbalovyKlubInfo();
        public FormNejlepsiKluby(Form1 form1)
        {
            InitializeComponent();

            f1 = form1;
            f1.hraci.NajdiNejlepsiKluby(out string kluby, out int maxGoly);

            textBox2.Text = maxGoly.ToString();
            textBox1.Lines = kluby.Split(';');

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
