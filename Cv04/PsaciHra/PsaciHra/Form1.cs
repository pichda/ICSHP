using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsaciHra
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();

        List<string> wordList = new List<string>();

        public Form1()
        {
            InitializeComponent();
            stats.UpdatedStats += Stats_UpdatedStats;
            wordList.Add("AUTO");
            wordList.Add("HONDA");
            wordList.Add("CIVIC");

            // nastaveni intervalu na 10s.
            timer1.Interval = 5000;
        }

        private void Stats_UpdatedStats(object sender, EventArgs e)
        {
            correctLabel.Text = $"Correct: {stats.Correct}";
            missedLabel.Text = $"Missed: {stats.Missed}";
            accuracyLabel.Text = $"Accuracy: {stats.Accuracy}%";
        }


        /// <summary>
        /// Event, který generuje náhodne písmeno, při každém časovém intervalu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, EventArgs e)
        {
            string slovo = wordList.ElementAt(random.Next(0, wordList.Count()-1));

            for (int i = 0; i < slovo.Length; i++)
            {
                gameListBox.Items.Add((Keys)slovo[i]);
            }

            gameListBox.SelectedItem = 0;

            //maximum znaků na 40
            if (gameListBox.Items.Count > 40)
            {
                timer1.Stop();
                gameListBox.Items.Clear();
                gameListBox.Items.Add("Game over!");
                gameListBox.Refresh();
                System.Threading.Thread.Sleep(3000);
                Application.Exit();
            }
            else
            {
                gameListBox.Refresh();
            }
        }
        /// <summary>
        /// Event, který se spustí při zmáčknutí klávesy a vyhledává, jestli je v listboxu.
        /// Mění podle času obtížnost. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameListBox_KeyDown(object sender, KeyEventArgs e)
        {

            gameListBox.SelectedItem = 0;

            if (gameListBox.Items.IndexOf(e.KeyCode)==0)
            {
                gameListBox.Items.Remove(e.KeyCode);
                gameListBox.Refresh();
                stats.Update(true);
            }
            else
            {
                stats.Update(false);
            }

            if (timer1.Interval > 5000)
            {
                timer1.Interval -= 500;
                difficultProgressBar.Value = 5000 - timer1.Interval;
            }
            else if (timer1.Interval > 2000)
            {
                timer1.Interval -= 200;
                difficultProgressBar.Value = 5000 - timer1.Interval;
            }
            else if (timer1.Interval > 1000 && timer1.Interval-8>0)
            {
                timer1.Interval -= 100;
                difficultProgressBar.Value = 5000 - timer1.Interval;
            }

        }
    }
}
