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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 18;
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                if (!textBox2.Text.Equals(""))
                {
                    if (!textBox3.Text.Equals(""))
                    {
                        if (textBox1.Text.Contains("#") || textBox1.Text.Contains("%") || textBox2.Text.Contains("#") || textBox2.Text.Contains("%") || textBox3.Text.Contains("#") || textBox3.Text.Contains("%"))
                        {
                            MessageBox.Show("Contains characters(\"%\", \"#\") that should not be included in the text to be changed.");
                        }
                        else
                        {
                            int C = 0; String INID = textBox1.Text;
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
                                    C = 1;
                                }
                            }
                            if (C == 1)
                            {
                                C = 0;
                                MessageBox.Show("동일한 아이디가 이미 생성 되어있습니다.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                RunCommand("java -jar Client.Add.User.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + Form1.LoginID + " " + Form1.LoginPassword);
                                MessageBox.Show("Account change successful!");
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
