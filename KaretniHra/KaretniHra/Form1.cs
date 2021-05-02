using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace KaretniHra
{
    public partial class Form1 : Form
    {
        public FormMenu FormMenu { get; set; }
        public Hra novaHra { get; set; }
        public List<PictureBoxKarta> GrafikaKaret { get; set; }

        public Form1(FormMenu menu)
        {
            InitializeComponent();
            FormMenu = menu;
            GrafikaKaret = new List<PictureBoxKarta>();

            Hrac hrac1 = new Hrac("Hráč", true);
            Hrac protiHrac = new Hrac("Počítač", false);
            bool hrajeHrac = true;
            bool jeNevyzvednutaPenalizace = false;

            List<Karta> balikKaret = new List<Karta>();
            List<Karta> hraciPoleKaret = new List<Karta>();
            int pocetKaretNaZacatku = 6;
            int pocetSedmicek = 0;

            novaHra = new Hra(hrac1, protiHrac, balikKaret, hraciPoleKaret, null, jeNevyzvednutaPenalizace, pocetKaretNaZacatku, ZnakyKaret.kule, hrajeHrac, pocetSedmicek);

            inicializaceHry();
            StartHry();
            prekresliKarty();
            prekresliKartyProtihrace();
        }

        public Form1(FormMenu menu, Hra ulozenaHra)
        {
            InitializeComponent();
            FormMenu = menu;
            GrafikaKaret = new List<PictureBoxKarta>();
            novaHra = ulozenaHra;
            VytvoreniGrafikyKaret();

            pictureBoxHrane.Image = Util.DejObrazekKarty(novaHra.posledniHrana);
            pictureBoxHrane.SizeMode = PictureBoxSizeMode.StretchImage;

            prekresliKarty();
            prekresliKartyProtihrace();
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
                for (int j = 0; j < novaHra.BalikKaret.Count; j++)
                {
                    int prvniNahodnyPrvek = Util.randomCisloVRozmezi(0, novaHra.BalikKaret.Count);
                    int druhyNahodnyPrvek = Util.randomCisloVRozmezi(0, novaHra.BalikKaret.Count);

                    Karta temp = novaHra.BalikKaret[prvniNahodnyPrvek];
                    novaHra.BalikKaret[prvniNahodnyPrvek] = novaHra.BalikKaret[druhyNahodnyPrvek];
                    novaHra.BalikKaret[druhyNahodnyPrvek] = temp;
                }
            }
        }

        private void VytvoreniHracichKaret()
        {
            for (int i = 0; i < 4; i++)
            {
                PictureBoxKarta sedmaPctBox = new PictureBoxKarta();
                Karta sedma = new Karta((ZnakyKaret)i, CisloKaret.sedma);
                sedmaPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                sedmaPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                sedmaPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(sedmaPctBox);

                PictureBoxKarta osmickaPctBox = new PictureBoxKarta();
                Karta osmicka = new Karta((ZnakyKaret)i, CisloKaret.osmicka);
                osmickaPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                osmickaPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                osmickaPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(osmickaPctBox);

                PictureBoxKarta devitkaPctBox = new PictureBoxKarta();
                Karta devitka = new Karta((ZnakyKaret)i, CisloKaret.devitka);
                devitkaPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                devitkaPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                devitkaPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(devitkaPctBox);

                PictureBoxKarta desitkaPctBox = new PictureBoxKarta();
                Karta desitka = new Karta((ZnakyKaret)i, CisloKaret.desitka);
                desitkaPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                desitkaPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                desitkaPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(desitkaPctBox);

                PictureBoxKarta spodekPctBox = new PictureBoxKarta();
                Karta spodek = new Karta((ZnakyKaret)i, CisloKaret.spodek);
                spodekPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                spodekPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                spodekPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(spodekPctBox);

                PictureBoxKarta svrsekPctBox = new PictureBoxKarta();
                Karta svrsek = new Karta((ZnakyKaret)i, CisloKaret.svrsek);
                svrsekPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                svrsekPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                svrsekPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(svrsekPctBox);

                PictureBoxKarta kralPctBox = new PictureBoxKarta();
                Karta kral = new Karta((ZnakyKaret)i, CisloKaret.kral);
                kralPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                kralPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                kralPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(kralPctBox);

                PictureBoxKarta esoPctBox = new PictureBoxKarta();
                Karta eso = new Karta((ZnakyKaret)i, CisloKaret.eso);
                esoPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                esoPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                esoPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(esoPctBox);

                novaHra.BalikKaret.Add(sedma);
                novaHra.BalikKaret.Add(osmicka);
                novaHra.BalikKaret.Add(devitka);
                novaHra.BalikKaret.Add(desitka);
                novaHra.BalikKaret.Add(spodek);
                novaHra.BalikKaret.Add(svrsek);
                novaHra.BalikKaret.Add(kral);
                novaHra.BalikKaret.Add(eso);
            }
        }

        private void VytvoreniGrafikyKaret()
        {
            for (int i = 0; i < 4; i++)
            {
                PictureBoxKarta sedmaPctBox = new PictureBoxKarta();
                sedmaPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                sedmaPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                sedmaPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(sedmaPctBox);

                PictureBoxKarta osmickaPctBox = new PictureBoxKarta();
                osmickaPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                osmickaPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                osmickaPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(osmickaPctBox);

                PictureBoxKarta devitkaPctBox = new PictureBoxKarta();
                devitkaPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                devitkaPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                devitkaPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(devitkaPctBox);

                PictureBoxKarta desitkaPctBox = new PictureBoxKarta();
                desitkaPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                desitkaPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                desitkaPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(desitkaPctBox);

                PictureBoxKarta spodekPctBox = new PictureBoxKarta();
                spodekPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                spodekPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                spodekPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(spodekPctBox);

                PictureBoxKarta svrsekPctBox = new PictureBoxKarta();
                svrsekPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                svrsekPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                svrsekPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(svrsekPctBox);

                PictureBoxKarta kralPctBox = new PictureBoxKarta();
                kralPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                kralPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                kralPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(kralPctBox);

                PictureBoxKarta esoPctBox = new PictureBoxKarta();
                esoPctBox.MouseHover += new EventHandler(OnHoverZobrazKartu);
                esoPctBox.MouseLeave += new EventHandler(OnHoverOutSkryjKartu);
                esoPctBox.Click += new EventHandler(KliknutiNaKartu);
                GrafikaKaret.Add(esoPctBox);
            }
        }

        public void StartHry()
        {
            // ziskani karet na pocatku hry

            for (int i = 0; i < novaHra.PocetKaretNaZacatku; i++)
            {
                Karta kartaProHrace = novaHra.BalikKaret[novaHra.BalikKaret.Count - 1];
                novaHra.Hrac1.PridejKartuDoRuky(kartaProHrace, GrafikaKaret[novaHra.VratIndexGrafikyKarty(kartaProHrace)]);
                OdeberPosledniKartuZBaliku();

                Karta kartaProtihrace = novaHra.BalikKaret[novaHra.BalikKaret.Count - 1];
                novaHra.ProtiHrac.PridejKartuDoRuky(kartaProtihrace, GrafikaKaret[novaHra.VratIndexGrafikyKarty(kartaProHrace)]);
                OdeberPosledniKartuZBaliku();
            }
            Karta kartaDoPole = novaHra.BalikKaret[novaHra.BalikKaret.Count - 1];
            novaHra.HraciPoleKaret.Add(kartaDoPole);
            OdeberPosledniKartuZBaliku();
            pictureBoxHrane.Image = Util.DejObrazekKarty(kartaDoPole);
            pictureBoxHrane.SizeMode = PictureBoxSizeMode.StretchImage;

            // pokud karta v poli je svrsek, tak se kontroluje jaká barva platí, podle poslední karty v baliku
            if (novaHra.HraciPoleKaret[novaHra.HraciPoleKaret.Count - 1].CisloKarty == CisloKaret.svrsek)
            {
                novaHra.AktualniZnak = novaHra.BalikKaret[novaHra.BalikKaret.Count - 1].Znak;
                novaHra.posledniHrana = kartaDoPole;
                pictureBox5.Image = Util.DejObrazekZnaku(novaHra.AktualniZnak);
            }
            else
            {
                novaHra.AktualniZnak = kartaDoPole.Znak;
                novaHra.posledniHrana = kartaDoPole;
                pictureBox5.Image = Util.DejObrazekZnaku(novaHra.AktualniZnak);
            }

            pictureBox5.Visible = true;
        }

        private void OdeberPosledniKartuZBaliku()
        {
            novaHra.BalikKaret.Remove(novaHra.BalikKaret[novaHra.BalikKaret.Count - 1]);
        }

        /// <summary>
        /// Pokud neni zadna karta v baliku, tak se pridaji karty z hraciho pole do baliku a zamicha se balik.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LiznutiKarty(object sender, EventArgs e)
        {
            //TODO: animace karty/ vykresleni karet prozatim
            if (novaHra.HrajeHrac && button1.Visible != true)
            {
                if (novaHra.BalikKaret.Count == 0)
                {
                    while (novaHra.HraciPoleKaret.Count > 0)
                    {
                        novaHra.BalikKaret.Add(novaHra.HraciPoleKaret[0]);
                        novaHra.HraciPoleKaret.RemoveAt(0);
                    }
                    ZamichaniKaret();
                }
                if (novaHra.PocetSedmicek > 0)
                {
                    for (int i = 0; i < novaHra.PocetSedmicek * 2; i++)
                    {
                        if (novaHra.HraciPoleKaret.Count == 1 && novaHra.BalikKaret.Count == 0)
                        {
                            // nic nedelej, protoze nelze uz pridat kartu do ruky
                        }
                        else
                        {
                            Karta kartaProHrace = novaHra.BalikKaret[novaHra.BalikKaret.Count - 1];
                            novaHra.Hrac1.PridejKartuDoRuky(kartaProHrace, GrafikaKaret[novaHra.VratIndexGrafikyKarty(kartaProHrace)]);
                            OdeberPosledniKartuZBaliku();

                            if (novaHra.BalikKaret.Count == 0)
                            {
                                while (novaHra.HraciPoleKaret.Count > 0)
                                {
                                    novaHra.BalikKaret.Add(novaHra.HraciPoleKaret[0]);
                                    novaHra.HraciPoleKaret.RemoveAt(0);
                                }
                                ZamichaniKaret();
                            }
                        }
                    }
                    novaHra.PocetSedmicek = 0;
                    novaHra.JeNevyzvednutaPenalizace = false;
                }
                else
                {
                    Karta kartaProHrace = novaHra.BalikKaret[novaHra.BalikKaret.Count - 1];
                    novaHra.Hrac1.PridejKartuDoRuky(kartaProHrace, GrafikaKaret[novaHra.VratIndexGrafikyKarty(kartaProHrace)]);
                    OdeberPosledniKartuZBaliku();
                }
                novaHra.HrajeHrac = false;
                prekresliKarty();
                tahProtiHrace();
            }
        }

        private void liznutiKartyProPocitac()
        {
            if (!novaHra.HrajeHrac)
            {
                if (novaHra.BalikKaret.Count == 0)
                {
                    while (novaHra.HraciPoleKaret.Count > 0)
                    {
                        novaHra.BalikKaret.Add(novaHra.HraciPoleKaret[0]);
                        novaHra.HraciPoleKaret.RemoveAt(0);
                    }
                    ZamichaniKaret();
                }

                if (novaHra.PocetSedmicek > 0)
                {
                    for (int i = 0; i < novaHra.PocetSedmicek * 2; i++)
                    {
                        Karta karta = novaHra.BalikKaret[novaHra.BalikKaret.Count - 1];
                        novaHra.ProtiHrac.PridejKartuDoRuky(karta, GrafikaKaret[novaHra.VratIndexGrafikyKarty(karta)]);
                        OdeberPosledniKartuZBaliku();
                    }
                    novaHra.PocetSedmicek = 0;
                }
                else
                {
                    Karta karta = novaHra.BalikKaret[novaHra.BalikKaret.Count - 1];
                    novaHra.ProtiHrac.PridejKartuDoRuky(karta, GrafikaKaret[novaHra.VratIndexGrafikyKarty(karta)]);
                    OdeberPosledniKartuZBaliku();
                }
                novaHra.HrajeHrac = true;
                prekresliKartyProtihrace();
            }
        }

        /// <summary>
        /// funkce, ktera prekresli karty na hraci pole (Form1)
        /// </summary>
        private void prekresliKarty()
        {
            int pocetKaret = novaHra.Hrac1.DejPocetKaret();

            for (int i = 0; i < pocetKaret; i++)
            {
                int polovina = pocetKaret / 2;
                int zacatekSouradnic = 500 - (25 * polovina);

                GrafikaKaret[novaHra.VratIndexGrafikyKarty(novaHra.Hrac1.KartyVRuce[i])].Location = new System.Drawing.Point(zacatekSouradnic + (25 * i), 400);
                GrafikaKaret[novaHra.VratIndexGrafikyKarty(novaHra.Hrac1.KartyVRuce[i])].Image = Util.DejObrazekKarty(novaHra.Hrac1.KartyVRuce[i]);
                this.Controls.Add(GrafikaKaret[novaHra.VratIndexGrafikyKarty(novaHra.Hrac1.KartyVRuce[i])]);
            }
        }

        /// <summary>
        /// prekresli karty pro protihrace
        /// </summary>
        private void prekresliKartyProtihrace()
        {
            int pocetKaretProtiHrace = novaHra.ProtiHrac.DejPocetKaret();
            for (int i = 0; i < pocetKaretProtiHrace; i++)
            {
                int polovina = pocetKaretProtiHrace / 2;
                int zacatekSouradnic = 500 - (25 * polovina);

                GrafikaKaret[novaHra.VratIndexGrafikyKarty(novaHra.ProtiHrac.KartyVRuce[i])].Location = new System.Drawing.Point(zacatekSouradnic + (25 * i), 0);
                this.Controls.Add(GrafikaKaret[novaHra.VratIndexGrafikyKarty(novaHra.ProtiHrac.KartyVRuce[i])]);
            }
        }

        private void OnHoverZobrazKartu(object sender, EventArgs e)
        {
            PictureBoxKarta pctBox = sender as PictureBoxKarta;
            Karta karta = novaHra.VratKartuGrafikyNaIndexu(GrafikaKaret.IndexOf(pctBox));

            if (novaHra.Hrac1.MaIdentickouKartu(karta.CisloKarty, karta.Znak))
            {
                pctBox.BringToFront();
            }
        }

        private void OnHoverOutSkryjKartu(object sender, EventArgs e)
        {
            PictureBoxKarta pctBox = sender as PictureBoxKarta;
            Karta karta = novaHra.VratKartuGrafikyNaIndexu(GrafikaKaret.IndexOf(pctBox));
            if (novaHra.Hrac1.MaIdentickouKartu(karta.CisloKarty, karta.Znak))
            {
                prekresliKarty();
            }
        }

        private void KliknutiNaKartu(object sender, EventArgs e)
        {
            if (novaHra.HrajeHrac)
            {
                PictureBoxKarta pctBox = sender as PictureBoxKarta;
                Karta karta = novaHra.VratKartuGrafikyNaIndexu(GrafikaKaret.IndexOf(pctBox));
                if (novaHra.Hrac1.MaIdentickouKartu(karta.CisloKarty, karta.Znak))
                {
                    karta = novaHra.Hrac1.DejPrvniNalezenouKartu(karta.CisloKarty, karta.Znak);
                    if (novaHra.JeNevyzvednutaPenalizace)
                    {
                        if (karta.CisloKarty == CisloKaret.sedma && novaHra.posledniHrana.CisloKarty == CisloKaret.sedma)
                        {
                            nastaveniKaret(karta);
                            novaHra.PocetSedmicek++;
                            novaHra.HrajeHrac = false;
                            novaHra.JeNevyzvednutaPenalizace = true;
                        }
                        else if (novaHra.posledniHrana.CisloKarty == CisloKaret.eso)
                        {
                            if (novaHra.Hrac1.MaKartu(CisloKaret.eso))
                            {
                                if (karta.CisloKarty == CisloKaret.eso)
                                {
                                    nastaveniKaret(karta);
                                    novaHra.HrajeHrac = false;
                                    novaHra.JeNevyzvednutaPenalizace = true;
                                }
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
                        else if (karta.CisloKarty == CisloKaret.sedma && (novaHra.posledniHrana.CisloKarty == CisloKaret.sedma || novaHra.AktualniZnak == karta.Znak))
                        {
                            nastaveniKaret(karta);
                            novaHra.PocetSedmicek++;
                            novaHra.HrajeHrac = false;
                            novaHra.JeNevyzvednutaPenalizace = true;
                        }
                        else if (karta.CisloKarty == CisloKaret.eso && (novaHra.posledniHrana.CisloKarty == CisloKaret.eso || novaHra.AktualniZnak == karta.Znak))
                        {
                            nastaveniKaret(karta);
                            novaHra.HrajeHrac = false;
                            novaHra.JeNevyzvednutaPenalizace = true;
                        }
                        else
                        {
                            if (karta.CisloKarty == novaHra.posledniHrana.CisloKarty || karta.Znak == novaHra.AktualniZnak)
                            {
                                nastaveniKaret(karta);
                                novaHra.HrajeHrac = false;
                            }
                        }
                    }

                    if (novaHra.Hrac1.DejPocetKaret() == 0)
                    {
                        prekresliKarty();
                        zakazHraciInterakci();
                        label2.Text = "YOU WIN";
                        label2.Visible = true;
                        //TODO: vypis na obrazovku "YOU WIN", prehod po 5ti sekundach na druhy form (menu, kde bude nova hra nebo nacti hru)
                    }
                    else
                    {
                        if (!novaHra.HrajeHrac)
                        {
                            prekresliKarty();
                            zakazHraciInterakci();
                            tahProtiHrace();
                        }
                    }
                }
            }
        }

        private void tahProtiHrace()
        {
            if (!novaHra.HrajeHrac)
            {
                if (novaHra.JeNevyzvednutaPenalizace)
                {
                    if (novaHra.posledniHrana.CisloKarty == CisloKaret.sedma)
                    {
                        if (novaHra.ProtiHrac.MaKartu(CisloKaret.sedma))
                        {
                            nastaveniKaret(novaHra.ProtiHrac.DejPrvniNalezenouKartu(CisloKaret.sedma));
                            novaHra.PocetSedmicek++;
                            novaHra.HrajeHrac = true;
                            novaHra.JeNevyzvednutaPenalizace = true;
                        }
                        else
                        {
                            liznutiKartyProPocitac();
                            novaHra.HrajeHrac = true;
                            novaHra.JeNevyzvednutaPenalizace = false;
                        }
                    }
                    else if (novaHra.posledniHrana.CisloKarty == CisloKaret.eso)
                    {
                        if (novaHra.ProtiHrac.MaKartu(CisloKaret.eso))
                        {
                            if (novaHra.ProtiHrac.MaKartu(CisloKaret.eso))
                            {
                                nastaveniKaret(novaHra.ProtiHrac.DejPrvniNalezenouKartu(CisloKaret.eso));
                                novaHra.HrajeHrac = true;
                                novaHra.JeNevyzvednutaPenalizace = true;
                                button1.Visible = true;
                            }
                        }
                        else
                        {
                            novaHra.HrajeHrac = true;
                            novaHra.JeNevyzvednutaPenalizace = false;
                            Console.WriteLine("test");
                        }
                    }
                }
                else
                {
                    if (novaHra.Hrac1.DejPocetKaret() == 1)
                    {
                        int sedmaIndex = novaHra.ProtiHrac.MaKartuAJeHratelna(CisloKaret.sedma, novaHra.AktualniZnak);
                        int esoIndex = novaHra.ProtiHrac.MaKartuAJeHratelna(CisloKaret.eso, novaHra.AktualniZnak);
                        int svrsekIndex = novaHra.ProtiHrac.MaKartuAJeHratelna(CisloKaret.svrsek, novaHra.AktualniZnak);

                        if (sedmaIndex > -1)
                        {
                            nastaveniKaret(novaHra.ProtiHrac.DejKartuNaIndexu(sedmaIndex));
                            novaHra.HrajeHrac = true;
                            novaHra.PocetSedmicek++;
                            novaHra.JeNevyzvednutaPenalizace = true;
                        }
                        else if (esoIndex > -1)
                        {
                            nastaveniKaret(novaHra.ProtiHrac.DejKartuNaIndexu(esoIndex));
                            novaHra.HrajeHrac = true;
                            novaHra.JeNevyzvednutaPenalizace = true;
                            button1.Visible = true;
                        }
                        else if (svrsekIndex > -1)
                        {
                            novaHra.AktualniZnak = novaHra.ProtiHrac.VratZnak(novaHra.AktualniZnak);
                            nastaveniKaret(novaHra.ProtiHrac.DejKartuNaIndexu(svrsekIndex));
                            novaHra.HrajeHrac = true;
                        }
                        else
                        {
                            int normalniKartaIndex = novaHra.ProtiHrac.MaNormalniKartu(novaHra.posledniHrana, novaHra.AktualniZnak);
                            if (normalniKartaIndex > -1)
                            {
                                nastaveniKaret(novaHra.ProtiHrac.DejKartuNaIndexu(normalniKartaIndex));
                                novaHra.HrajeHrac = true;
                            }
                            else
                            {
                                liznutiKartyProPocitac();
                            }
                        }
                    }
                    else
                    {
                        int normalniKartaIndex = novaHra.ProtiHrac.MaNormalniKartu(novaHra.posledniHrana, novaHra.AktualniZnak);
                        if (normalniKartaIndex > -1)
                        {
                            nastaveniKaret(novaHra.ProtiHrac.DejKartuNaIndexu(normalniKartaIndex));
                            novaHra.HrajeHrac = true;
                        }
                        else
                        {
                            int sedmaIndex = novaHra.ProtiHrac.MaKartuAJeHratelna(CisloKaret.sedma, novaHra.AktualniZnak);
                            int esoIndex = novaHra.ProtiHrac.MaKartuAJeHratelna(CisloKaret.eso, novaHra.AktualniZnak);
                            int svrsekIndex = novaHra.ProtiHrac.MaKartuAJeHratelna(CisloKaret.svrsek, novaHra.AktualniZnak);

                            if (esoIndex > -1)
                            {
                                nastaveniKaret(novaHra.ProtiHrac.DejKartuNaIndexu(esoIndex));
                                novaHra.HrajeHrac = true;
                                novaHra.JeNevyzvednutaPenalizace = true;
                                button1.Visible = true;
                            }
                            else if (svrsekIndex > -1)
                            {
                                novaHra.AktualniZnak = novaHra.ProtiHrac.VratZnak(novaHra.AktualniZnak);
                                nastaveniKaret(novaHra.ProtiHrac.DejKartuNaIndexu(svrsekIndex));
                                novaHra.HrajeHrac = true;
                            }
                            else if (sedmaIndex > -1)
                            {
                                nastaveniKaret(novaHra.ProtiHrac.DejKartuNaIndexu(sedmaIndex));
                                novaHra.HrajeHrac = true;
                                novaHra.PocetSedmicek++;
                                novaHra.JeNevyzvednutaPenalizace = true;
                            }
                            else
                            {
                                liznutiKartyProPocitac();
                            }
                        }
                    }
                }
                if (novaHra.ProtiHrac.DejPocetKaret() == 0)
                {
                    prekresliKarty();
                    zakazHraciInterakci();
                    label2.Text = "YOU LOSE";
                    label2.ForeColor = System.Drawing.Color.Red;
                    label2.Visible = true;

                    foreach (var karta in novaHra.Hrac1.KartyVRuce)
                    {
                        GrafikaKaret[novaHra.VratIndexGrafikyKarty(karta)].Visible = false;
                    }
                    //TODO: vypis na obrazovku "YOU WIN", prehod po 5ti sekundach na druhy form (menu, kde bude nova hra nebo nacti hru)
                }
                else
                {
                    prekresliKartyProtihrace();
                    uvolniHraciInterakci();
                }
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

        public void AnimaceKarty(bool jeHrac, PictureBoxKarta karta)
        {
            int xKrok = (karta.Location.X-500)/50;
            int yKrok = (200- karta.Location.Y) /50;
            if (jeHrac)
            {
                zakazHraciInterakci();
            }
            for (int i = 0; i < 50; i++)
            {
                karta.Location = new System.Drawing.Point(karta.Location.X + xKrok, yKrok + karta.Location.Y);
                this.Refresh();
            }
        }

        /// <summary>
        /// Event, ktery zvoli barvu karty na kule, zavola metodu PrekresliKarty, schovejVybiraniZnaku a tahProtiHrace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            novaHra.AktualniZnak = ZnakyKaret.kule;
            novaHra.HrajeHrac = false;
            uvolniHraciInterakci();
            schovejVybiraniZnaku();
            pictureBox5.Image = Util.DejObrazekZnaku(novaHra.AktualniZnak);
            pictureBox5.Visible = true;
            tahProtiHrace();
        }

        /// <summary>
        ///  Event, ktery zvoli barvu karty na listy, zavola metodu PrekresliKarty, schovejVybiraniZnaku a tahProtiHrace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            novaHra.AktualniZnak = ZnakyKaret.list;
            novaHra.HrajeHrac = false;
            uvolniHraciInterakci();
            schovejVybiraniZnaku();
            pictureBox5.Image = Util.DejObrazekZnaku(novaHra.AktualniZnak);
            pictureBox5.Visible = true;
            tahProtiHrace();
        }

        /// <summary>
        ///  Event, ktery zvoli barvu karty na srdce, zavola metodu PrekresliKarty, schovejVybiraniZnaku a tahProtiHrace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            novaHra.AktualniZnak = ZnakyKaret.srdce;
            novaHra.HrajeHrac = false;
            uvolniHraciInterakci();
            schovejVybiraniZnaku();
            pictureBox5.Image = Util.DejObrazekZnaku(novaHra.AktualniZnak);
            pictureBox5.Visible = true;
            tahProtiHrace();
        }

        /// <summary>
        ///  Event, ktery zvoli barvu karty na zaludy, zavola metodu PrekresliKarty, schovejVybiraniZnaku a tahProtiHrace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            novaHra.AktualniZnak = ZnakyKaret.zalud;
            novaHra.HrajeHrac = false;
            uvolniHraciInterakci();
            schovejVybiraniZnaku();
            pictureBox5.Image = Util.DejObrazekZnaku(novaHra.AktualniZnak);
            pictureBox5.Visible = true;
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
                AnimaceKarty(true, GrafikaKaret[novaHra.VratIndexGrafikyKarty(karta)]);

                novaHra.Hrac1.OdeberKartu(karta, GrafikaKaret[novaHra.VratIndexGrafikyKarty(karta)]);
                novaHra.HraciPoleKaret.Add(karta);
                novaHra.posledniHrana = karta;
                novaHra.AktualniZnak = karta.Znak;

                pictureBoxHrane.Image = Util.DejObrazekKarty(karta);
                pictureBox5.Image = Util.DejObrazekZnaku(novaHra.AktualniZnak);
            }
            else
            {
                AnimaceKarty(false, GrafikaKaret[novaHra.VratIndexGrafikyKarty(karta)]);

                novaHra.ProtiHrac.OdeberKartu(karta, GrafikaKaret[novaHra.VratIndexGrafikyKarty(karta)]);
                novaHra.HraciPoleKaret.Add(karta);
                novaHra.posledniHrana = karta;
                novaHra.AktualniZnak = karta.Znak;

                pictureBoxHrane.Image = Util.DejObrazekKarty(karta);
                pictureBox5.Image = Util.DejObrazekZnaku(novaHra.AktualniZnak);
            }
        }

        private void zakazHraciInterakci()
        {
            foreach (Karta k in novaHra.Hrac1.KartyVRuce)
            {
                GrafikaKaret[novaHra.VratIndexGrafikyKarty(k)].Enabled = false;
            }
            pictureBoxBalik.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void uvolniHraciInterakci()
        {
            foreach (Karta k in novaHra.Hrac1.KartyVRuce)
            {
                GrafikaKaret[novaHra.VratIndexGrafikyKarty(k)].Enabled = true;
            }
            pictureBoxBalik.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        /// <summary>
        /// tlacitko "stojim", ukonci kolo, pokud hrac nema eso nebo ho nechce zahrat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            novaHra.JeNevyzvednutaPenalizace = false;
            novaHra.HrajeHrac = false;
            button1.Visible = false;
            tahProtiHrace();
        }

        /// <summary>
        /// zavre hru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// prejde do menu a ukonci rozehranou hru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            FormMenu.Show();
            this.Close();
        }

        /// <summary>
        /// serializuje a ulozi hru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("save.bin", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, novaHra);
            stream.Close();
        }
    }
}