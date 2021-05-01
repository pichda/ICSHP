using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KaretniHra
{
    public partial class Form1 : Form
    {
        //TODO: mozny refactor codu (predelani vlastnosti BalikKaret, HraciPoleKaret na tridu Karty, kde budou funkce add a remove)

        public Hrac Hrac1 { get; set; }
        public Hrac ProtiHrac { get; set; }
        public List<Karta> BalikKaret { get; set; } // karty, které si hrac bere, pokud nemuze kartu zahrat
        public List<Karta> HraciPoleKaret { get; set; } // karty v poli

        public Karta posledniHrana { get; set; } // posledni zahrana karta

        public int PocetKaretNaZacatku { get; set; } // pocet karet, kterych se rozda kazdemu hraci

        public ZnakyKaret AktualniZnak { get; set; }  // aktulani znak/barva, ktery se vyuziva jen, kdyz je svrsek na hracim poli

        public bool HrajeHrac { get; set; }
        public int PocetSedmicek { get; set; }  // pocet sedmicek, ktere se zahrali. Scita se za kazdou sedmu, ktera se hrala po minule sedmicce.

        public Form1()
        {
            InitializeComponent();

            Hrac1 = new Hrac("Hráč", true);
            ProtiHrac = new Hrac("Počítač", false);
            HrajeHrac = true;

            BalikKaret = new List<Karta>();
            HraciPoleKaret = new List<Karta>();
            PocetKaretNaZacatku = 6;
            PocetSedmicek = 0;
            inicializaceHry();
            StartHry();
            prekresliKarty();
        }

        public void inicializaceHry()
        {
            VytvoreniHracichKaret();
            ZamichaniKaret();
        }

        private void ZamichaniKaret()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < BalikKaret.Count; j++)
                {
                    int prvniNahodnyPrvek = Util.randomCisloVRozmezi(0, BalikKaret.Count);
                    int druhyNahodnyPrvek = Util.randomCisloVRozmezi(0, BalikKaret.Count);

                    Karta temp = BalikKaret[prvniNahodnyPrvek];
                    BalikKaret[prvniNahodnyPrvek] = BalikKaret[druhyNahodnyPrvek];
                    BalikKaret[druhyNahodnyPrvek] = temp;
                }
            }
        }

        private void VytvoreniHracichKaret()
        {
            for (int i = 0; i < 4; i++)
            {
                Karta sedma = new Karta((ZnakyKaret)i, CisloKaret.sedma);
                sedma.MouseHover += new EventHandler(OnHoverZobrazKartu);
                sedma.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                sedma.Click += new EventHandler(KliknutiNaKartu);

                Karta osmicka = new Karta((ZnakyKaret)i, CisloKaret.osmicka);
                osmicka.MouseHover += new EventHandler(OnHoverZobrazKartu);
                osmicka.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                osmicka.Click += new EventHandler(KliknutiNaKartu);

                Karta devitka = new Karta((ZnakyKaret)i, CisloKaret.devitka);
                devitka.MouseHover += new EventHandler(OnHoverZobrazKartu);
                devitka.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                devitka.Click += new EventHandler(KliknutiNaKartu);

                Karta desitka = new Karta((ZnakyKaret)i, CisloKaret.desitka);
                desitka.MouseHover += new EventHandler(OnHoverZobrazKartu);
                desitka.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                desitka.Click += new EventHandler(KliknutiNaKartu);

                Karta spodek = new Karta((ZnakyKaret)i, CisloKaret.spodek);
                spodek.MouseHover += new EventHandler(OnHoverZobrazKartu);
                spodek.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                spodek.Click += new EventHandler(KliknutiNaKartu);

                Karta svrsek = new Karta((ZnakyKaret)i, CisloKaret.svrsek);
                svrsek.MouseHover += new EventHandler(OnHoverZobrazKartu);
                svrsek.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                svrsek.Click += new EventHandler(KliknutiNaKartu);

                Karta kral = new Karta((ZnakyKaret)i, CisloKaret.kral);
                kral.MouseHover += new EventHandler(OnHoverZobrazKartu);
                kral.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                kral.Click += new EventHandler(KliknutiNaKartu);

                Karta eso = new Karta((ZnakyKaret)i, CisloKaret.eso);
                eso.MouseHover += new EventHandler(OnHoverZobrazKartu);
                eso.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                eso.Click += new EventHandler(KliknutiNaKartu);

                BalikKaret.Add(sedma);
                BalikKaret.Add(osmicka);
                BalikKaret.Add(devitka);
                BalikKaret.Add(desitka);
                BalikKaret.Add(spodek);
                BalikKaret.Add(svrsek);
                BalikKaret.Add(kral);
                BalikKaret.Add(eso);
            }
        }

        public void StartHry()
        {
            // ziskani karet na pocatku hry

            for (int i = 0; i < PocetKaretNaZacatku; i++)
            {
                Karta kartaProHrace = BalikKaret[BalikKaret.Count - 1];
                Hrac1.PridejKartuDoRuky(kartaProHrace);
                OdeberPosledniKartuZBaliku();

                Karta kartaProtihrace = BalikKaret[BalikKaret.Count - 1];
                ProtiHrac.PridejKartuDoRuky(kartaProtihrace);
                OdeberPosledniKartuZBaliku();
            }
            Karta kartaDoPole = BalikKaret[BalikKaret.Count - 1];
            HraciPoleKaret.Add(kartaDoPole);
            OdeberPosledniKartuZBaliku();
            kartaDoPole.Image = Util.DejObrazekKarty(kartaDoPole);
            kartaDoPole.Visible = true;
            pictureBoxHrane.Image = HraciPoleKaret[0].Image;
            pictureBoxHrane.SizeMode = PictureBoxSizeMode.StretchImage;

            // pokud karta v poli je svrsek, tak se kontroluje jaká barva platí, podle poslední karty v baliku
            if (HraciPoleKaret[HraciPoleKaret.Count - 1].CisloKarty == CisloKaret.svrsek)
            {
                AktualniZnak = BalikKaret[BalikKaret.Count - 1].Znak;
            }
            else
            {
                posledniHrana = kartaDoPole;
            }
        }

        private void OdeberPosledniKartuZBaliku()
        {
            BalikKaret.Remove(BalikKaret[BalikKaret.Count - 1]);
        }

        /// <summary>
        /// Pokud neni zadna karta v baliku, tak se pridaji karty z hraciho pole do baliku a zamicha se balik.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LiznutiKarty(object sender, EventArgs e)
        {
            //TODO: animace karty/ vykresleni karet prozatim
            if (HrajeHrac)
            {
                if (BalikKaret.Count == 0)
                {
                    while (HraciPoleKaret.Count > 0)
                    {
                        BalikKaret.Add(HraciPoleKaret[0]);
                        HraciPoleKaret.RemoveAt(0);
                    }
                    ZamichaniKaret();
                }
                if (PocetSedmicek > 0)
                {
                    for (int i = 0; i < PocetSedmicek * 2; i++)
                    {
                        Karta kartaProHrace = BalikKaret[BalikKaret.Count - 1];
                        Hrac1.PridejKartuDoRuky(kartaProHrace);
                        OdeberPosledniKartuZBaliku();
                    }
                    PocetSedmicek = 0;
                }
                else
                {
                    Karta kartaProHrace = BalikKaret[BalikKaret.Count - 1];
                    Hrac1.PridejKartuDoRuky(kartaProHrace);
                    OdeberPosledniKartuZBaliku();
                }
                HrajeHrac = false;
                prekresliKarty();
            }
        }

        private void liznutiKartyProPocitac()
        {
            if (!HrajeHrac)
            {
                if (BalikKaret.Count == 0)
                {
                    while (HraciPoleKaret.Count > 0)
                    {
                        BalikKaret.Add(HraciPoleKaret[0]);
                        HraciPoleKaret.RemoveAt(0);
                    }
                    ZamichaniKaret();
                }

                if (PocetSedmicek > 0)
                {
                    for (int i = 0; i < PocetSedmicek * 2; i++)
                    {
                        Karta karta = BalikKaret[BalikKaret.Count - 1];
                        ProtiHrac.PridejKartuDoRuky(karta);
                        OdeberPosledniKartuZBaliku();
                    }
                    PocetSedmicek = 0;
                }
                else
                {
                    Karta karta = BalikKaret[BalikKaret.Count - 1];
                    ProtiHrac.PridejKartuDoRuky(karta);
                    OdeberPosledniKartuZBaliku();
                }
                HrajeHrac = true;
                prekresliKartyProtihrace();
            }
        }

        /// <summary>
        /// funkce, ktera prekresli karty na hraci pole (Form1)
        /// </summary>
        private void prekresliKarty()
        {
            int pocetKaret = Hrac1.DejPocetKaret();

            for (int i = 0; i < pocetKaret; i++)
            {
                int polovina = pocetKaret / 2;
                int zacatekSouradnic = 500 - (25 * polovina);

                Hrac1.KartyVRuce[i].Location = new System.Drawing.Point(zacatekSouradnic + (25 * i), 400);
                this.Controls.Add(Hrac1.KartyVRuce[i]);
            }
        }

        private void prekresliKartyProtihrace()
        {
            int pocetKaretProtiHrace = ProtiHrac.DejPocetKaret();
            for (int i = 0; i < pocetKaretProtiHrace; i++)
            {
                int polovina = pocetKaretProtiHrace / 2;
                int zacatekSouradnic = 500 - (25 * polovina);

                ProtiHrac.KartyVRuce[i].Location = new System.Drawing.Point(zacatekSouradnic + (25 * i), 10);
                this.Controls.Add(ProtiHrac.KartyVRuce[i]);
            }
        }

        private void OnHoverZobrazKartu(object sender, EventArgs e)
        {
            Karta karta = sender as Karta;
            if (karta.JeHrace)
            {
                karta.BringToFront();
            }
        }

        private void OnHoverOutSkryjKartu(object sender, EventArgs e)
        {
            Karta karta = sender as Karta;
            if (karta.JeHrace)
            {
                //karta.SendToBack();
                prekresliKarty(); // rozhodne neni efektivni/optimalizovany

                //TODO: bringtoback (vyzkouset podobnou metodu k bringtofront, misto prekresleni vsech karet)
            }
        }

        private void KliknutiNaKartu(object sender, EventArgs e)
        {
            if (HrajeHrac)
            {
                Karta karta = sender as Karta;
                if (karta.JeHrace)
                {
                    if (JePenalizacniKarta(karta))
                    {
                        if (posledniHrana.CisloKarty == CisloKaret.sedma)
                        {
                            if (karta.CisloKarty == CisloKaret.sedma)
                            {
                                nastaveniKaret(karta);
                                PocetSedmicek++;
                                HrajeHrac = false;
                            }
                        }
                        else if (posledniHrana.CisloKarty == CisloKaret.eso)
                        {
                            if (Hrac1.MaKartu(CisloKaret.eso))
                            {
                                if (karta.CisloKarty == CisloKaret.eso)
                                {
                                    nastaveniKaret(karta);
                                    HrajeHrac = false;
                                }
                            }
                            else
                            {
                                HrajeHrac = false;
                            }
                        }
                    }
                    else
                    {
                        if (karta.CisloKarty == CisloKaret.svrsek)
                        {
                            zakazHraciInterakci();
                            zobrazVybiraniZnaku();
                            nastaveniKaret(karta);
                        }
                        else
                        {
                            if (karta.CisloKarty == posledniHrana.CisloKarty || karta.Znak == posledniHrana.Znak)
                            {
                                nastaveniKaret(karta);
                                HrajeHrac = false;
                            }
                        }
                    }

                    if (Hrac1.DejPocetKaret() == 0)
                    {
                        //TODO: vypis na obrazovku "YOU WIN", prehod po 5ti sekundach na druhy form (menu, kde bude nova hra nebo nacti hru)
                    }
                    else
                    {
                        if (!HrajeHrac)
                        {
                            prekresliKarty();
                            tahProtiHrace();
                            zakazHraciInterakci();
                        }
                    }
                }
            }
        }

        private void tahProtiHrace()
        {
            if (!HrajeHrac)
            {
                if (JePenalizacniKarta(posledniHrana))
                {
                    if (posledniHrana.CisloKarty == CisloKaret.sedma)
                    {
                        if (ProtiHrac.MaKartu(CisloKaret.sedma))
                        {
                            nastaveniKaret(ProtiHrac.DejPrvniNalezenouKartu(CisloKaret.sedma));
                            PocetSedmicek++;
                            HrajeHrac = true;
                        }
                        else
                        {
                            liznutiKartyProPocitac();
                            HrajeHrac = true;
                        }
                    }
                    else if (posledniHrana.CisloKarty == CisloKaret.eso)
                    {
                        if (ProtiHrac.MaKartu(CisloKaret.eso))
                        {
                            if (ProtiHrac.MaKartu(CisloKaret.eso))
                            {
                                nastaveniKaret(ProtiHrac.DejPrvniNalezenouKartu(CisloKaret.eso));
                                HrajeHrac = true;
                            }
                        }
                        else
                        {
                            HrajeHrac = true;
                        }
                    }
                }
                else
                {
                    if (Hrac1.DejPocetKaret() == 1)
                    {
                        // pokud hral svrska
                        if(posledniHrana.CisloKarty == CisloKaret.svrsek)
                        {
                            if (ProtiHrac.MaKartu(CisloKaret.svrsek))
                            {
                                nastaveniKaret(ProtiHrac.DejPrvniNalezenouKartu(CisloKaret.svrsek));
                                HrajeHrac = true;
                                
                                // zahraj svrska
                            }else if(ProtiHrac.MaKartuAJeHratelna(CisloKaret.sedma, AktualniZnak))
                            {
                                // zahraj sedmu
                            }
                            else if (ProtiHrac.MaKartuAJeHratelna(CisloKaret.eso, AktualniZnak))
                            {
                                // zahraj eso
                            }
                            else
                            {
                                // normalne zahraj
                            }
                        }
                        else
                        {
                            // pokud hral cokoliv jineho ale ma posledni kartu
                        }
                        // zahral svrska a ma posledni kartu, tak taky zmen barvu, jinak zkus zahrat sedmu, eso
                    }
                    else
                    {
                        // normalne hraj, pokud nema posledni kartu a nehrozi vyhra pro hrace
                    }

                    if (!ProtiHrac.MaNormalniKartu(posledniHrana))
                    {
                        // nema normalni kartu ale ma svrska - ma normalni kartu, nema normalni kartu
                        if (ProtiHrac.MaKartu(CisloKaret.svrsek))
                        {
                            if (ProtiHrac.DejPocetKaret() == 2)
                            {
                                if (ProtiHrac.DejPrvniKartu().CisloKarty == CisloKaret.svrsek)
                                {
                                    AktualniZnak = ProtiHrac.DejKartuNaIndexu(1).Znak;
                                    nastaveniKaret(ProtiHrac.DejKartuNaIndexu(0));
                                    HrajeHrac = true;
                                }
                                else
                                {

                                }
                            }
                        }
                        nastaveniKaret(karta);
                    }
                    else
                    {
                        if (karta.CisloKarty == posledniHrana.CisloKarty || karta.Znak == posledniHrana.Znak)
                        {
                            nastaveniKaret(karta);
                            HrajeHrac = false;
                        }
                    }
                    //vykresli karty pocitace
                }


                //if (JePenalizacniKarta(posledniHrana))
                //{
                //    if (posledniHrana.CisloKarty == CisloKaret.sedma)
                //    {
                //        if (ProtiHrac.MaKartu(CisloKaret.sedma))
                //        {
                //        }
                //        else
                //        {
                //        }
                //    }
                //    else
                //    {
                //    }
                //}
                //else
                //{
                //    if (Hrac1.DejPocetKaret() == 1)
                //    {
                //        if (ProtiHrac.MaKartu(CisloKaret.sedma))
                //        {
                //            HrajeHrac = true;
                //        }
                //        else
                //        {
                //            //     if()
                //        }
                //    }
                //    else
                //    {
                //    }

                // if(ProtiHrac.MaKartu())
            }
        }

        /// <summary>
        /// Vraci true, pokud karta v parametru je sedma nebo eso.
        /// </summary>
        /// <param name="karta"></param>
        /// <returns></returns>
        public bool JePenalizacniKarta(Karta karta)
        {
            if (karta.CisloKarty == CisloKaret.eso || karta.CisloKarty == CisloKaret.sedma)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AnimaceKarty()
        {
            foreach (Karta karta in Hrac1.KartyVRuce)
            {
                karta.Enabled = false;
            }

            // TODO: pocitac
            // odebira kartu
            // liza kartu

            // hrac

            // odebira kartu
            // liza kartu

            System.Threading.Thread.Sleep(300);

            foreach (Karta karta in Hrac1.KartyVRuce)
            {
                karta.Enabled = true;
            }
        }

        /// <summary>
        /// Event, ktery zvoli barvu karty na kule, zavola metodu PrekresliKarty, schovejVybiraniZnaku a tahProtiHrace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AktualniZnak = ZnakyKaret.kule;
            HrajeHrac = false;
            uvolniHraciInterakci();
            schovejVybiraniZnaku();
            pictureBox5.Image = Util.DejObrazekZnaku(AktualniZnak);
            tahProtiHrace();
        }

        /// <summary>
        ///  Event, ktery zvoli barvu karty na listy, zavola metodu PrekresliKarty, schovejVybiraniZnaku a tahProtiHrace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AktualniZnak = ZnakyKaret.list;
            HrajeHrac = false;
            uvolniHraciInterakci();
            schovejVybiraniZnaku();
            pictureBox5.Image = Util.DejObrazekZnaku(AktualniZnak);
            tahProtiHrace();
        }

        /// <summary>
        ///  Event, ktery zvoli barvu karty na srdce, zavola metodu PrekresliKarty, schovejVybiraniZnaku a tahProtiHrace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AktualniZnak = ZnakyKaret.srdce;
            HrajeHrac = false;
            uvolniHraciInterakci();
            schovejVybiraniZnaku();
            pictureBox5.Image = Util.DejObrazekZnaku(AktualniZnak);
            tahProtiHrace();
        }

        /// <summary>
        ///  Event, ktery zvoli barvu karty na zaludy, zavola metodu PrekresliKarty, schovejVybiraniZnaku a tahProtiHrace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AktualniZnak = ZnakyKaret.zalud;
            HrajeHrac = false;
            uvolniHraciInterakci();
            schovejVybiraniZnaku();
            pictureBox5.Image = Util.DejObrazekZnaku(AktualniZnak);
            tahProtiHrace();
        }

        private void schovejVybiraniZnaku()
        {
            label1.Visible = false;
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Enabled = false;
            pictureBox2.Visible = false;
            pictureBox3.Enabled = false;
            pictureBox3.Visible = false;
            pictureBox4.Enabled = false;
            pictureBox4.Visible = false;
        }

        private void zobrazVybiraniZnaku()
        {
            label1.Visible = true;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
            pictureBox2.Visible = true;
            pictureBox2.Enabled = true;
            pictureBox3.Visible = true;
            pictureBox3.Enabled = true;
            pictureBox4.Visible = true;
            pictureBox4.Enabled = true;
        }

        private void nastaveniKaret(Karta karta)
        {
            if (karta.JeHrace)
            {
                Hrac1.OdeberKartu(karta);
                HraciPoleKaret.Add(karta);
                posledniHrana = karta;

                pictureBoxHrane.Image = karta.Image;
            }
            else
            {
                ProtiHrac.OdeberKartu(karta);
                HraciPoleKaret.Add(karta);
                posledniHrana = karta;

                karta.Image = Util.DejObrazekKarty(karta);
                karta.Visible = true;
                pictureBoxHrane.Image = karta.Image;
            }
        }

        private void zakazHraciInterakci()
        {
            foreach (Karta k in Hrac1.KartyVRuce)
            {
                k.Enabled = false;
            }
            pictureBoxBalik.Enabled = false;
        }

        private void uvolniHraciInterakci()
        {
            foreach (Karta k in Hrac1.KartyVRuce)
            {
                k.Enabled = true;
            }
            pictureBoxBalik.Enabled = true;
        }
    }
}