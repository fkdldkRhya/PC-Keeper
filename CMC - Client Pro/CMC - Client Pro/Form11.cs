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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
            String ID = Form4.nextID;
            label4.Text = ID;
        }
        public static String A = "";
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void A_1()
        {
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " " + A + " " + Form1.LoginID + " " + Form1.LoginPassword);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                A = textBox1.Text.Replace(" ", "#");
                Thread th = new Thread(A_1);th.Start();
                MessageBox.Show("CMD명령어 전송을 완료함.","INFO",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (!textBox1.Text.Equals(""))
                {
                    A = textBox1.Text.Replace(" ", "#");
                    Thread th = new Thread(A_1); th.Start();
                    MessageBox.Show("CMD명령어 전송을 완료함.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
