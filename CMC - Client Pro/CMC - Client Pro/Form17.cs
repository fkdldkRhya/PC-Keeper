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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        public static int ToFormMove = 0;
        public static int MoveValForm_X = 0;
        public static int MoveValForm_Y = 0;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ToFormMove = 0;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ToFormMove = 1;
            MoveValForm_X = e.X;
            MoveValForm_Y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ToFormMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MoveValForm_X, MousePosition.Y - MoveValForm_Y);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            textBox1.Text = System.IO.File.ReadAllText("PC-Keeper_Key.pky");
        }

        private void label1_Move(object sender, EventArgs e)
        {

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ToFormMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MoveValForm_X, MousePosition.Y - MoveValForm_Y);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ToFormMove = 1;
            MoveValForm_X = e.X;
            MoveValForm_Y = e.Y;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            ToFormMove = 0;
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
            DialogResult result = MessageBox.Show("Are you sure you want to change the license?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                String[] KeySP = Program.publicServerINFO[3].Split('%'); Guid g = Guid.NewGuid(); String MainServerKey = g.ToString();
                RunCommand("java -jar Client.Main.Key.dll " + KeySP[0] + " " + KeySP[1] + " Del " + System.IO.File.ReadAllText("PC-Keeper_Key.pky") + " " + MainServerKey);
                System.IO.FileInfo fi = new System.IO.FileInfo("PC-Keeper_Key.pky");
                fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete();
                Application.Exit();
            }
        }
    }
}
