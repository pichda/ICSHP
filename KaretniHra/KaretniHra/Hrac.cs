using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaretniHra
{
    public class Hrac
    {
        // TODO: refactoring (pridani metody add, ...)

        public List<Karta> KartyVRuce { get; set; }
        public string Jmeno { get; set; }
        public bool JeHrac { get; set; }
        public Hrac(String jmeno, bool jeHrac)
        {
            KartyVRuce = new List<Karta>();
            Jmeno = jmeno;
            JeHrac = jeHrac;
        }

        public bool MaKartu(CisloKaret cisloKarty)
        {
            foreach (var karta in KartyVRuce)
            {
                if (karta.CisloKarty == cisloKarty)
                {
                    return true;
                }
            }
            return false;
        }

        public bool MaKartuAJeHratelna(CisloKaret cisloKarty, ZnakyKaret aktualniZnak)
        {
            foreach (var karta in KartyVRuce)
            {
                if (karta.CisloKarty == cisloKarty && karta.Znak ==aktualniZnak)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Vraci true, pokud hrac ma aspon jednu kartu, ktera neni svrsek, eso, sedma a lze zahrat
        /// </summary>
        /// <returns></returns>
        public bool MaNormalniKartu(Karta kartaNaPlose)
        {
            foreach (var karta in KartyVRuce)
            {
                if (karta.CisloKarty != CisloKaret.eso || karta.CisloKarty != CisloKaret.sedma || karta.CisloKarty != CisloKaret.svrsek)
                {
                    if(karta.CisloKarty == kartaNaPlose.CisloKarty || karta.Znak == kartaNaPlose.Znak)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MaNormalniKartu()
        {
            foreach (var karta in KartyVRuce)
            {
                if (karta.CisloKarty != CisloKaret.eso || karta.CisloKarty != CisloKaret.sedma || karta.CisloKarty != CisloKaret.svrsek)
                {
                    return true;
                }
            }
            return false;
        }


        public int DejPocetKaret()
        {
            return KartyVRuce.Count();
        }

        public void PridejKartuDoRuky(Karta karta)
        {
            if (JeHrac)
            {
                karta.JeHrace = true;
                karta.Image = Util.DejObrazekKarty(karta);
            }
            else
            {
                karta.JeHrace = false;
                karta.Image = Properties.Resources.zada;
            }
            KartyVRuce.Add(karta);
        }

        public void OdeberKartu(Karta karta)
        {
            karta.JeHrace = false;
            karta.Visible = false;
            KartyVRuce.Remove(karta);
        }

        public Karta DejPrvniNalezenouKartu(CisloKaret cisloKarty)
        {
            foreach (var karta in KartyVRuce)
            {
                if (karta.CisloKarty == cisloKarty)
                {
                    return karta;
                }
                
            }
                throw new ArgumentException();
        }
        public Karta DejPrvniKartu()
        {
            return KartyVRuce[0];
        }
        public Karta DejKartuNaIndexu(int index)
        {
            if (index > DejPocetKaret()-1)
            {
                throw new IndexOutOfRangeException();
            }
            return KartyVRuce[index];
        }
    }
}
