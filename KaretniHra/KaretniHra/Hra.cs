using System.Collections.Generic;
using System;

namespace KaretniHra
{
    public class Hra
    {
        public Hra(Hrac hrac1, Hrac protiHrac, List<Karta> balikKaret, List<Karta> hraciPoleKaret, Karta posledniHrana, bool jeNevyzvednutaPenalizace, int pocetKaretNaZacatku, ZnakyKaret aktualniZnak, bool hrajeHrac, int pocetSedmicek)
        {
            Hrac1 = hrac1;
            ProtiHrac = protiHrac;
            BalikKaret = balikKaret;
            HraciPoleKaret = hraciPoleKaret;
            this.posledniHrana = posledniHrana;
            JeNevyzvednutaPenalizace = jeNevyzvednutaPenalizace;
            PocetKaretNaZacatku = pocetKaretNaZacatku;
            AktualniZnak = aktualniZnak;
            HrajeHrac = hrajeHrac;
            PocetSedmicek = pocetSedmicek;
        }

        public Hrac Hrac1 { get; set; }
        public Hrac ProtiHrac { get; set; }
        public List<Karta> BalikKaret { get; set; } // karty, které si hrac bere, pokud nemuze kartu zahrat
        public List<Karta> HraciPoleKaret { get; set; } // karty v poli

        public Karta posledniHrana { get; set; } // posledni zahrana karta
        public bool JeNevyzvednutaPenalizace { get; set; }
        public int PocetKaretNaZacatku { get; set; } // pocet karet, kterych se rozda kazdemu hraci

        public ZnakyKaret AktualniZnak { get; set; }  // aktulani znak/barva, ktery se vyuziva jen, kdyz je svrsek na hracim poli

        public bool HrajeHrac { get; set; }
        public int PocetSedmicek { get; set; }  // pocet sedmicek, ktere se zahrali. Scita se za kazdou sedmu, ktera se hrala po minule sedmicce.

