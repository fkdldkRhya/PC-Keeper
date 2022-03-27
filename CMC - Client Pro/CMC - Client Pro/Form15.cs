using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        public static int A = 0;
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
        public void A_3()
        {
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " start#GetProcessList.exe " + Form1.LoginID + " " + Form1.LoginPassword);
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " start#GetProcessList.exe " + Form1.LoginID + " " + Form1.LoginPassword);
            RunCommand("java -jar Client.Get.ACIP.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " " + Form4.nextPW);
            Thread.Sleep(1000);
            int recv = 0;
            byte[] data = new byte[2024];
            string stringData;
            try
            {
                try
                {
                    IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(System.IO.File.ReadAllText(Application.StartupPath + "\\RemoteClientData.dll")), 9050);

                    Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                    EndPoint remoteEP = (EndPoint)sender;

                    string welcome = "AVX";
                    data = Encoding.UTF8.GetBytes(welcome);
                    client.SendTo(data, data.Length, SocketFlags.None, serverEP);

                    data = new byte[2024];
                    recv = client.ReceiveFrom(data, ref remoteEP);

                    stringData = Encoding.UTF8.GetString(data, 0, recv);
                    RD = stringData;
                    client.Close();
                    A1 = 1;
                }
                catch (System.FormatException)
                {
                    try
                    {
                        FTCH();
                        MessageBox.Show("Error! Server connection failure!");
                        if (!this.IsHandleCreated)
                        {
                            this.CreateHandle();
                        }
                        this.Invoke(new Action(delegate ()
                        {
                            Form15 f15 = new Form15();
                            f15.Close();
                        }));
                    }
                    catch (System.ObjectDisposedException)
                    {

                    }
                }
            }
            catch (System.Net.Sockets.SocketException)
            {
                try
                {
                    FTCH();
                    MessageBox.Show("Error! Server connection failure!");
                    if (!this.IsHandleCreated)
                    {
                        this.CreateHandle();
                    }
                    this.Invoke(new Action(delegate ()
                    {
                        Form15 f15 = new Form15();
                        f15.Close();
                    }));
                }
                catch (System.ObjectDisposedException)
                {

                }
            }
        }

        private void FTCH()
        {
            IntPtr x;
            if (!this.IsHandleCreated)
            {
                x = this.Handle;
            }
        }

        public void A_2()
        {

            for (int i = 0; i < 100; i++)
            {
                i = 0;
                Thread.Sleep(1000);
                if (A1 == 1)
                {
                    A1 = 0;
                    String[] B = RD.Split('#');
                    for (int i1 = 0; i1 < B.Length; i1++)
                    {
                        if (!B[i1].Equals("svchost"))
                        {
                            try
                            {
                                this.Invoke(new Action(delegate ()
                                {
                                    listBox1.Items.Add("프로세스 이름: " + B[i1]);
                                }));
                            }
                            catch (System.InvalidOperationException)
                            {
                                if (!this.IsHandleCreated)
                                {
                                    this.CreateHandle();
                                }
                                this.Invoke(new Action(delegate ()
                                {
                                    listBox1.Items.Add("프로세스 이름: " + B[i1]);
                                }));
                            }
                        }
                    }
                    i = 1000;
                }
            }
        }
        public static String RD = "";
        public static int A1 = 0;
        public static String B = "";
        private void Form15_Load(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
            }
            Thread th = new Thread(A_3); th.Start();
            Thread th2 = new Thread(A_2); th2.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox1.Text.Equals(""))
            {
                String[] B = RD.Split('#');
                for (int i1 = 0; i1 < B.Length; i1++)
                {
                    if (!B[i1].Equals("svchost"))
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            listBox1.Items.Add("프로세스 이름: " + B[i1]);
                        }));
                    }
                }
            }
            else
            {
                String Bs = textBox1.Text;
                String[] B = RD.Split('#');
                for (int i1 = 0; i1 < B.Length; i1++)
                {
                    if (!B[i1].Equals("svchost"))
                    {
                        if (B[i1].Contains(Bs))
                        {

                            listBox1.Items.Add("프로세스 이름: " + B[i1]);
                        }
                    }
                }
            }
        }

        public void A_4()
        {
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " start#PC-Keeper_Toxg.exe " + Form1.LoginID + " " + Form1.LoginPassword);
            MessageBox.Show("Toxg[TaskKill]의 실행을 성공함.", "성공!");
        }
        public void A_5()
        {
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " java#-jar#Stop.dll#Cks0983pop " + Form1.LoginID + " " + Form1.LoginPassword);
            MessageBox.Show("Toxg[TaskKill]의 실행을 종료함.", "성공!");
        }
        public void A_6()
        {
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " java#-jar#PC-Keeper_Toxg_Writer.dll#"+B+" " + Form1.LoginID + " " + Form1.LoginPassword);
            MessageBox.Show("Toxg[TaskKill]의 프로세스 리스트에 해당 항목을 추가함.", "성공!");
        }
        public void A_7()
        {
            RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form4.nextID + " java#-jar#processListReset.dll " + Form1.LoginID + " " + Form1.LoginPassword);
            MessageBox.Show("Toxg[TaskKill]의 프로세스 리스트를 초기화함", "성공!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(A_4); th.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(A_5); th.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(A_6); th.Start();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx > -1)
            {
                int index = listBox1.SelectedIndex; String temp = (String)listBox1.Items[index];
                temp = temp.Replace("프로세스 이름: ", ""); B = temp; B = B.Replace(" ", "#");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(A_7); th.Start();
        }
    }
}
