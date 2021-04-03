using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaretniHra
{
    public class Karta : PictureBox
    {
        public ZnakyKaret Znak { get; set; }
        public CisloKaret CisloKarty { get; set; }
        public bool JeHrace { get; set; }

        public Karta(ZnakyKaret znak, CisloKaret cisloKarty)
        {
            this.Height = 150;
            this.Width = 100;
            this.Visible = true;
            JeHrace = false;
            this.Znak = znak;
            this.CisloKarty = cisloKarty;
            this.Image = Properties.Resources.zada;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }
}
