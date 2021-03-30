using System;
using System.Collections.Generic;

namespace LigaMistru
{
    internal class Hraci
    {
        public int Pocet { get; set; }
        private Hrac[] poleHracu = new Hrac[100];

        public void Vymaz(int index)
        {
            if (index > poleHracu.Length - 1)
            {
                poleHracu[index] = null;
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

        public void NajdiNejlepsiKluby(out string[]kluby,out int[] golPocet)
        {
            FotbalovyKlubInfo klubyInfo = new FotbalovyKlubInfo();

            int[] goly = new int[klubyInfo.Pocet];

            for (int i = 0; i < Pocet; i++)
            {

                switch (poleHracu[i].Klub)
                {
                    case FotbalovyKlub.None:
                        goly[0] = poleHracu[i].GolPocet;
                        break;
                    case FotbalovyKlub.FCPorto:
                        goly[1] = poleHracu[i].GolPocet;
                        break;
                    case FotbalovyKlub.Arsenal:
                        goly[2] = poleHracu[i].GolPocet;
                        break;
                    case FotbalovyKlub.RealMadrid:
                        goly[3] = poleHracu[i].GolPocet;
                        break;
                    case FotbalovyKlub.Chelsea:
                        goly[4] = poleHracu[i].GolPocet;
                        break;
                    case FotbalovyKlub.Barcelona:
                        goly[5] = poleHracu[i].GolPocet;
                        break;
                }
                
            }
            int nejviceGolu = goly[0];
            int index = 0; // index, ktery zmensuje druhy pruchod pole

            
            for (int i = 1; i < goly.Length; i++)
            {
                if (goly[i] > nejviceGolu)
                {
                    nejviceGolu = goly[i];
                    index = 0;
                }
            }

            List<int> listGoly = new List<int>();
            List<string> listKluby = new List<string>();

            // kontrola, jestli ostatni tymy taky nemaji stejne max golu
            for (int i = index; i < goly.Length; i++)
            {
                if (goly[i] == nejviceGolu)
                {
                    listKluby.Add(klubyInfo.DejNazev((FotbalovyKlub)i)); // i = index v enumu tymu
                    listGoly.Add(goly[i]); // goly[i] = celkovy pocet golu tymu
                }
            }

            golPocet = listGoly.ToArray();
            kluby = listKluby.ToArray();

        }
        
    }
}