using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form4 : Form
    {
        public static TreeNode svrNode = new TreeNode("ClientList", 0, 0);
        public Form4()
        {
            InitializeComponent();
        }
        public static String AllUserText = "";
        public void TreeViewSetting()
        {
            ImageList il = new ImageList();
            il.Images.Add(Bitmap.FromFile("7c35a8b8-8091-472e-96ee-179cea8dc4ff\\ServerIcon.png")); treeView1.ImageList = il;
            RunCommand("java -jar Client.ShowData.dll "+ Form1.ServerIPs+" "+ Form1.ServerPorts + " "+ Form1.LoginID+" "+ Form1.LoginPassword);
            Thread.Sleep(1000);
            System.IO.FileInfo fi = new System.IO.FileInfo(Application.StartupPath + "\\0b21e2d2-9845-4d87-8124-586762a957de\\UserData.dll");
            if (fi.Exists)
            {
                String A = System.IO.File.ReadAllText(Application.StartupPath + "\\0b21e2d2-9845-4d87-8124-586762a957de\\UserData.dll");
                System.IO.File.WriteAllText(Application.StartupPath + "\\0b21e2d2-9845-4d87-8124-586762a957de\\UserData.dll", "LOCK-CMS Client 0x003");
                if (A.Equals("") || A.Equals(null)) { }
                else
                {
                    fi.Delete(); fi.Delete();
                    String aID = null;
                    String aPass = null;
                    String aEmail = null;
                    String aAr = null;
                    String[] SPA = A.Split('#');
                    for (int i = 0; i < SPA.Length; i++)
                    {
                        try
                        {
                            String[] SPA1 = SPA[i].Split('%');
                            aID = SPA1[0];
                            aPass = SPA1[1];
                            aEmail = SPA1[2];
                            aAr = SPA1[3];
                            if (aID.Equals(Form1.LoginID))
                            {
                                this.Invoke(new Action(delegate ()
                                {
                                    textBox3.Text = aEmail;
                                }));
                            }
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                        }
                        svrNode.Nodes.Add(aID, "ID: " + aID, 0, 0);
                        AllUserText = A;
                    }
                }
            }
            else
            {
                MessageBox.Show("An error occurred, the error is that the server is closed or the account does not have permission.");
                this.Close();
            }
            treeView1.Nodes.Add(svrNode); treeView1.ExpandAll();

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
        public void RunCommand2(String command)
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
        public void RunCommand3(String command)
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
        public void RunCommand4(String command)
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
        public void RunCommand5(String command)
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
        public void RunCommand6(String command)
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
            for (int A1 = 0; A1 < 999; A1++)
            {
                Thread.Sleep(1500);
                RunCommand("java -jar Client.ShowData.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form1.LoginID + " " + Form1.LoginPassword);
                Thread.Sleep(1000);
                this.Invoke(new Action(delegate ()
                {
                    treeView1.Nodes.Clear();
                }));
                System.IO.FileInfo fi = new System.IO.FileInfo(Application.StartupPath + "\\0b21e2d2-9845-4d87-8124-586762a957de\\UserData.dll");
                if (fi.Exists)
                {
                    String A = System.IO.File.ReadAllText(Application.StartupPath + "\\0b21e2d2-9845-4d87-8124-586762a957de\\UserData.dll");
                    System.IO.File.WriteAllText(Application.StartupPath + "\\0b21e2d2-9845-4d87-8124-586762a957de\\UserData.dll", "LOCK-CMS Client 0x003");
                    if (A.Equals("") || A.Equals(null)) { }
                    else
                    {
                        fi.Delete(); fi.Delete();
                        String aID = null;
                        String aPass = null;
                        String aEmail = null;
                        String aAr = null;
                        String[] SPA = A.Split('#');
                        svrNode = null; svrNode = new TreeNode("ClientList", 0, 0);
                        for (int i = 0; i < SPA.Length; i++)
                        {
                            try
                            {
                                try
                                {
                                    String[] SPA1 = SPA[i].Split('%');
                                    aID = SPA1[0];
                                    aPass = SPA1[1];
                                    aEmail = SPA1[2];
                                    aAr = SPA1[3];
                                }
                                catch (System.IndexOutOfRangeException)
                                {
                                    A1 = 0;
                                }
                            }
                            catch (IOException)
                            {
                                A1 = 0;
                                MessageBox.Show("An error occurred, the error is that the server is closed or the account does not have permission.");
                                this.Invoke(new Action(delegate ()
                                {
                                    this.Close();
                                }));
                            }

                            if (aID.Equals(label7.Text))
                            {
                                if (aAr.Equals("1"))
                                {
                                    this.Invoke(new Action(delegate ()
                                    {
                                        label7.Text = aID;
                                        label10.Text = "권한이 있음";
                                        label8.Text = "권한이 있는 계정의 비밀번호는 표시할수없습니다";
                                        label9.Text = aEmail;
                                        button1.Enabled = false;
                                        button2.Enabled = true;
                                        String K = Form1.LoginID;
                                        if (aID.Equals(K))
                                        {
                                            button2.Enabled = false;
                                        }
                                    }));
                                }
                                else
                                {
                                    this.Invoke(new Action(delegate ()
                                    {
                                        label7.Text = aID;
                                        label10.Text = "권한이 없음";
                                        label8.Text = aPass;
                                        label9.Text = aEmail;
                                        button1.Enabled = true;
                                        button2.Enabled = true;
                                    }));
                                }
                            }

                            this.Invoke(new Action(delegate ()
                            {
                                svrNode.Nodes.Add(aID, "ID: " + aID, 0, 0);
                            }));

                            AllUserText = A;
                        }
                        this.Invoke(new Action(delegate ()
                        {
                            treeView1.Nodes.Add(svrNode); treeView1.ExpandAll();
                        }));
                    }
                }
                else
                {
                    MessageBox.Show("An error occurred, the error is that the server is closed or the account does not have permission.");
                    this.Invoke(new Action(delegate ()
                    {
                        this.Close();
                    }));
                }
                A1 = 0;
            }
        }

        
        public void A_10()
        {
            int C = 0;int CC = 0;
            for (int i = 0; i < 999999; i++)
            {
                i = 0;
                if (CC == 15)
                {
                    CC = 0;
                    if (!CALS.Equals("no0xvrj3mfmdjrmrifmfdlkjsrbtnkiuherwbnlkjsgdfs9231784y0897hds0afiubg-0897gq30487yuigvbsdpaikucvjh"))
                    {
                        if (CALS.Contains("#"))
                        {
                            String[] sp = CALS.Split('#');
                            for(int x = 0; x<sp.Length; x++)
                            { 
                                RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + sp[x] + " " + "start#ClientRestart.exe" + " " + Form1.LoginID + " " + Form1.LoginPassword);
                            }
                        }
                        else
                        {
                            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + CALS + " " + "start#ClientRestart.exe" + " " + Form1.LoginID + " " + Form1.LoginPassword);
                        }
                    }
                }
                Thread.Sleep(100);
                C++; i = 0;
                if (C == 100)
                {
                    C = 0; CC++;
                }
            }
        }
        
        public void FormLoadTask()
        {
            Thread th2 = new Thread(A_5); th2.Start();
            Thread th3 = new Thread(A_6); th3.Start();
            textBox1.MaxLength = 18;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox1.Text = Form1.LoginID;
            for (int i = 0; i < Form1.LoginPassword.Length; i++)
            {
                textBox2.Text = textBox2.Text + "*";
            }
            TreeViewSetting();
            Thread th = new Thread(A_1); th.Start();
            //Thread th4 = new Thread(A_10); th4.Start();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            FormLoadTask();
            Form1 f1 = new Form1();
            f1.WindowState = FormWindowState.Minimized;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.IO.File.WriteAllText(Application.StartupPath + "\\0b21e2d2-9845-4d87-8124-586762a957de\\UserData.dll", "LOCK-CMS Client 0x003");
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public static int ArCheckINT = 0;
        public static int C = 0;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeKey = e.Node.Name;
            if (C == 0)
            {
                nodeKey = "[지정되지않음]";
                C = 1;
            }
            label7.Text = nodeKey;
            String[] A = AllUserText.Split('#');
            for(int B = 0; B<A.Length; B++)
            {
                String[] C = A[B].Split('%');
                if (C[0].Equals(nodeKey))
                {
                    nextPW = C[1];
                    if (C[3].Equals("1"))
                    {
                        String FormsLoginID = Form1.LoginID;
                        label10.Text = "권한이 있음";
                        label8.Text = "권한이 있는 계정의 비밀번호는 표시할수없습니다";
                        label9.Text = C[2];
                        button1.Enabled = false;
                        button2.Enabled = true;
                        if (FormsLoginID.Equals(nodeKey))
                        {
                            button2.Enabled = false;
                        }
                    }
                    else
                    {
                        label10.Text = "권한이 없음";
                        label8.Text = C[1];
                        label9.Text = C[2];
                        button1.Enabled = true;
                        button2.Enabled = true;
                    }
                }
            }
            String FormLoginID = Form1.LoginID;
            if (FormLoginID.Equals(nodeKey))
            {
                button1.Enabled = false;
            }
        }
        public void A_2()
        {
            String DID = label7.Text;
            String DPA = label8.Text;
            this.Invoke(new Action(delegate ()
            {
                label7.Text = "[지정되지않음]";
                label10.Text = "[지정되지않음]";
                label8.Text = "[지정되지않음]";
                label9.Text = "[지정되지않음]";
            }));
            RunCommand2("java -jar Client.Remove.User.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + DID + " " + DPA + " " + Form1.LoginID + " " + Form1.LoginPassword);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(A_2);
            th.Start();
        }
        public static String nextID = "";
        public static String nextPW = "";
        public static String nextEM = "";
        private void button2_Click(object sender, EventArgs e)
        {
            if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
            {
                MessageBox.Show("Error! Account not selected.Please select an account.");
            }
            else
            {
                nextID = label7.Text;
                nextEM = label9.Text;
                String A = "권한이 있음";
                String B = label10.Text;
                if (A.Equals(B))
                {
                    Form7 f7 = new Form7();
                    f7.ShowDialog();
                }
                else
                {
                    Form6 f6 = new Form6();
                    f6.ShowDialog();
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void A_3()
        {
            RunCommand3("java -jar Client.User.DataC.dll "+Form1.ServerIPs+" "+ Form1.ServerPorts+" "+Form1.LoginID+" "+Form1.LoginPassword +" "+textBox1.Text + " " + textBox2.Text + " "+textBox3.Text);
            this.Invoke(new Action(delegate ()
            {
                Application.Restart();
            }));
        }
            
        public static int TaskSaveA = 0;
        private void button10_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("#") || textBox1.Text.Contains("%")|| textBox2.Text.Contains("#") || textBox2.Text.Contains("%")|| textBox3.Text.Contains("#") || textBox3.Text.Contains("%"))
            {
                if (TaskSaveA == 1)
                {
                    if (textBox1.Text.Contains("#") || textBox1.Text.Contains("%") || textBox2.Text.Contains("#") || textBox2.Text.Contains("%") || textBox3.Text.Contains("#") || textBox3.Text.Contains("%"))
                    {
                        MessageBox.Show("Contains characters(\"%\", \"#\") that should not be included in the text to be changed.");
                    }
                    else
                    {
                        if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals(""))
                        {
                            String FormLoginId = Form1.LoginID;
                            int C = 0; String INID = textBox1.Text;
                            String aID = null;
                            String aPass = null;
                            String aEmail = null;
                            String aAr = null;
                            String[] SPA = AllUserText.Split('#');
                            for (int i = 0; i < SPA.Length; i++)
                            {
                                String[] SPA1 = SPA[i].Split('%');
                                aID = SPA1[0];
                                aPass = SPA1[1];
                                aEmail = SPA1[2];
                                aAr = SPA1[3];
                                if (!FormLoginId.Equals(INID))
                                {
                                    if (aID.Equals(INID))
                                    {
                                        C = 1;
                                    }
                                }
                                else
                                {
                                    C = 0;
                                }
                                if (Form1.LoginID.Equals(INID))
                                {
                                    if (Form1.LoginPassword.Equals(textBox2.Text))
                                    {
                                        if (aEmail.Equals(textBox3.Text))
                                        {
                                            C = 2;
                                            break;
                                        }
                                    }
                                }
                            }

                            if (!(C == 2))
                            {

                                if (C == 1)
                                {
                                    C = 0;
                                    MessageBox.Show("동일한 아이디가 이미 생성 되어있습니다.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    TaskSaveA = 0;
                                    MessageBox.Show("계정 정보를 변경하면 다시시작 해야합니다.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Thread th = new Thread(A_3);
                                    th.Start();
                                }
                            }
                            else
                            {
                                if (C == 2)
                                {
                                    MessageBox.Show("계정정보가 변경 되지 않았습니다.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    C = 0;
                                }
                            }
                        }
                    }
                }
                else
                {
                    String V = Form8.A;
                    if (V.Equals("YES"))
                    {
                        textBox2.Text = Form1.LoginPassword;
                        button10.Text = "저장";
                        textBox1.ReadOnly = false;
                        textBox2.ReadOnly = false;
                        textBox3.ReadOnly = false;
                        TaskSaveA = 1;
                    }
                    else
                    {
                        Form8 f8 = new Form8();
                        f8.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Contains characters(\"%\", \"#\") that should not be included in the text to be changed.");
            }
        }

        public void A_12()
        {
            RunCommand3("java -jar Client.Server.TaskM.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form1.LoginID + " " + Form1.LoginPassword);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Button_M == 1)
            {
                DialogResult result = MessageBox.Show("Are you really shutting down the server?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    System.Threading.Thread th = new System.Threading.Thread(A_12);
                    th.Start();
                }
            }
            else
            {
                Form9 f9 = new Form9();
                f9.ShowDialog();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Button_M == 1)
            {
                Form19 f19 = new Form19();
                f19.ShowDialog();
            }
            else
            {
                Form10 f10 = new Form10();
                f10.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Button_M == 1)
            {
                nextID = label7.Text;
                if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
                {
                    MessageBox.Show("Error! Account not selected.Please select an account.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to reconnect the PC?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        System.Threading.Thread th = new System.Threading.Thread(A_13);
                        th.Start();
                    }
                }
            }
            else
            {
                nextID = label7.Text;
                if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
                {
                    MessageBox.Show("Error! Account not selected.Please select an account.");
                }
                else
                {
                    Form11 f11 = new Form11();
                    f11.ShowDialog();
                }
            }
        }

        public void A_13()
        {
            RunCommand("java -jar Client.Get.ACIP.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + label7.Text + " " + label8.Text);
            Thread.Sleep(1000);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(System.IO.File.ReadAllText("RemoteClientData.dll")), 9424);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipep);
            Console.WriteLine("Socket connect");
            Byte[] _data = new Byte[1024];
            client.Receive(_data);
            String _buf = Encoding.Default.GetString(_data);
            MessageBox.Show("ID: " + nextID +" , " + _buf);
            _buf = "소켓 접속 확인 됐습니다.";
            _data = Encoding.Default.GetBytes(_buf);
            client.Send(_data);
            client.Close();
        }

        public void A_4()
        {
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + label7.Text + " start#RemoteServer.exe " + Form1.LoginID +" "+Form1.LoginPassword);
            RunCommand("java -jar Client.Get.ACIP.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + label7.Text + " " + label8.Text);
            Thread.Sleep(1000);
            RunCommand4("\"CMC-ClientViewer.exe\"");
        }
        public static int rtCR = 0;
        public void rt_Copyrigth()
        {
            if(rtCR == 0)
            {
                MessageBox.Show("That remote control was created using a library of people called \"Jakelanser\".Blog address: http://blog.naver.com/PostView.nhn?bllogId=jjjy3742&logNo=220952097632","Copyright",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            rtCR = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Button_M == 1)
            {
                Form20 f20 = new Form20();
                f20.ShowDialog();
            }
            else
            {
                if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
                {
                    MessageBox.Show("Error! Account not selected.Please select an account.");
                }
                else
                {
                    rt_Copyrigth();
                    Thread th = new Thread(A_4);
                    th.Start();
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        public static String CALS = "";
        public static int CheckOne = 0;
        public static int CheckOne1 = 0;
        public void A_5()
        {
            for (int i = 0; i < 999; i++)
            {
                Thread.Sleep(2000);
                CheckOne1++;
                this.Invoke(new Action(delegate ()
                {
                    listView1.BeginUpdate();
                    listView1.View = View.Details;
                    ImageList il = new ImageList();
                    il.Images.Add(Bitmap.FromFile("7c35a8b8-8091-472e-96ee-179cea8dc4ff\\computer.png"));
                    listView1.LargeImageList = il;
                    listView1.SmallImageList = il;
                }));

                i = 0;
                String A = System.IO.File.ReadAllText(Application.StartupPath + "\\getCAL.DATA.dll");
                A = A.Replace("%TEST", "");
                if (A.Equals("null"))
                {
                    CALS = "no0xvrj3mfmdjrmrifmfdlkjsrbtnkiuherwbnlkjsgdfs9231784y0897hds0afiubg-0897gq30487yuigvbsdpaikucvjh";
                    A = "접속된 계정 없음";
                    ListViewItem lvi = new ListViewItem(A);
                    if(!A.Equals("접속된 계정 없음"))
                    {
                        lvi.SubItems.Add("접속됨");
                    }
                    else
                    {
                        lvi.SubItems.Add("접속 없음");
                    }
                    lvi.ImageIndex = 0;
                    this.Invoke(new Action(delegate ()
                    {
                        listView1.Columns.Clear();
                        listView1.Items.Clear();
                        listView1.Items.Add(lvi);
                    }));
                }
                else
                {
                    int ABC = 0;
                    if (A.Contains("#"))
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            listView1.Columns.Clear();
                            listView1.Items.Clear();
                        }));
                        A = A.Substring(1);
                        String[] B = A.Split('#');
                        for (int i1 = 0; i1 < B.Length; i1++)
                        {
                            CALS = CALS + "#" + B[i1];
                            if (ABC == 0)
                            {
                                CALS = B[i1];
                            }
                            ListViewItem lvi = new ListViewItem(B[i1]);
                            lvi.SubItems.Add("접속됨");
                            lvi.ImageIndex = 0;
                            ABC = 1;
                            this.Invoke(new Action(delegate ()
                            {
                                listView1.Items.Add(lvi);
                            }));
                        }
                    }
                    else
                    {
                        CALS = A;
                        ListViewItem lvi = new ListViewItem(A);
                        lvi.SubItems.Add("접속됨");
                        lvi.ImageIndex = 0;
                        this.Invoke(new Action(delegate ()
                        {
                            listView1.Columns.Clear();
                            listView1.Items.Clear();
                            listView1.Items.Add(lvi);
                        }));
                    }
                }
                this.Invoke(new Action(delegate ()
                {
                    listView1.Columns.Add("ID", 200, HorizontalAlignment.Left);
                    listView1.Columns.Add("접속여부", 200, HorizontalAlignment.Left);
                    listView1.EndUpdate();
                }));
                CheckOne = 1;
            }
        }
        public void A_6()
        {
            for(int A = 0; A< 100; A++)
            {
                A = 0; Thread.Sleep(500);
                RunCommand5("java -jar Client.Get.CAL.dll " + Form1.ServerIPs + " " + Form1.ServerPorts);
            }
        }
            private void button11_Click(object sender, EventArgs e)
            {

            }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
                ListViewItem lvItem = items[0];
                string nodeKey = lvItem.SubItems[0].Text;
                if (!nodeKey.Equals("접속된 계정 없음"))
                {
                    String[] A = AllUserText.Split('#');
                    for (int B = 0; B < A.Length; B++)
                    {
                        String[] C = A[B].Split('%');
                        if (C[0].Equals(nodeKey))
                        {
                            nextPW = C[1];
                            if (C[3].Equals("1"))
                            {
                                this.Invoke(new Action(delegate ()
                                {
                                    label7.Text = nodeKey;
                                    String FormsLoginID = Form1.LoginID;
                                label10.Text = "권한이 있음";
                                label8.Text = "권한이 있는 계정의 비밀번호는 표시할수없습니다";
                                label9.Text = C[2];
                                button1.Enabled = false;
                                button2.Enabled = true;
                                if (FormsLoginID.Equals(nodeKey))
                                {
                                    button2.Enabled = false;
                                }
                                }));
                            }
                            else
                            {
                                this.Invoke(new Action(delegate ()
                                {
                                    label7.Text = nodeKey;
                                    label10.Text = "권한이 없음";
                                label8.Text = C[1];
                                label9.Text = C[2];
                                button1.Enabled = true;
                                button2.Enabled = true;
                                }));
                            }
                        }
                    }
                    String FormLoginID = Form1.LoginID;
                    if (FormLoginID.Equals(nodeKey))
                    {
                        button1.Enabled = false;
                    }
                }   
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            nextID = label7.Text;
            if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
            {
                MessageBox.Show("Error! Account not selected.Please select an account.");
            }
            else
            {
                nextID = label7.Text;
                nextPW = label8.Text;
                Form12 f12 = new Form12();
                f12.ShowDialog();
            }
        }
        [STAThread]
        private void button8_Click(object sender, EventArgs e)
        {
            nextID = label7.Text;
            if (CALS.Equals(""))
            {
                MessageBox.Show("Error! No transferable account detected.");
            }
            else
            {
                nextID = label7.Text;
                nextPW = label8.Text;

            }
        }

        public void A_8()
        {
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + label7.Text + " ShutdownEXE.exe " + Form1.LoginID + " " + Form1.LoginPassword);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        public static String index = "";
        public void A_9()
        {
            MessageBox.Show(index);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listView1.Items.ToString();
            Thread th = new Thread(A_9);
            th.Start();
        }
        public static int Button_M = 0;
        private void button12_Click(object sender, EventArgs e)
        {
            if(Button_M == 0)
            {
                Button_M = 1;
                button12.Text = "<-";
                button3.Text = "서버 종료";
                button4.Text = "파일 제출";
                button6.Text = "정보 보기";
                button5.Text = "PC재접속";
                button7.Enabled = false;
                button11.Enabled = false;
                button9.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
            }
            else
            {
                Button_M = 0;
                button12.Text = "->";
                button3.Text = "계정 추가"; 
                button4.Text = "권한 설정";
                button6.Text = "원격 제어";
                button5.Text = "RunCMD";
                button7.Enabled = true;
                button11.Enabled = true;
                button9.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            nextID = label7.Text;
            nextEM = label9.Text;
            Form13 f13 = new Form13();
            f13.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        public static int ToFormMove = 0;
        public static int MoveValForm_X = 0;
        public static int MoveValForm_Y = 0;
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

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ToFormMove = 0;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
            {
                MessageBox.Show("Error! Account not selected.Please select an account.");
            }
            else
            {
                nextID = label7.Text;
                nextEM = label9.Text;
                Form14 f14 = new Form14();
                f14.ShowDialog();
            }
        }

        private void label17_MouseMove(object sender, MouseEventArgs e)
        {
            if (ToFormMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MoveValForm_X, MousePosition.Y - MoveValForm_Y);
            }
        }

        private void label17_MouseUp(object sender, MouseEventArgs e)
        {
            ToFormMove = 0;
        }

        private void label17_MouseDown(object sender, MouseEventArgs e)
        {
            ToFormMove = 1;
            MoveValForm_X = e.X;
            MoveValForm_Y = e.Y;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void A_7()
        {
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + label7.Text + " PC-Keeper_FILETS.exe " + Form1.LoginID + " " + Form1.LoginPassword);
            RunCommand("java -jar Client.Get.ACIP.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + label7.Text + " " + label8.Text);
            Thread.Sleep(1000);
            string s = System.IO.File.ReadAllText("RemoteClientData.dll");
            RunCommand4("\"File-Transfer-System.exe\" "+s);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
            {
                MessageBox.Show("Error! Account not selected.Please select an account.");
            }
            else
            {
                nextID = label7.Text;
                nextEM = label9.Text;
                Thread th = new Thread(A_7);
                th.Start();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
            {
                MessageBox.Show("Error! Account not selected.Please select an account.");
            }
            else
            {
                nextID = label7.Text;
                nextEM = label9.Text;
                Form15 f15 = new Form15();
                f15.ShowDialog();
            }
        }
        void MenuClick(object obj, EventArgs ea)
        {
            MenuItem mI = (MenuItem)obj;
            String str = mI.Text;

            if (str == "PC-Shutdown")
            {
                if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
                {
                    MessageBox.Show("Error! Account not selected.Please select an account.");
                }
                else
                {
                    nextID = label7.Text;
                    nextEM = label9.Text;
                    DialogResult result = MessageBox.Show("Are you sure you want to shut down the specified PC?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        System.Threading.Thread th = new System.Threading.Thread(A_8);
                        th.Start();
                    }
                }
            }
            if (str == "PC-원격제어")
            {
                if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
                {
                    MessageBox.Show("Error! Account not selected.Please select an account.");
                }
                else
                {
                    rt_Copyrigth();
                    Thread th = new Thread(A_4);
                    th.Start();
                }
            }
            if (str == "WindowLocker")
            {
                if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
                {
                    MessageBox.Show("Error! Account not selected.Please select an account.");
                }
                else
                {
                    nextID = label7.Text;
                    nextEM = label9.Text;
                    Form14 f14 = new Form14();
                    f14.ShowDialog();
                }
            }
            if (str == "PC연결 해제")
            {
                if (label7.Text.Equals("[지정되지않음]") || label7.Text.Equals(""))
                {
                    MessageBox.Show("Error! Account not selected.Please select an account.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to disconnect the client?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        nextID = label7.Text;
                        nextEM = label9.Text;
                        System.Threading.Thread th = new System.Threading.Thread(A_11);
                        th.Start();
                    }
                }
            }
        }

        public void A_11()
        {
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " " + "java#-jar#Client.DC.Main.dll" + " " + Form1.LoginID + " " + Form1.LoginPassword);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

            if (listView1.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
                ListViewItem lvItem = items[0];
                string nodeKey = lvItem.SubItems[0].Text;
                if (!nodeKey.Equals("접속된 계정 없음"))
                {
                    String[] A = AllUserText.Split('#');
                    for (int B = 0; B < A.Length; B++)
                    {
                        String[] C = A[B].Split('%');
                        if (C[0].Equals(nodeKey))
                        {
                            nextPW = C[1];
                            if (C[3].Equals("1"))
                            {
                                this.Invoke(new Action(delegate ()
                                {
                                    label7.Text = nodeKey;
                                    String FormsLoginID = Form1.LoginID;
                                    label10.Text = "권한이 있음";
                                    label8.Text = "권한이 있는 계정의 비밀번호는 표시할수없습니다";
                                    label9.Text = C[2];
                                    button1.Enabled = false;
                                    button2.Enabled = true;
                                    if (FormsLoginID.Equals(nodeKey))
                                    {
                                        button2.Enabled = false;
                                    }
                                }));
                            }
                            else
                            {
                                this.Invoke(new Action(delegate ()
                                {
                                    label7.Text = nodeKey;
                                    label10.Text = "권한이 없음";
                                    label8.Text = C[1];
                                    label9.Text = C[2];
                                    button1.Enabled = true;
                                    button2.Enabled = true;
                                }));
                            }
                        }
                    }
                    String FormLoginID = Form1.LoginID;
                    if (FormLoginID.Equals(nodeKey))
                    {
                        button1.Enabled = false;
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo tvHit = treeView1.HitTest(e.Location);
            if (e.Button == MouseButtons.Right) {
                if (tvHit.Location == TreeViewHitTestLocations.None)
                {
                    EventHandler eh = new EventHandler(MenuClick);
                    MenuItem[] ami = {
                    new MenuItem("WindowLocker",eh),
                    new MenuItem("PC-원격제어",eh),
                    new MenuItem("PC-Shutdown",eh),
                    new MenuItem("PC연결 해제",eh),
                    };
                    ContextMenu = new System.Windows.Forms.ContextMenu(ami);
                }
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form23 f23 = new Form23();
            f23.ShowDialog();
        }
    }
}
