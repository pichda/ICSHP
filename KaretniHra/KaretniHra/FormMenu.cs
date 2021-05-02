using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaretniHra
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("save.bin", FileMode.Open, FileAccess.Read);

                Hra ulozenaHra = (Hra)formatter.Deserialize(stream);

                if (ulozenaHra != null)
                {
                    this.Hide();
                    Form1 formHra = new Form1(this, ulozenaHra);
                    formHra.Show();
                }
            }
            catch
            {

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 formHra = new Form1(this);
            formHra.Show();
        }
    }
}
