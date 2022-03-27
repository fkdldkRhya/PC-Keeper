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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        public static String LoginPASS;
        private void Form10_Load(object sender, EventArgs e)
        {
            LoginPASS = Form1.LoginPassword;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(" "))
            {
                textBox1.Text = textBox1.Text.Replace(" ", "");
                textBox1.SelectionStart = textBox1.Text.Length;
            }
            if (textBox1.Text.Equals(LoginPASS))
            {
                label7.ForeColor = System.Drawing.Color.Green;
                label7.Text = "비밀번호가 일치합니다.";
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                label7.ForeColor = System.Drawing.Color.Red;
                label7.Text = "비밀번호가 일치하지 않습니다.";
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                button1.Enabled = false;
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
        private void button1_Click(object sender, EventArgs e)
        {
            String A = Form4.AllUserText;
            String[] SPA = A.Split('#');
            String aID = null;
            String aPass = null;
            String aEmail = null;
            String aAr = null;
            int B = 0;
            for (int i = 0; i < SPA.Length; i++)
            {
                String[] SPA1 = SPA[i].Split('%');
                aID = SPA1[0];
                aPass = SPA1[1];
                aEmail = SPA1[2];
                aAr = SPA1[3];
                if (aID.Equals(textBox2.Text))
                {
                    if (aPass.Equals(textBox3.Text))
                    {
                        B = 0;
                        break;
                    }
                    else
                    {
                        B = 1;
                    }
                }
                else
                {
                    B = 1;
                }
            }
            if (B == 0)
            {
                RunCommand("java -jar Client.Add.Ar.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + textBox2.Text + " " + textBox3.Text + " " + Form1.LoginID + " " + Form1.LoginPassword);
                this.Close();
            }
            else
            {
                MessageBox.Show("Accounts that do not depend on them can not be authorized.");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(" "))
            {
                textBox1.Text = textBox1.Text.Replace(" ", "");
                textBox1.SelectionStart = textBox1.Text.Length;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(" "))
            {
                textBox1.Text = textBox1.Text.Replace(" ", "");
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(" "))
            {
                textBox1.Text = textBox1.Text.Replace(" ", "");
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(" "))
            {
                textBox1.Text = textBox1.Text.Replace(" ", "");
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int C = 0; String INID = textBox5.Text;
            label12.Text = "아이디 확인중...";
            label12.ForeColor = System.Drawing.Color.Red;
            String A = Form4.AllUserText;
            String aID = null;
            String aPass = null;
            String aEmail = null;
            String aAr = null;
            String[] SPA = Form4.AllUserText.Split('#');
            for (int i = 0; i < SPA.Length; i++)
            {
                String[] SPA1 = SPA[i].Split('%');
                aID = SPA1[0];
                aPass = SPA1[1];
                aEmail = SPA1[2];
                aAr = SPA1[3];
                if (aID.Equals(INID))
                {
                    PASS = aPass;
                    C = 1;
                }
            }
            if(C == 1)
            {
                textBox5.Enabled = false;
                textBox4.Enabled = true;
                button2.Enabled = true;
                label12.Text = "아이디 확인됨";
                label12.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                MessageBox.Show("This ID does not exist.");
                textBox5.Enabled = true;
                textBox4.Enabled = false;
                button2.Enabled = false;
                label12.Text = "해당아이디는 존제하지 않습니다.";
                label12.ForeColor = System.Drawing.Color.Red;
            }
        }
        public static String PASS;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(PASS))
            {
                label10.Text = "권한제거중..";
                label10.ForeColor = System.Drawing.Color.Green;
                RunCommand("java -jar Client.Remove.Ar.dll "+Form1.ServerIPs+" "+Form1.ServerPorts+" "+textBox5.Text+" "+textBox4.Text+" "+Form1.LoginID+" "+Form1.LoginPassword);
                this.Close();
            }
            else
            {
                label10.Text = "비밀번호가 일치하지 않습니다.";
                label10.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