        public int VratIndexGrafikyKarty(Karta karta)
        {
            // list, kule, srdce, zalud
            // sedma, osmicka, devitka, desitka, spodek, svrsek, kral, eso
            switch (karta.Znak)
            {
                case ZnakyKaret.list:
                    switch (karta.CisloKarty)
                    {
                        case CisloKaret.sedma:
                            return 0;
                        case CisloKaret.osmicka:
                            return 1;
                        case CisloKaret.devitka:
                            return 2;
                        case CisloKaret.desitka:
                            return 3;
                        case CisloKaret.spodek:
                            return 4;
                        case CisloKaret.svrsek:
                            return 5;
                        case CisloKaret.kral:
                            return 6;
                        case CisloKaret.eso:
                            return 7;
                        default:
                            break;
                    }
                    break;
                case ZnakyKaret.kule:
                    switch (karta.CisloKarty)
                    {
                        case CisloKaret.sedma:
                            return 8;
                        case CisloKaret.osmicka:
                            return 9;
                        case CisloKaret.devitka:
                            return 10;
                        case CisloKaret.desitka:
                            return 11;
                        case CisloKaret.spodek:
                            return 12;
                        case CisloKaret.svrsek:
                            return 13;
                        case CisloKaret.kral:
                            return 14;
                        case CisloKaret.eso:
                            return 15;
                        default:
                            break;
                    }
                    break;
                case ZnakyKaret.srdce:
                    switch (karta.CisloKarty)
                    {
                        case CisloKaret.sedma:
                            return 16;
                        case CisloKaret.osmicka:
                            return 17;
                        case CisloKaret.devitka:
                            return 18;
                        case CisloKaret.desitka:
                            return 19;
                        case CisloKaret.spodek:
                            return 20;
                        case CisloKaret.svrsek:
                            return 21;
                        case CisloKaret.kral:
                            return 22;
                        case CisloKaret.eso:
                            return 23;
                        default:
                            break;
                    }
                    break;
                case ZnakyKaret.zalud:
                    switch (karta.CisloKarty)
                    {
                        case CisloKaret.sedma:
                            return 24;
                        case CisloKaret.osmicka:
                            return 25;
                        case CisloKaret.devitka:
                            return 26;
                        case CisloKaret.desitka:
                            return 27;
                        case CisloKaret.spodek:
                            return 28;
                        case CisloKaret.svrsek:
                            return 29;
                        case CisloKaret.kral:
                            return 30;
                        case CisloKaret.eso:
                            return 31;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            throw new ArgumentException();
        }
        public Karta VratKartuGrafikyNaIndexu(int index)
        {
            // list, kule, srdce, zalud
            // sedma, osmicka, devitka, desitka, spodek, svrsek, kral, eso
            switch (index)
            {
                case 0:
                    return new Karta(ZnakyKaret.list, CisloKaret.sedma);
                case 1:
                    return new Karta(ZnakyKaret.list, CisloKaret.osmicka);
                case 2:
                    return new Karta(ZnakyKaret.list, CisloKaret.devitka);
                case 3:
                    return new Karta(ZnakyKaret.list, CisloKaret.desitka);
                case 4:
                    return new Karta(ZnakyKaret.list, CisloKaret.spodek);
                case 5:
                    return new Karta(ZnakyKaret.list, CisloKaret.svrsek);
                case 6:
                    return new Karta(ZnakyKaret.list, CisloKaret.kral);
                case 7:
                    return new Karta(ZnakyKaret.list, CisloKaret.eso);
                case 8:
                    return new Karta(ZnakyKaret.kule, CisloKaret.sedma);
                case 9:
                    return new Karta(ZnakyKaret.kule, CisloKaret.osmicka);
                case 10:
                    return new Karta(ZnakyKaret.kule, CisloKaret.devitka);
                case 11:
                    return new Karta(ZnakyKaret.kule, CisloKaret.desitka);
                case 12:
                    return new Karta(ZnakyKaret.kule, CisloKaret.spodek);
                case 13:
                    return new Karta(ZnakyKaret.kule, CisloKaret.svrsek);
                case 14:
                    return new Karta(ZnakyKaret.kule, CisloKaret.kral);
                case 15:
                    return new Karta(ZnakyKaret.kule, CisloKaret.eso);
                case 16:
                    return new Karta(ZnakyKaret.srdce, CisloKaret.sedma);
                case 17:
                    return new Karta(ZnakyKaret.srdce, CisloKaret.osmicka);
                case 18:
                    return new Karta(ZnakyKaret.srdce, CisloKaret.devitka);
                case 19:
                    return new Karta(ZnakyKaret.srdce, CisloKaret.desitka);
                case 20:
                    return new Karta(ZnakyKaret.srdce, CisloKaret.spodek);
                case 21:
                    return new Karta(ZnakyKaret.srdce, CisloKaret.svrsek);
                case 22:
                    return new Karta(ZnakyKaret.srdce, CisloKaret.kral);
                case 23:
                    return new Karta(ZnakyKaret.srdce, CisloKaret.eso);
                case 24:
                    return new Karta(ZnakyKaret.zalud, CisloKaret.sedma);
                case 25:
                    return new Karta(ZnakyKaret.zalud, CisloKaret.osmicka);
                case 26:
                    return new Karta(ZnakyKaret.zalud, CisloKaret.devitka);
                case 27:
                    return new Karta(ZnakyKaret.zalud, CisloKaret.desitka);
                case 28:
                    return new Karta(ZnakyKaret.zalud, CisloKaret.spodek);
                case 29:
                    return new Karta(ZnakyKaret.zalud, CisloKaret.svrsek);
                case 30:
                    return new Karta(ZnakyKaret.zalud, CisloKaret.kral);
                case 31:
                    return new Karta(ZnakyKaret.zalud, CisloKaret.eso);
                default:
                    break;
            }
            throw new ArgumentException();
        }
    }
}