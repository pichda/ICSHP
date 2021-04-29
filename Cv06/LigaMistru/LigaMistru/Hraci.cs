using System;
using System.Collections.Generic;

namespace LigaMistru
{
    public class Hraci
    {
        private SpojovySeznam seznamHracu;

        public Hraci()
        {
            seznamHracu = new SpojovySeznam();
        }

        public void Vymaz(int index)
        {
            seznamHracu.RemoveAt(index);
        }

        public void Pridej(Hrac hrac)
        {
            seznamHracu.Add(hrac);
        }

        public Array DejVsechnyHrace(Array vracenePole)
        {
            seznamHracu.CopyTo(vracenePole, 0);
            return vracenePole;
        }

        public Hrac[] DejVybraneHrace(int[] vybraneKluby)
        {
            Hrac[] temp = new Hrac[Size()];
            int indexVybranychHracu = 0;

            for (int i = 0; i < Size(); i++)
            {
                for (int j = 0; j < vybraneKluby.Length; j++)
                {
                    Hrac docasnyHrac = (Hrac)seznamHracu[i];
                    if (docasnyHrac.Klub == (FotbalovyKlub)vybraneKluby[j])
                    {
                        temp[indexVybranychHracu] = docasnyHrac;
                        indexVybranychHracu++;
                        break;
                    }
                } 
            }

            if(indexVybranychHracu == 0)
            {
                return null;
            }
            else
            {
                Hrac[] vybranyHraci = new Hrac[indexVybranychHracu];
                temp.CopyTo(vybranyHraci, 0);
                return vybranyHraci;
            }
        }

        public void Uprav(int index, String jmeno, int golPocet, FotbalovyKlub klub)
        {
            Hrac upravaHrace = (Hrac)seznamHracu.Get(index);

            upravaHrace.GolPocet = golPocet;
            upravaHrace.Jmeno = jmeno;
            upravaHrace.Klub = klub;

            seznamHracu.Set(index, upravaHrace);
        }

        public object this[int index]
        {
            get
            {
                return seznamHracu.Get(index);
            }
            set
            {
                seznamHracu.Set(index, value);
            }
        }

        public int Size()
        {
            return seznamHracu.Count;
        }

        public void NajdiNejlepsiKluby(out string kluby,out int golPocet)
        {
            FotbalovyKlubInfo klubyInfo = new FotbalovyKlubInfo();

            int[] goly = new int[klubyInfo.Pocet];
            kluby = "";

            for (int i = 0; i < Size(); i++)
            {
                Hrac pomocna = (Hrac)seznamHracu.Get(i);

                switch (pomocna.Klub)
                {
                    case FotbalovyKlub.None:
                        goly[0] += pomocna.GolPocet;
                        break;
                    case FotbalovyKlub.FCPorto:
                        goly[1] += pomocna.GolPocet;
                        break;
                    case FotbalovyKlub.Arsenal:
                        goly[2] += pomocna.GolPocet;
                        break;
                    case FotbalovyKlub.RealMadrid:
                        goly[3] += pomocna.GolPocet;
                        break;
                    case FotbalovyKlub.Chelsea:
                        goly[4] += pomocna.GolPocet;
                        break;
                    case FotbalovyKlub.Barcelona:
                        goly[5] += pomocna.GolPocet;
                        break;
                }
                
            }
            int nejviceGolu = goly[1];
            int index = 1; // index, ktery zmensuje druhy pruchod pole

            
            for (int i = 2; i < goly.Length; i++)
            {
                if (goly[i] > nejviceGolu)
                {
                    nejviceGolu = goly[i];
                    index = i;
                }
            }


            // kontrola, jestli ostatni tymy taky nemaji stejne max golu
            for (int i = index; i < goly.Length; i++)
            {
                if (goly[i] == nejviceGolu)
                {
                    kluby += klubyInfo.DejNazev((FotbalovyKlub)i) + ";"; // i = index v enumu tymu
                }
            }

            golPocet = nejviceGolu;

        }

        public void NajdiNejlepsiKluby(out FotbalovyKlub[] kluby, out int golPocet)
        {
            FotbalovyKlubInfo klubyInfo = new FotbalovyKlubInfo();

            int[] goly = new int[klubyInfo.Pocet];
            kluby = new FotbalovyKlub[20];

            for (int i = 0; i < Size(); i++)
            {
                Hrac pomocna = (Hrac)seznamHracu.Get(i);
                switch (pomocna.Klub)
                {
                    case FotbalovyKlub.None:
                        goly[0] += pomocna.GolPocet;
                        break;
                    case FotbalovyKlub.FCPorto:
                        goly[1] += pomocna.GolPocet;
                        break;
                    case FotbalovyKlub.Arsenal:
                        goly[2] += pomocna.GolPocet;
                        break;
                    case FotbalovyKlub.RealMadrid:
                        goly[3] += pomocna.GolPocet;
                        break;
                    case FotbalovyKlub.Chelsea:
                        goly[4] += pomocna.GolPocet;
                        break;
                    case FotbalovyKlub.Barcelona:
                        goly[5] += pomocna.GolPocet;
                        break;
                }

            }
            int nejviceGolu = goly[1];
            int index = 1; // index, ktery zmensuje druhy pruchod pole


            for (int i = 2; i < goly.Length; i++)
            {
                if (goly[i] > nejviceGolu)
                {
                    nejviceGolu = goly[i];
                    index = i;
                }
            }


            // kontrola, jestli ostatni tymy taky nemaji stejne max golu
            int pomocnaIndex = 0;
            for (int i = index; i < goly.Length; i++)
            {
                if (goly[i] == nejviceGolu)
                {
                    kluby[pomocnaIndex] = (FotbalovyKlub)i; // i = index v enumu tymu
                }
            }

            golPocet = nejviceGolu;
        }
    }
}