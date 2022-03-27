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
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
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
        public static String ID = "";
        public void A_4()
        {
            for(int i =0; i<10;i++)
            {
                RunCommand("java -jar Client.Send.MCRC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + ID + " PCK_SendData-Client.exe#" + getMyIp() + " " + Form1.LoginID + " " + Form1.LoginPassword);
                Thread.Sleep(1000);
            }
            
        }
        private string getMyIp()
        {

            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }

            return localIP;

        }
        private void Form21_Load(object sender, EventArgs e)
        {
            String[] A1 = Base64Decode(Form20.NextEventData).Split('#');
            ID = A1[0];
            Thread th = new Thread(A_4);
            th.Start();
            
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 7953);
            sock.Bind(ep);
            sock.Listen(10);
            Socket clientSock = sock.Accept();
            byte[] buff = new byte[8192];
            int n = clientSock.Receive(buff);
            string data = Encoding.UTF8.GetString(buff, 0, n);
            Console.WriteLine(data);
            clientSock.Send(buff, 0, n, SocketFlags.None); 
            clientSock.Close();
            sock.Close();
            
            String[] A = data.Split('#');
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "ID - PASSWORD - E-mail";
            dataGridView1.Columns[1].Name = "Operating system";
            dataGridView1.Columns[2].Name = "CPU";
            dataGridView1.Columns[3].Name = "GPU";
            dataGridView1.Columns[4].Name = "RAM";
            dataGridView1.Columns[5].Name = "PC-Name";
            string[] row = { "ID:"+A1[0] +" , PASSWORD: "+A1[1]+" , E-mail: "+A1[2], A[0], A[1], A[2], A[3],A[4] };
            dataGridView1.Rows.Add(row);
        }
    }
}
