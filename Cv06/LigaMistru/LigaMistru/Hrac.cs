using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaMistru
{
    public class Hrac
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
        public Hrac()
        {
            Jmeno = "";
            Klub = FotbalovyKlub.None;
            GolPocet = 0;
        }

        public override string ToString()
        {
            return $"{Jmeno};{Klub};{GolPocet}";
        }

        public override bool Equals(object obj)
        {
            return obj is Hrac hrac &&
                   Jmeno == hrac.Jmeno &&
                   Klub == hrac.Klub &&
                   GolPocet == hrac.GolPocet;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
