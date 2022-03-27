using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form13 : Form
    {
        public Form13()
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

        public static String SendMessage = "";
        private void Form13_Load(object sender, EventArgs e)
        {
            checkedListBox1.SelectionMode = SelectionMode.One;
            String AllUser = Form4.AllUserText;
            checkedListBox1.SelectionMode = SelectionMode.One;
            String aID = null;
            String aPass = null;
            String aEmail = null;
            String aAr = null;
            String[] SPA = AllUser.Split('#');
            for (int i = 0; i < SPA.Length; i++)
            {
                String[] SPA1 = SPA[i].Split('%');
                aID = SPA1[0];
                aPass = SPA1[1];
                aEmail = SPA1[2];
                aAr = SPA1[3];

                checkedListBox1.Items.Add("ID: "+aID);

            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox1.Text.Replace("/e", "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "/e";
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                checkedListBox1.SelectionMode = SelectionMode.One;
            }
        }
        public static String V = "";
        public static String K = ""; 
        public void A_1()
        {
            checkedListBox1.SelectionMode = SelectionMode.One;
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + V + " java#SendMessageC#"+K+" " + Form1.LoginID + " " + Form1.LoginPassword);
            Thread.Sleep(2000);
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + V + " start#Send-notification-system.exe" + " " + Form1.LoginID + " " + Form1.LoginPassword);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = checkedListBox1.Items.Count;
            String Val = "";
            for(int A = 0; A < index; A++)
            {
                if (checkedListBox1.GetItemChecked(A))
                {
                    Val = checkedListBox1.Items[A].ToString();
                    K = textBox1.Text.Replace(" ", "@");
                    V = Val.Replace("ID: ",""); 
                    Thread th = new Thread(A_1);
                    th.Start();
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.SelectionMode = SelectionMode.One;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox1.SelectionMode = SelectionMode.One;
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
    }
}
