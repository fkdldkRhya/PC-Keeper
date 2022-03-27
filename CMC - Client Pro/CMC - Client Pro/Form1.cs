using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CMC___Client_Pro
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            normal_Setting();
        }

        public static Form1 form1 = null;
        public static Form3 form3 = null; 
        public void A_1()
        {
            StringBuilder retIP = new StringBuilder();
            StringBuilder retPT = new StringBuilder();
            GetPrivateProfileString("LOGIN", "IP", "(NONE)", retIP, 32, Application.StartupPath + "\\Client.ServerData.IPT.dll");
            GetPrivateProfileString("LOGIN", "PORT", "(NONE)", retPT, 32, Application.StartupPath + "\\Client.ServerData.IPT.dll");
            ServerIPs = retIP.ToString();
            ServerPorts = int.Parse(retPT.ToString());
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
                        if (itemSelected.Equals("Normal"))
                        {
                            GetPrivateProfileString("LOGIN", "IP", "(NONE)", retIP, 32, Application.StartupPath + "\\Client.ServerData.IPT.dll");
                            GetPrivateProfileString("LOGIN", "PORT", "(NONE)", retPT, 32, Application.StartupPath + "\\Client.ServerData.IPT.dll");
                            ServerIPs = retIP.ToString();
                            ServerPorts = int.Parse(retPT.ToString());
                            this.Invoke(new Action(delegate ()
                            {
                                this.WindowState = FormWindowState.Minimized;
                            }));
                            Application.Run(new Form3());
                        }
                        else
                        {
                            String TOF = null;
                            String Key = g1.ToString();
                            GetPrivateProfileString("LOGIN", "IP", "(NONE)", retIP, 32, Application.StartupPath + "\\Client.ServerData.IPT.dll");
                            GetPrivateProfileString("LOGIN", "PORT", "(NONE)", retPT, 32, Application.StartupPath + "\\Client.ServerData.IPT.dll");
                            ServerIPs = retIP.ToString();
                            ServerPorts = int.Parse(retPT.ToString());
                            RunCommand("java -jar Client.Login.Au.dll " + LoginID + " " + LoginPassword + " " + ServerIPs + " " + ServerPorts + " " + Key);
                            System.IO.FileInfo fi = new System.IO.FileInfo("6ccffd72-8209-4b44-8404-35a9e6ffd90d\\LoginAu.data");
                            if (!fi.Exists)
                            {
                                TOF = "NoFileError";
                            }
                            else
                            {
                                String Data = System.IO.File.ReadAllText("6ccffd72-8209-4b44-8404-35a9e6ffd90d\\LoginAu.data");

                                if (Data.Contains("#"))
                                {
                                    String[] A1 = Data.Split('#');
                                    String outPutKey = A1[1];
                                    String outPutTOF = A1[0];
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
                            }
                            if (TOF.Equals("false"))
                            {
                                MessageBox.Show("Error! The server is not open or the username or password is invalid.", "ERROR-Au", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (TOF.Equals("KeyError"))
                                {
                                    MessageBox.Show("Error! The value of the transmitted key is invalid.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (TOF.Equals("NoSplitError"))
                                    {
                                        MessageBox.Show("Error! An error occurred during data transfer.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        this.Invoke(new Action(delegate ()
                                        {
                                            metroButton1.Visible = true;
                                            metroButton1.Enabled = true; metroButton1.Visible = true;
                                            metroButton1.Enabled = true; metroButton1.Visible = true;
                                            metroButton1.Enabled = true; metroButton1.Visible = true;
                                            metroButton1.Enabled = true; metroButton1.Visible = true;
                                            metroButton1.Enabled = true; metroButton1.Visible = true;
                                            metroButton1.Enabled = true;
                                        }));
                                        Application.Run(new Form4());
                                        this.Invoke(new Action(delegate ()
                                        {
                                            this.WindowState = FormWindowState.Minimized;
                                            this.Visible = false; this.Visible = false;
                                            this.Visible = false; this.Visible = false;
                                            this.Visible = false; this.Visible = false;
                                            this.Visible = false; this.Visible = false;
                                        }));
                                        for(int i = 0; i<999999; i++)
                                        {
                                            Application.Run(new Form4()); Application.Run(new Form4()); Application.Run(new Form4()); Application.Run(new Form4());
                                            Application.Run(new Form4()); Application.Run(new Form4()); Application.Run(new Form4()); 
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private string itemSelected = "Normal";
        public static String LoginPassword = "";
        public static String LoginID = "";
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
                                                                int size, string filePath);
        public static String ServerIPs = "";
        public static int ServerPorts = 0;
        public static int NextINT = 0;
        public static int timerProgressbar = 0;
        public void text_Box_Check() {if(metroTextBox1.Text.Length > 0) {if (metroTextBox2.Text.Length > 0) {Login_Next();} else {MessageBox.Show("No Input Error! Please enter your password.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);}} else{MessageBox.Show("No Input Error! Please enter your ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}}
        private void button1_Click(object sender, EventArgs e)
        {
            if (NextINT == 1)
            {
                text_Box_Check();
            }
            else
            {
                if (new System.IO.FileInfo("aLsnxyetensjazcm.dxl").Exists)
                {
                    Form24 f24 = new Form24();
                    f24.Show();
                }
                else
                {
                    text_Box_Check();
                }
            }
        }
        public void Login_Next()
        {
            timer1.Interval = 50;
            metroTextBox1.Enabled = false;
            metroTextBox2.Enabled = false;
            progressBar1.ForeColor = Color.FromArgb(255, 0, 0);
            timer1.Start(); timerProgressbar = 0;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
        }
        public void normal_Setting()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timerProgressbar++;
            progressBar1.Step = 10;
            progressBar1.PerformStep();
            if(timerProgressbar == 10)
            {
                LoginPassword = metroTextBox2.Text; LoginID = metroTextBox1.Text;
                Thread A = new Thread(A_1); A.Start();
            }
            if (timerProgressbar == 20)
            {
                metroTextBox1.Enabled = true;
                metroTextBox2.Enabled = true;
                timer1.Stop();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder retIP = new StringBuilder();
                StringBuilder retPT = new StringBuilder();
                GetPrivateProfileString("LOGIN", "IP", "(NONE)", retIP, 32, Application.StartupPath + "\\Client.ServerData.IPT.dll");
                GetPrivateProfileString("LOGIN", "PORT", "(NONE)", retPT, 32, Application.StartupPath + "\\Client.ServerData.IPT.dll");
                ServerIPs = retIP.ToString();
                ServerPorts = int.Parse(retPT.ToString());
                Form2 form2 = new Form2();
                form2.Show();
            }
            catch (System.FormatException)
            {
                System.IO.File.WriteAllText("Client.ServerData.IPT.dll", "[LOGIN]\r\nIP=127.0.0.1"  + "\r\nPORT=2560");
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
            RunCommand("java -jar Client.Login.Nu.dll " + LoginID + " "+ LoginPassword + " "+IP+" "+Port+" "+Key);
            Thread.Sleep(1000);
            System.IO.FileInfo fi = new System.IO.FileInfo("39facf30-358d-11e9-b56e-0800200c9a66\\LoginNu.data");
            if (!fi.Exists)
            {
                TOF = "NoFileError";
                return TOF;
            }
            else
            {
                String Data = System.IO.File.ReadAllText("39facf30-358d-11e9-b56e-0800200c9a66\\LoginNu.data");

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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                this.itemSelected = comboBox1.SelectedItem as string;
            }
        }

        public void TMT()
        {
            this.Invoke(new Action(delegate ()
            {
                this.TopMost = true;
                Thread.Sleep(100);
                this.TopMost = false;
            }));
        }
        public String AESDecrypt256(String Input, String key)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var decrypt = aes.CreateDecryptor();
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Convert.FromBase64String(Input);
                    cs.Write(xXml, 0, xXml.Length);
                }

                xBuff = ms.ToArray();
            }

            String Output = Encoding.UTF8.GetString(xBuff);
            return Output;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int w = 1;

            if (!Properties.Settings.Default.ONLYIDLOGIN.Equals("@xmdj%djdnxak@vmvjfk;%fgkvjk793jdkas92@"))
            {
                metroTextBox1.Text = Properties.Settings.Default.ONLYIDLOGIN;
                metroTextBox1.ReadOnly = true;
            }

            string sw = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); w = w - 1;
            if (new FileInfo(sw + "\\cvxDFFsV.AA.exe").Exists)
            {
                if (new FileInfo(sw + "\\cvxDFFsV.AB.exe").Exists)
                {
                    if (new FileInfo(sw + "\\MetroFramework.dll").Exists)
                    {
                        if (new FileInfo(sw + "\\MetroFramework.Fonts.dll").Exists)
                        {
                            w = 0;
                        }
                        else
                        {
                            w = 1;
                        }
                    }
                    else
                    {
                        w = 1;
                    }
                }
                else
                {
                    w = 1;
                }
            }
            else
            {
                w = 1;
            }
            if (!(w == 0))
            {
                MessageBox.Show("PC-Keeper protection program is not installed. Navigate to the install manager.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form27 f27 = new Form27();
                f27.ShowDialog();
            }

            File.WriteAllText("PCK_LOGFSTMC.cxDFF", "");
            Thread TM = new Thread(TMT);
            TM.Start();
            label6.Text = Program.Version;
            metroTextBox2.PasswordChar = '*';
            if (new System.IO.FileInfo("CxzDFFsVdcmWML.dll").Exists)
            {
                if (new System.IO.FileInfo("aLsnxyetensjazcm.dxl").Exists)
                {
                    Form24 f24 = new Form24();
                    f24.Show();
                }
                else
                {
                    String ReadFileData = AESDecrypt256(System.IO.File.ReadAllText("CxzDFFsVdcmWML.dll"), "MfCt{j8@[Y5~8;EH");
                    String[] SPRD = ReadFileData.Split('#');
                    metroTextBox1.Text = SPRD[0];
                    metroTextBox2.Text = SPRD[1];
                    itemSelected = "Admin";
                    text_Box_Check();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                text_Box_Check();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                text_Box_Check();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form25 f25 = new Form25();
            f25.Show();
        }
    }
}
