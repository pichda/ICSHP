using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaMistru
{
    class Hrac
    {
        public string Jmeno { get; set; }
        public FotbalovyKlub Klub { get; set; }
        public int GolPocet { get; set; }

        public Hrac(string jmeno, FotbalovyKlub klub, int golPocet)
        {
            Jmeno = jmeno;
            Klub = klub;
            GolPocet = golPocet;
        }

    }
}
