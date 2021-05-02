using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaretniHra
{
    public class PictureBoxKarta : PictureBox
    {
        public PictureBoxKarta()
        {
            this.Height = 150;
            this.Width = 100;
            this.Visible = true;
            this.Image = Properties.Resources.zada;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
