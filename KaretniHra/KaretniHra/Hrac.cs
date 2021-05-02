using System;
using System.Collections.Generic;
using System.Linq;

namespace KaretniHra
{
    [Serializable]
    public class Hrac
    {

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

        public bool MaIdentickouKartu(CisloKaret cisloKarty, ZnakyKaret znakKarty)
        {
            foreach (var karta in KartyVRuce)
            {
                if (karta.CisloKarty == cisloKarty && znakKarty == karta.Znak)
                {
                    return true;
                }
            }
            return false;
        }

        public int MaKartuAJeHratelna(CisloKaret cisloKarty, ZnakyKaret aktualniZnak)
        {
            if (cisloKarty == CisloKaret.svrsek)
            {
                foreach (var karta in KartyVRuce)
                {
                    if (karta.CisloKarty == cisloKarty)
                    {
                        return KartyVRuce.IndexOf(karta);
                    }
                }
            }
            else
            {
                foreach (var karta in KartyVRuce)
                {
                    if (karta.CisloKarty == cisloKarty && karta.Znak == aktualniZnak)
                    {
                        return KartyVRuce.IndexOf(karta);
                    }
                }
            }
            return -1;
        }

        public ZnakyKaret VratZnak(ZnakyKaret zmenenyZnak)
        {
            int[] pole = new int[4];

            foreach (var karta in KartyVRuce)
            {
                if (karta.Znak != zmenenyZnak)
                {
                    switch (karta.Znak)
                    {
                        case ZnakyKaret.list:
                            pole[0]++;
                            break;

                        case ZnakyKaret.kule:
                            pole[1]++;
                            break;

                        case ZnakyKaret.srdce:
                            pole[2]++;
                            break;

                        case ZnakyKaret.zalud:
                            pole[3]++;
                            break;

                        default:
                            break;
                    }
                }
            }
            int maxValue = pole.Max();
            for (int i = 0; i < 4; i++)
            {
                if (pole[i] == maxValue)
                {
                    switch (i)
                    {
                        case 0:
                            return ZnakyKaret.list;

                        case 1:
                            return ZnakyKaret.kule;

                        case 2:
                            return ZnakyKaret.srdce;

                        case 3:
                            return ZnakyKaret.zalud;

                        default:
                            break;
                    }
                }
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Vraci index prvni nalezene karty, pokud hrac ma aspon jednu kartu, ktera neni svrsek, eso, sedma a lze zahrat
        /// jinak -1, kdyz neni zadna hratelna normalni karta
        /// </summary>
        /// <returns></returns>
        public int MaNormalniKartu(Karta kartaNaPlose, ZnakyKaret aktualniZnak)
        {
            foreach (var karta in KartyVRuce)
            {
                if (karta.CisloKarty != CisloKaret.eso && karta.CisloKarty != CisloKaret.sedma && karta.CisloKarty != CisloKaret.svrsek)
                {
                    if (karta.CisloKarty == kartaNaPlose.CisloKarty || karta.Znak == aktualniZnak)
                    {
                        return KartyVRuce.IndexOf(karta);
                    }
                }
            }
            return -1;
        }

        public int DejPocetKaret()
        {
            return KartyVRuce.Count();
        }

        public void PridejKartuDoRuky(Karta karta, PictureBoxKarta grafikaKarty)
        {
            if (JeHrac)
            {
                karta.JeHrace = true;
                grafikaKarty.Image = Util.DejObrazekKarty(karta);
                grafikaKarty.Visible = true;
            }
            else
            {
                karta.JeHrace = false;
                grafikaKarty.Image = Properties.Resources.zada;
                grafikaKarty.Visible = true;
            }
            KartyVRuce.Add(karta);
        }

        public void OdeberKartu(Karta karta, PictureBoxKarta grafikaKarty)
        {
            karta.JeHrace = false;
            grafikaKarty.Visible = false;
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

        public Karta DejPrvniNalezenouKartu(CisloKaret cisloKarty, ZnakyKaret znakKarty)
        {
            foreach (var karta in KartyVRuce)
            {
                if (karta.CisloKarty == cisloKarty && znakKarty == karta.Znak)
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
            if (index > DejPocetKaret() - 1)
            {
                throw new IndexOutOfRangeException();
            }
            return KartyVRuce[index];
        }
    }
}