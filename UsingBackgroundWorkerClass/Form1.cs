using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace UsingBackgroundWorkerClass
{
    public partial class Form1 : Form
    {
        private BackgroundWorker worker;
        public Form1()
        {
            InitializeComponent();

            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                new Action<string>(UpdateLabel),
                e.Result.ToString());
            }
            else
            {
                UpdateLabel(e.Result.ToString());
            }
        }

        private void UpdateLabel(string text)
        {
            lblResult.Text = text;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = DoIntensiveCalculations();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        private object DoIntensiveCalculations()
        {
            //We are simulating intensive calculations
            //by doing nonsense divisions.
            double result = 1000000000d;
            var maxValue = Int32.MaxValue;
            for (int i = 1; i < maxValue; i++)
            {
                result /= i;
            }
            return result + 10d;
        }
    }
}
