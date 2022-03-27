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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
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
        public void A_1()
        {
            RunCommand("java -jar Client.User.DataC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " " + Form4.nextPW + " " + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text);
            this.Invoke(new Action(delegate ()
            {
                this.Close();
            }));
        }
        public static String DID = null;
        public static String DPA = null;
        public void A_2()
        {
            RunCommand("java -jar Client.Remove.User.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + DID + " " + DPA + " " + Form1.LoginID + " " + Form1.LoginPassword);
            this.Invoke(new Action(delegate ()
            {
                this.Close();
            }));
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DID = Form4.nextID;
            if (textBox1.Text.Contains("#") || textBox1.Text.Contains("%") || textBox2.Text.Contains("#") || textBox2.Text.Contains("%") || textBox3.Text.Contains("#") || textBox3.Text.Contains("%"))
            {
                MessageBox.Show("Contains characters(\"%\", \"#\") that should not be included in the text to be changed.");
            }
            else
            {
                if (!textBox1.Text.Equals("")&& !textBox2.Text.Equals("")&& !textBox3.Text.Equals(""))
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
                        if (!DID.Equals(INID))
                        {
                            if (aID.Equals(INID))
                            {
                                C = 1;
                            }
                        }
                    }
                    if (C == 1)
                    {
                        C = 0;
                        MessageBox.Show("동일한 아이디가 이미 생성 되어있습니다.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Your account information has changed.");
                        Thread th = new Thread(A_1);
                        th.Start();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to delete this account?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                DID = Form4.nextID;
                DPA = Form4.nextPW;
                String FormLoginId = Form1.LoginID;
                    Thread th = new Thread(A_2);
                    th.Start();
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form4.nextID;
            textBox2.Text = Form4.nextPW;
            textBox3.Text = Form4.nextEM;
            textBox1.MaxLength = 18;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(" "))
            {
                textBox1.Text = textBox1.Text.Replace(" ", "");
                textBox1.SelectionStart = textBox1.Text.Length;
            }
            if (textBox1.Text.Equals(Form4.nextID) && textBox2.Text.Equals(Form4.nextPW) && textBox3.Text.Equals(Form4.nextEM))
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Contains(" "))
            {
                textBox2.Text = textBox2.Text.Replace(" ", "");
                textBox2.SelectionStart = textBox2.Text.Length;
            }
            if (textBox1.Text.Equals(Form4.nextID) && textBox2.Text.Equals(Form4.nextPW) && textBox3.Text.Equals(Form4.nextEM))
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Contains(" "))
            {
                textBox3.Text = textBox3.Text.Replace(" ", "");
                textBox3.SelectionStart = textBox3.Text.Length;
            }
            if (textBox1.Text.Equals(Form4.nextID) && textBox2.Text.Equals(Form4.nextPW) && textBox3.Text.Equals(Form4.nextEM))
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

