using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            String ID = Form4.nextID;
            label4.Text = ID;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(" ", "");
            if (textBox1.Text.Equals(""))
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
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
        String ina = "";
        public void A()
        {
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " del#WindowLocker.yesNo.Admin.stop " + Form1.LoginID + " " + Form1.LoginPassword);
            Thread.Sleep(1000);
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " WindowLocker.exe#"+ina+ " " +Form1.LoginID + " " + Form1.LoginPassword);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to lock your PC with WindowLocker?Please complete the important tasks to lock.", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ina = textBox1.Text;
                System.Threading.Thread th = new System.Threading.Thread(A);
                th.Start();
            }
        }
        public void B()
        {
            for (int i = 0; i < 10; i++)
            {
                RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " WindowLockerSetting.exe " + Form1.LoginID + " " + Form1.LoginPassword);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            System.Threading.Thread th = new System.Threading.Thread(B);
            th.Start();
        }
    }
}
