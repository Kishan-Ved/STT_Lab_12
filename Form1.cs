using System;
using System.Drawing;
using System.Windows.Forms;

namespace alarmFormBased
{
    public partial class Form1 : Form
    {
        private TimeSpan targetTime;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        // Called when the Start button is clicked
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (TimeSpan.TryParse(textBoxTime.Text, out targetTime))
            {
                timerCheck.Start(); // Begin checking every second
            }
            else
            {
                MessageBox.Show("Invalid time format. Please enter in HH:MM:SS", "Error");
            }
        }

        // Called every second while timer is running
        private void timerCheck_Tick(object sender, EventArgs e)
        {
            // Change background color randomly
            this.BackColor = Color.FromArgb(
                random.Next(256), random.Next(256), random.Next(256));

            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            // Compare current time with target time
            if (currentTime.Hours == targetTime.Hours &&
                currentTime.Minutes == targetTime.Minutes &&
                currentTime.Seconds == targetTime.Seconds)
            {
                timerCheck.Stop();
                MessageBox.Show("Ring... Ring... Ring...", "Alarm");
            }
        }
    }
}
