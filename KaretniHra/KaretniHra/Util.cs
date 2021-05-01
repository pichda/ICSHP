using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaretniHra
{
    public static class Util
    {
        private static Random rnd = new Random();

        public static System.Drawing.Bitmap DejObrazekKarty(Karta karta)
        {
            switch (karta.Znak)
            {
                case ZnakyKaret.list:
                    switch (karta.CisloKarty)
                    {
                        case CisloKaret.sedma:
                            return Properties.Resources.listy_sedma;
                        case CisloKaret.osmicka:
                            return Properties.Resources.listy_osmicka;
                        case CisloKaret.devitka:
                            return Properties.Resources.listy_devitka;
                        case CisloKaret.desitka:
                            return Properties.Resources.listy_desitka;
                        case CisloKaret.spodek:
                            return Properties.Resources.listy_spodek;
                        case CisloKaret.svrsek:
                            return Properties.Resources.listy_svrsek;
                        case CisloKaret.kral:
                            return Properties.Resources.listy_kral;
                        case CisloKaret.eso:
                            return Properties.Resources.listy_eso;
                    }
                    break;
                case ZnakyKaret.kule:
                    switch (karta.CisloKarty)
                    {
                        case CisloKaret.sedma:
                            return Properties.Resources.kule_sedmicka;
                        case CisloKaret.osmicka:
                            return Properties.Resources.kule_osmicka;
                        case CisloKaret.devitka:
                            return Properties.Resources.kule_devitka;
                        case CisloKaret.desitka:
                            return Properties.Resources.kule_desitka;
                        case CisloKaret.spodek:
                            return Properties.Resources.kule_spodek;
                        case CisloKaret.svrsek:
                            return Properties.Resources.kule_svrsek;
                        case CisloKaret.kral:
                            return Properties.Resources.kule_kral;
                        case CisloKaret.eso:
                            return Properties.Resources.kule_eso;
                    }
                    break;
                case ZnakyKaret.srdce:
                    switch (karta.CisloKarty)
                    {
                        case CisloKaret.sedma:
                            return Properties.Resources.srdce_sedma;
                        case CisloKaret.osmicka:
                            return Properties.Resources.srdce_osmicka;
                        case CisloKaret.devitka:
                            return Properties.Resources.srdce_devitka;
                        case CisloKaret.desitka:
                            return Properties.Resources.srdce_deset;
                        case CisloKaret.spodek:
                            return Properties.Resources.srdce_spodek;
                        case CisloKaret.svrsek:
                            return Properties.Resources.srdce_svrsek;
                        case CisloKaret.kral:
                            return Properties.Resources.srdce_kral;
                        case CisloKaret.eso:
                            return Properties.Resources.srdce_eso;
                    }
                    break;
                case ZnakyKaret.zalud:
                    switch (karta.CisloKarty)
                    {
                        case CisloKaret.sedma:
                            return Properties.Resources.zalud_sedma;
                        case CisloKaret.osmicka:
                            return Properties.Resources.zalud_osmicka;
                        case CisloKaret.devitka:
                            return Properties.Resources.zalud_devitka;
                        case CisloKaret.desitka:
                            return Properties.Resources.zalud_desitka;
                        case CisloKaret.spodek:
                            return Properties.Resources.zalud_spodek;
                        case CisloKaret.svrsek:
                            return Properties.Resources.zalud_svrsek;
                        case CisloKaret.kral:
                            return Properties.Resources.zalud_kral;
                        case CisloKaret.eso:
                            return Properties.Resources.zalud_eso;
                    }
                    break;
            }
            throw new ApplicationException("chyba");
        }
        public static System.Drawing.Bitmap DejObrazekZnaku(ZnakyKaret aktualniZnak)
        {
            switch (aktualniZnak)
            {
                case ZnakyKaret.kule:
                    return Properties.Resources.kule;
                case ZnakyKaret.srdce:
                    return Properties.Resources.srdce;
                case ZnakyKaret.zalud:
                    return Properties.Resources.zalud;
                case ZnakyKaret.list:
                    return Properties.Resources.listy;
                default: throw new ArgumentException();
            }

        }

        public static int randomCisloVRozmezi(int min, int max)
        {
            return rnd.Next(min, max);
        }

    }
}
