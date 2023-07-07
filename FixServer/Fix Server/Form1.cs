using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Fix_Server
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = (5000);
            timer1.Tick += new EventHandler(showForms);
            timer1.Start();
            InitializeComponent();
            timer2.Interval = (5000);
            timer2.Tick += new EventHandler(fixProccess);
            timer2.Start();
        }
        int count;


        
        private void Form1_Load(object sender, EventArgs e)
        {
            showForms(sender, e);

        }
        private void showForms(object sender, EventArgs e)
        {
 
            Process[] allProcs = Process.GetProcesses();

            count = 0;
            foreach (Process proc in allProcs)
            {
                ProcessThreadCollection myThreads = proc.Threads;
                if (proc.ProcessName == "cmd")
                {
                    count++;
                }

            }
            proccessCount.Text = count.ToString();

        }

        private void fixProccess(object sender, EventArgs e)
        {
            Process[] workers = Process.GetProcessesByName("cmd");
            if (workers.Length != 0)
            {
                foreach (Process worker in workers)
                {
                    count++;
                    worker.Kill();
                    worker.WaitForExit();
                    worker.Dispose();
                }
            }

        }

    }
}
