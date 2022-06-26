using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace HorseRace
{
    public class Horse : Button
    {

        public static string hResult;  //static variable for result in Horse

        private Timer timer;

        private bool isFinished = false;

        private bool isStarted = false;

        private int interval = 100;

        private int displacement = 50;

        private Panel finishLine;

        public bool IsFinished { get => isFinished; set => isFinished = value; }
        public bool IsStarted {
            get { return isStarted;  }

            set { isStarted = value;
                timer.Enabled = isStarted;
            }
        }
        public int Interval { get => interval; set => interval = value; }
        public int Displacement { get => displacement; set => displacement = value; }

        private GameForm f;



        public Horse(GameForm frm, Panel finishLine, int interval, int displacement)
        {
            this.f = frm;
            this.finishLine = finishLine;

            timer = new Timer();
            this.interval = interval;
            this.displacement = displacement;

            timer.Interval = this.interval;
            timer.Enabled = isStarted;
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            this.Left += displacement;
            if (!isFinished)
            {
                if (this.Left + this.Width > finishLine.Left )
                {
                    isFinished = true;

                    timer.Stop();
                    //f.result += this.Text + "\n"; // if instance variable is used;
                    //GameForm.fResult += this.Text + "\n";  // if static variable is used (declared in GameForm)
                    hResult += this.Text + "\n"; // if static variable is used (dclared in Horse)



                }

            }


        }
    }
}
