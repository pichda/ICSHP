using System;
using System.Collections.Generic;

namespace LigaMistru
{
    public class Hraci
    {
        public int Pocet { get; set; }
        private Hrac[] poleHracu = new Hrac[100];

        public void Vymaz(int index)
        {
            if (index > poleHracu.Length - 1)
            {
                poleHracu[index] = null;
                Pocet--;
                for (int i = index; i < Pocet; i++)
                {
                    poleHracu[i] = poleHracu[i + 1];
                }
                
            }
        }

        public void Pridej(Hrac hrac)
        {
            if (Pocet > poleHracu.Length - 1)
            {
                Array.Resize(ref poleHracu, poleHracu.Length * 2);
                poleHracu[Pocet] = hrac;
                Pocet++;
            }
            else
            {
                poleHracu[Pocet] = hrac;
                Pocet++;
            }
        }

        public void Uprav(int index, String jmeno, int golPocet, FotbalovyKlub klub)
        {
            if (index > poleHracu.Length - 1)
            {
                poleHracu[index].GolPocet = golPocet;
                poleHracu[index].Jmeno = jmeno;
                poleHracu[index].Klub = klub;

            }
        }

        public object this[int index]
        {
            get
            {
                if (index >= 0 && index <= Pocet)
                {
                    return poleHracu[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (index > Pocet && index < poleHracu.Length - 1)
                {
                    poleHracu[index] = (Hrac)value;
                }
            }
        }

        public void NajdiNejlepsiKluby(out string kluby,out int golPocet)
        {
            FotbalovyKlubInfo klubyInfo = new FotbalovyKlubInfo();

            int[] goly = new int[klubyInfo.Pocet];
            kluby = "";

            for (int i = 0; i < Pocet; i++)
            {

                switch (poleHracu[i].Klub)
                {
                    case FotbalovyKlub.None:
                        goly[0] += poleHracu[i].GolPocet;
                        break;
                    case FotbalovyKlub.FCPorto:
                        goly[1] += poleHracu[i].GolPocet;
                        break;
                    case FotbalovyKlub.Arsenal:
                        goly[2] += poleHracu[i].GolPocet;
                        break;
                    case FotbalovyKlub.RealMadrid:
                        goly[3] += poleHracu[i].GolPocet;
                        break;
                    case FotbalovyKlub.Chelsea:
                        goly[4] += poleHracu[i].GolPocet;
                        break;
                    case FotbalovyKlub.Barcelona:
                        goly[5] += poleHracu[i].GolPocet;
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
        
    }
}