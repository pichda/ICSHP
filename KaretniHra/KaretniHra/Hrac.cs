using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaretniHra
{
    public class Hrac
    {
        public List<Karta> KartyVRuce { get; set; }

        public Hrac()
        {
            KartyVRuce = new List<Karta>();
        }

    }
}
