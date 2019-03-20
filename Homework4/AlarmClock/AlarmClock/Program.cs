using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Timers;
using System.IO;
using System.Reflection;
namespace timerAlarm
{
    public class TimerForm : System.Windows.Forms.Form
    {
        //Controls and Components
        private System.Windows.Forms.TextBox timerInput;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ResetButton;
        private System.ComponentModel.IContainer components;
        //Timer and associated variables
        private System.Timers.Timer timerClock = new System.Timers.Timer();
        private int clockTime = 0;
        private int alarmTime = 0;
        public TimerForm()
        {
            InitializeComponent();
            InitializeTimer();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <SUMMARY>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </SUMMARY>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.
              Resources.ResourceManager(typeof(TimerForm));
            this.timerInput = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // timerInput
            //
            this.timerInput.Location = new System.Drawing.Point(12, 13);
            this.timerInput.Name = "timerInput";
            this.timerInput.Size = new System.Drawing.Size(50, 20);
            this.timerInput.TabIndex = 0;
            this.timerInput.Text = "00:00:00";
            //
            // StartButton
            //
            this.StartButton.FlatStyle = System.Windows.Forms.
              FlatStyle.System;
            this.StartButton.Location = new System.Drawing.Point(75, 11);
            this.StartButton.Name = "StartButton";
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.Click += new System.EventHandler
              (this.StartButton_Click);
            //
            // ResetButton
            //
            this.ResetButton.FlatStyle = System.Windows.Forms.
              FlatStyle.System;
            this.ResetButton.Location = new System.Drawing.Point(161, 11);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.TabIndex = 2;
            this.ResetButton.Text = "Reset";
            this.ResetButton.Click += new
              System.EventHandler(this.ResetButton_Click);
            //
            // TimerForm
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(247, 46);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
         this.ResetButton,
         this.StartButton,
         this.timerInput});
            this.FormBorderStyle = System.Windows.Forms.
              FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject(Resouces._1)));
            this.MaximizeBox = false;
            this.Name = "TimerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alarm Timer";
            this.Resize += new System.EventHandler(this.
              TimerForm_Resized);
            this.ResumeLayout(false);
        }
        #endregion
        public void InitializeTimer()
        {
            this.timerClock.Elapsed += new ElapsedEventHandler(OnTimer);
            this.timerClock.Interval = 1000;
            this.timerClock.Enabled = true;
        }
        [STAThread]
        static void Main()
        {
            Application.Run(new TimerForm());
        }
        private void TimerForm_Resized(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
        private void StartButton_Click(object sender, System.EventArgs e)
        {
            this.clockTime = 0;
            inputToSeconds(this.timerInput.Text);
        }
        private void ResetButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.clockTime = 0;
                this.alarmTime = 0;
                this.timerInput.Text = "00:00:00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ResetButton_Click(): " + ex.Message);
            }
        }
        public void OnTimer(Object source, ElapsedEventArgs e)
        {
            try
            {
                this.clockTime++;
                int countdown = this.alarmTime - this.clockTime;
                if (this.alarmTime != 0)
                {
                    this.timerInput.Text = secondsToTime(countdown);
                }
                //Sound Alarm
                if (this.clockTime == this.alarmTime)
                {
                    MessageBox.Show("Play Sound");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OnTimer(): " + ex.Message);
            }
        }
        private void inputToSeconds(string timerInput)
        {
            try
            {
                string[] timeArray = new string[3];
                int minutes = 0;
                int hours = 0;
                int seconds = 0;
                int occurence = 0;
                int length = 0;
                occurence = timerInput.LastIndexOf(":");
                length = timerInput.Length;
                //Check for invalid input
                if (occurence == -1 || length != 8)
                {
                    MessageBox.Show("Invalid Time Format.");
                    ResetButton_Click(null, null);
                }
                else
                {
                    timeArray = timerInput.Split(':');
                    seconds = Convert.ToInt32(timeArray[2]);
                    minutes = Convert.ToInt32(timeArray[1]);
                    hours = Convert.ToInt32(timeArray[0]);
                    this.alarmTime += seconds;
                    this.alarmTime += minutes * 60;
                    this.alarmTime += (hours * 60) * 60;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("inputToSeconds(): " + e.Message);
            }
        }
        public string secondsToTime(int seconds)
        {
            int minutes = 0;
            int hours = 0;
            while (seconds >= 60)
            {
                minutes += 1;
                seconds -= 60;
            }
            while (minutes >= 60)
            {
                hours += 1;
                minutes -= 60;
            }
            string strHours = hours.ToString();
            string strMinutes = minutes.ToString();
            string strSeconds = seconds.ToString();
            if (strHours.Length < 2)
                strHours = "0" + strHours;
            if (strMinutes.Length < 2)
                strMinutes = "0" + strMinutes;
            if (strSeconds.Length < 2)
                strSeconds = "0" + strSeconds;
            return strHours + ":" + strMinutes + ":" + strSeconds;
        }
    }
}