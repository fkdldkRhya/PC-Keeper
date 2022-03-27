using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form30 : Form
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public Form30() { InitializeComponent(); }
        private void button2_Click(object sender, EventArgs e) { this.Close(); }
        public static int timerProgressbar = 0;
        public void text_Box_Check() { if (textBox1.Text.Length > 0) { if (textBox2.Text.Length > 0) { Login_Next(); } else { MessageBox.Show("No Input Error! Please enter your password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } } else { MessageBox.Show("No Input Error! Please enter your ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        public void Login_Next() { timer1.Interval = 50; textBox1.Enabled = false; textBox2.Enabled = false; progressBar1.ForeColor = Color.FromArgb(255, 0, 0); timer1.Start(); timerProgressbar = 0; progressBar1.Visible = true; progressBar1.Value = 0; }
        private void button1_Click(object sender, EventArgs e) { text_Box_Check(); }
        private void Form30_Load(object sender, EventArgs e) { textBox2.PasswordChar = '*'; }
        public static String LoginPassword = "";
        public static String LoginID = "";
        public static String ServerIPs = "";
        public static String NextPTData = "";
        public static int ServerPorts = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timerProgressbar++;
            progressBar1.Step = 10;
            progressBar1.PerformStep();
            if (timerProgressbar == 10)
            {
                LoginPassword = textBox2.Text; LoginID = textBox1.Text;
                Thread A = new Thread(A_1); A.Start();
            }
            if (timerProgressbar == 20)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                timer1.Stop();
            }
        }
        public void A_1()
        {
            NextPTData = "";
            ServerIPs = Form1.ServerIPs;
            ServerPorts = Form1.ServerPorts;

            Guid g = Guid.NewGuid(); Guid g1 = Guid.NewGuid();
            String A = LoginNu(ServerIPs, ServerPorts, LoginPassword, LoginID, g.ToString());
            if (A.Equals("false"))
            {
                MessageBox.Show("Error! The server is not open or the username or password is invalid.", "ERROR-Nu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (A.Equals("KeyError"))
                {
                    MessageBox.Show("Error! The value of the transmitted key is invalid.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (A.Equals("NoSplitError"))
                    {
                        MessageBox.Show("Error! An error occurred during data transfer.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        RunCommand("java -jar Client.ShowData.dll " + ServerIPs + " " + ServerPorts + " " + textBox1.Text + " " + textBox2.Text);
                        Thread.Sleep(1000);
                        System.IO.FileInfo fi = new System.IO.FileInfo(Application.StartupPath + "\\0b21e2d2-9845-4d87-8124-586762a957de\\UserData.dll");
                        if (fi.Exists)
                        {
                            String RD = System.IO.File.ReadAllText(Application.StartupPath + "\\0b21e2d2-9845-4d87-8124-586762a957de\\UserData.dll");
                            if (RD.Equals("") || RD.Equals(null)) { }
                            else
                            {
                                fi.Delete(); fi.Delete();
                                String aID = null;
                                String aAr = null;
                                String[] SPA = RD.Split('#');
                                for (int i = 0; i < SPA.Length; i++)
                                {
                                    try
                                    {
                                        String[] SPA1 = SPA[i].Split('%');
                                        aID = SPA1[0];
                                        aAr = SPA1[3];
                                        NextPTData = NextPTData + "#" + aID + "%" + aAr;
                                    }
                                    catch (System.IndexOutOfRangeException)
                                    {
                                    }
                                }
                                NextPTData = NextPTData.Substring(1);
                                this.Invoke(new Action(delegate ()
                                {
                                    this.Close();
                                }));
                                Application.Run(new Form29());
                            }
                        }
                    }
                }
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
        public String LoginNu(String IP, int Port, String ID, String Password, String Key)
        {
            String TOF = null;
            RunCommand("java -jar Client.Login.Au.dll " + LoginID + " " + LoginPassword + " " + ServerIPs + " " + ServerPorts + " " + Key);
            Thread.Sleep(1000);
            System.IO.FileInfo fi = new System.IO.FileInfo("6ccffd72-8209-4b44-8404-35a9e6ffd90d\\LoginAu.data");
            if (!fi.Exists)
            {
                TOF = "NoFileError";
                return TOF;
            }
            else
            {
                String Data = System.IO.File.ReadAllText("6ccffd72-8209-4b44-8404-35a9e6ffd90d\\LoginAu.data");

                if (Data.Contains("#"))
                {
                    String[] A = Data.Split('#');
                    String outPutKey = A[1];
                    String outPutTOF = A[0];
                    if (outPutKey.Equals(Key))
                    {
                        if (outPutTOF.Equals("true"))
                        {
                            TOF = "true";
                        }
                        else
                        {
                            TOF = "false";
                        }
                    }
                    else
                    {
                        TOF = "KeyError";
                    }
                }
                else
                {
                    TOF = "NoSplitError";
                }
                return TOF;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(" ", "");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.Replace(" ", "");
        }
    }
}
