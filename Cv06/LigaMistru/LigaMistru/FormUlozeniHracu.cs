using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LigaMistru
{
    public partial class FormUlozeniHracu : Form
    {
        public Form1 f1;
        public FormUlozeniHracu(Form1 form1)
        {
            InitializeComponent();
            f1 = form1;
            listView1.View = View.List;

            String[] kluby = Enum.GetNames(typeof(FotbalovyKlub));

            for (int i = 0; i < kluby.Length; i++)
            {
                listView1.Items.Add(kluby[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Hrac[] hraci = f1.hraci.DejVybraneHrace(listView1.SelectedIndices.Cast<int>().ToArray());

                saveFileDialog1.Filter = "Text Files (.txt)| *.txt";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Stream s = File.Create(saveFileDialog1.FileName);
                    StreamWriter sw = new StreamWriter(s);

                    foreach (var item in hraci)
                    {
                        sw.WriteLine(item);
                    }
                    sw.Close();
                    s.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
