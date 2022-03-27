using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public static int A = 0;
        private void Form5_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        public void RunCommand(String command)
        {
            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            cmd.FileName = @"cmd";
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;
            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;
            cmd.RedirectStandardInput = true;
            cmd.RedirectStandardError = true;
            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();
            process.StandardInput.Write(@command + Environment.NewLine);
            process.StandardInput.Close();
            string result = process.StandardOutput.ReadToEnd();
            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(result);
            sb.Append("\r\n");
            process.WaitForExit();
            process.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            A++;
            if(A == 10)
            {
                A = 0;
                timer1.Stop();
                this.Close();
            }
            else
            {
                progressBar1.Step = r.Next(20,50);
                progressBar1.PerformStep();
            }
        }
    }
}
