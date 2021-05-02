using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KaretniHra
{
    [Serializable]
    public class Karta
    {
        public ZnakyKaret Znak { get; set; }
        public CisloKaret CisloKarty { get; set; }
        public bool JeHrace { get; set; }

        public Karta(ZnakyKaret znak, CisloKaret cisloKarty)
        {
            JeHrace = false;
            this.Znak = znak;
            this.CisloKarty = cisloKarty;
        }
    }
}
