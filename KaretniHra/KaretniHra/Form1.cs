using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KaretniHra
{
    public partial class Form1 : Form
    {
        public Hrac Hrac1 { get; set; }
        public Hrac ProtiHrac { get; set; }
        public List<Karta> BalikKaret { get; set; }
        public List<Karta> HraciPoleKaret { get; set; }

        public Karta posledniHrana { get; set; }

        public int PocetKaretNaZacatku { get; set; }

        public ZnakyKaret AktualniZnak { get; set; }  // aktulani znak/barva

        public Form1()
        {
            InitializeComponent();

            Hrac1 = new Hrac();
            ProtiHrac = new Hrac();

            BalikKaret = new List<Karta>();
            HraciPoleKaret = new List<Karta>();
            PocetKaretNaZacatku = 4;
            inicializaceHry();
            StartHry();
            ZobrazKarty();

            //PictureBox pctBox = new PictureBox();
            //pctBox.Location = new System.Drawing.Point(200,200);
            //pctBox.ClientSize = new Size(100, 150);
            //pctBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //pctBox.Image = Properties.Resources.kule_desitka;
        }

        public void inicializaceHry()
        {
            VytvoreniHracichKaret();
            Shuffle();
        }

        private void Shuffle()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < BalikKaret.Count / 2; j++)
                {
                    int prvniNahodnyPrvek = Util.randomCisloVRozmezi(0, BalikKaret.Count - 1);
                    int druhyNahodnyPrvek = Util.randomCisloVRozmezi(0, BalikKaret.Count - 1);

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
                kartaProHrace.JeHrace = true;
                kartaProHrace.Image = Util.DejObrazekKarty(kartaProHrace);
                Hrac1.KartyVRuce.Add(kartaProHrace);
                OdeberPosledniKartuZBaliku();
                //TODO: animace
                Karta kartaProtihrace = BalikKaret[BalikKaret.Count - 1];
                kartaProtihrace.Image = Properties.Resources.zada;
                ProtiHrac.KartyVRuce.Add(kartaProtihrace);
                OdeberPosledniKartuZBaliku();
                //TODO: animace
            }
            HraciPoleKaret.Add(BalikKaret[BalikKaret.Count - 1]);
            OdeberPosledniKartuZBaliku();
            HraciPoleKaret[0].Image = Util.DejObrazekKarty(HraciPoleKaret[0]);
            HraciPoleKaret[0].Visible = true;
            pictureBoxHrane.Image = HraciPoleKaret[0].Image;
            pictureBoxHrane.SizeMode = PictureBoxSizeMode.StretchImage;

            if (HraciPoleKaret[HraciPoleKaret.Count - 1].CisloKarty == CisloKaret.svrsek)
            {
                AktualniZnak = HraciPoleKaret[HraciPoleKaret.Count - 1].Znak;
            }
        }

        private void OdeberPosledniKartuZBaliku()
        {
            BalikKaret.Remove(BalikKaret[BalikKaret.Count - 1]);
        }

        private void LiznutiKarty(object sender, EventArgs e)
        {
        }

        private void ZobrazKarty()
        {
            // 500 x 400
            int pocetKaret = Hrac1.KartyVRuce.Count;
            if (pocetKaret % 2 == 0)
            {
                for (int i = 0; i < pocetKaret; i++)
                {
                    if(i<= pocetKaret / 2)
                    {
                        Hrac1.KartyVRuce[i].Location = new System.Drawing.Point(500 - (25 * (pocetKaret - i)), 400);
                        this.Controls.Add(Hrac1.KartyVRuce[i]);

                        //Hrac1.KartyVRuce[i].Visible = true;
                        //Hrac1.KartyVRuce[i].BringToFront();
                        //Hrac1.KartyVRuce[i].Refresh();

                    }
                    else
                    {
                        Hrac1.KartyVRuce[i].Location = new System.Drawing.Point(500 + (25 * (pocetKaret - i)), 400);
                        this.Controls.Add(Hrac1.KartyVRuce[i]);
                        //Hrac1.KartyVRuce[i].Visible = true;
                    }
                   
                }
            }
            else
            {
                for (int i = 0; i < pocetKaret; i++)
                {
                    if (i <= pocetKaret / 2)
                    {
                        Hrac1.KartyVRuce[i].Location = new System.Drawing.Point(500 - (25 * (pocetKaret - i)), 400);
                        this.Controls.Add(Hrac1.KartyVRuce[i]);
                        //Hrac1.KartyVRuce[i].Visible = true;
                    }
                    else if(i == (pocetKaret / 2) + 1)
                    {
                        Hrac1.KartyVRuce[i].Location = new System.Drawing.Point(500, 400);
                        this.Controls.Add(Hrac1.KartyVRuce[i]);
                        // Hrac1.KartyVRuce[i].Visible = true;
                    }
                    else
                    {
                        Hrac1.KartyVRuce[i].Location = new System.Drawing.Point(500 + (25 * (pocetKaret - i)), 400);
                        this.Controls.Add(Hrac1.KartyVRuce[i]);
                       // Hrac1.KartyVRuce[i].Visible = true;
                    }
                }
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
                ZobrazKarty();
            }
        }

        private void KliknutiNaKartu(object sender, EventArgs e)
        {
            Karta karta = sender as Karta;
            if (karta.JeHrace)
            {
                if (karta.CisloKarty == HraciPoleKaret[HraciPoleKaret.Count - 1].CisloKarty || karta.Znak == HraciPoleKaret[HraciPoleKaret.Count - 1].Znak)
                {
                }
            }
        }

        public void AnimaceKarty()
        {
            foreach (Karta karta in Hrac1.KartyVRuce)
            {
                karta.Enabled = false;
            }

            System.Threading.Thread.Sleep(300);

            foreach (Karta karta in Hrac1.KartyVRuce)
            {
                karta.Enabled = true;
            }
        }
    }
}