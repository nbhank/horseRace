using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRace
{
    public partial class GameForm : Form
    {
        public static string fResult;


        public string result;

        public GameForm()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(result);  // using instance variable declared in GameForm
            //MessageBox.Show(fResult); // using static variable declared in GameForm
            MessageBox.Show(Horse.hResult);  //using static variable in Horse
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int numberOfHorses = int.Parse(txtNumberOfHorses.Text);
            int startX = 10;
            int startY = 60;

            Random r = new Random();
            int minSpeed = 5;
            int maxSpeed = 10;
            int minInterval = 200;
            int maxInterval = 600;

            for (int i = 0; i < numberOfHorses; i++)
            {
                int speed = r.Next(minSpeed, maxSpeed);
                int interval = r.Next(minInterval, maxInterval);


                Horse h = new Horse(this, pnlFinishLine, interval, speed);
                h.Left = startX;
                h.Top = startY;
                h.Width = 30;
                h.Height = 20;
                h.Text = i.ToString();
                h.IsStarted = true;
                this.Controls.Add(h);
                startY += 30;

            }

        }
    }
}
