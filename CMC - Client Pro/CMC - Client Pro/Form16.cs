using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form16 : Form
    {
        public Form16()
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
        public string SHA256Hash(string data)
        {

            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(data));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }
        public static String CheckUpdate()
        {
            String Data = null;
            WebRequest request = null;
            WebResponse response = null;
            Stream resStream = null;
            StreamReader resReader = null;
            try
            {
                String uriString = "http://www.pckeeperupdate.kro.kr/";
                request = WebRequest.Create(uriString.Trim());
                response = request.GetResponse();
                resStream = response.GetResponseStream();
                resReader = new StreamReader(resStream);
                string resString = resReader.ReadToEnd();
                Data = resString;
            }
            catch (Exception) { }
            finally { if (resReader != null) resReader.Close(); if (response != null) response.Close(); }
            Data = Data.Replace("<html>", ""); Data = Data.Replace("<head>", ""); Data = Data.Replace("<title>PC-Keeper_Update</title>", ""); Data = Data.Replace("</body>", ""); Data = Data.Replace("</html>", ""); Data = Data.Replace("\r\n", "");
            return Data;
        }
        private static string GetMacAddress()
        {
            return NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                int c = 0;
                string B = textBox1.Text;
                B = SHA256Hash(B);
                String[] A = Program.NextData.Split('#');
                for (int i = 0; i < A.Length; i++)
                {
                    if (B.Equals(A[i]))
                    {
                        //PC-Keeper Key Server
                        String UpdateResult = CheckUpdate();
                        String[] AAA = UpdateResult.Split('#');
                        String[] KeySP = AAA[3].Split('%'); Guid g = Guid.NewGuid(); String MainServerKey = g.ToString();

                        RunCommand("java -jar Client.Main.Key.dll " + KeySP[0] + " " + KeySP[1] + " Check " + textBox1.Text + " " + GetMacAddress() + " " + MainServerKey);
                        Thread.Sleep(1000);
                        String ReadFileKeyRS = System.IO.File.ReadAllText("PC-KeeperKeyCheck.data");
                        String[] ReadFileKeySP = ReadFileKeyRS.Split('#');
                        if (ReadFileKeySP[1].Equals(MainServerKey))
                        {
                            if (ReadFileKeySP[0].Equals("true"))
                            {
                                RunCommand("java -jar Client.Main.Key.dll " + KeySP[0] + " " + KeySP[1] + " Add " + textBox1.Text + " " + GetMacAddress() + " " + MainServerKey);
                                c = 0;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("The key entered is already in use by another user.Please enter another key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                c = 2;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The authentication key received from the PC-Keeper activation key server does not match.");
                            c = 1;
                            return;
                        }

                    }
                    else
                    {
                        c = 1;
                    }
                }
                if(!(c == 2))
                {
                    if (c == 1)
                    {
                        MessageBox.Show("Invalid activation key. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        c = 0;
                    }
                    else
                    {
                        System.IO.File.WriteAllText("PC-Keeper_Key.pky", textBox1.Text);
                        MessageBox.Show("Genuine key matches. Please start again.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
              
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(" ", "");
            if (textBox1.Text.Equals(""))
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void Form16_Load(object sender, EventArgs e)
        {
        }
    }
}
