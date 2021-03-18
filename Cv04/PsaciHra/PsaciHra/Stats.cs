using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsaciHra
{
    class Stats
    {
        public delegate void UpdatedStatsEventHandler(object sender, EventArgs e);
        public int Correct { get; private set; }
        public int Missed { get; private set; }
        public int Accuracy { get; private set; }
        public event UpdatedStatsEventHandler UpdatedStats;

        public Stats()
        {
            Correct = 0;
            Missed = 0;
            Accuracy = 100;
        }

        private void OnUpdatedStats()
        {
            UpdatedStatsEventHandler handler = UpdatedStats;
            if (handler != null)
                handler(this, new EventArgs());
        }

        public void Update(bool correctKey)
        {
            if (correctKey)
            {
                Correct++;
            }
            else
            {
                Missed++;
            }
            double acc = ((Double)Correct / ((Double)Correct + (Double)Missed))*100.0;
            Accuracy = (int)acc;
            OnUpdatedStats();
        }
    }
}
