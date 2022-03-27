using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CMC___Client_Pro
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public void A_2()
        {
            for (int i = 0; i < 9999; i++)
            {
                i = 0;
                Thread.Sleep(1000);
                System.IO.FileInfo fi = new System.IO.FileInfo("41630cec-1c07-4062-b068-e26e1a6a0053.dll");
                if (fi.Exists)
                {
                    this.Invoke(new Action(delegate ()
                    {
                        System.IO.File.WriteAllText(Application.StartupPath + "\\Client.Regedit.Data.dll", Form1.LoginID + "@" + Form1.ServerIPs + "@" + Form1.ServerPorts);
                        Reg_write(rPath, rKey, rVal, RegistryValueKind.String);
                        Thread th = new Thread(A_1); th.Start();
                        label8.Visible = true; label7.Visible = false;
                        button2.Text = "접속 해제";
                        A = 1;
                    }));
                }
                else
                {
                    this.Invoke(new Action(delegate ()
                    {
                        Reg_del(rPath, rKey, rVal);
                    }));
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
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
            RunCommand("java -jar Client.Main.MC.dll " + Form1.ServerIPs + " " + Form1.ServerPorts + " " + Form1.LoginID + " 1500");
        }
        private void Reg_write(string rPath, string rKey, string rVal, RegistryValueKind rKnd)
        {
            RegistryKey reg = null;
            if (rPath.StartsWith("HKEY_CLASSES_ROOT")) reg = Registry.ClassesRoot;
            if (rPath.StartsWith("HKEY_CURRENT_USER")) reg = Registry.CurrentUser;
            if (rPath.StartsWith("HKEY_LOCAL_MACHINE")) reg = Registry.LocalMachine;
            if (rPath.StartsWith("HKEY_USERS")) reg = Registry.Users;
            if (rPath.StartsWith("HKEY_CURRENT_CONFIG")) reg = Registry.CurrentConfig;

            reg = reg.CreateSubKey(rPath.Substring((rPath.IndexOf("\\") + 1), rPath.Length - (rPath.IndexOf("\\") + 1)), RegistryKeyPermissionCheck.ReadWriteSubTree);
            reg.SetValue(rKey, rVal, rKnd);
            reg.Close();
        }
        private void Reg_del(string rPath, string rKey, string rVal)
        {
            RegistryKey reg = null;
            if (rPath.StartsWith("HKEY_CLASSES_ROOT")) reg = Registry.ClassesRoot;
            if (rPath.StartsWith("HKEY_CURRENT_USER")) reg = Registry.CurrentUser;
            if (rPath.StartsWith("HKEY_LOCAL_MACHINE")) reg = Registry.LocalMachine;
            if (rPath.StartsWith("HKEY_USERS")) reg = Registry.Users;
            if (rPath.StartsWith("HKEY_CURRENT_CONFIG")) reg = Registry.CurrentConfig;
            reg = reg.OpenSubKey(rPath.Substring((rPath.IndexOf("\\") + 1), rPath.Length - (rPath.IndexOf("\\") + 1)), true);
            if (Registry.GetValue(rPath, rKey, null) == null)
            {
                MessageBox.Show("레지스트리 에러\r\n레지스트리 작업을 설정하는중 삭제하는\r\n과정에서 문제가 발생하였습니다\r\n확인버튼을 눌르면 발생한 문제를 해결합니다.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.FileInfo fi = new System.IO.FileInfo("41630cec-1c07-4062-b068-e26e1a6a0053.dll"); System.IO.FileInfo fi1 = new System.IO.FileInfo("ea26de68-a628-42e1-9cac-8e8bcb4e84c1.dll");
                fi.Delete(); fi.Delete(); fi.Delete(); fi1.Delete(); fi1.Delete(); fi1.Delete(); Application.Restart();
            }
            else
            {
                System.IO.FileInfo fi = new System.IO.FileInfo("41630cec-1c07-4062-b068-e26e1a6a0053.dll");
                System.IO.FileInfo fi1 = new System.IO.FileInfo("ea26de68-a628-42e1-9cac-8e8bcb4e84c1.dll");
                fi.Delete(); fi.Delete(); fi.Delete(); fi1.Delete(); fi1.Delete(); fi1.Delete();
                reg.DeleteValue(rKey);
                Form5 f5 = new Form5();
                f5.Show();
                label8.Visible = false;
                label7.Visible = true;
                button2.Text = "접속";
                A = 0;
            }

        }

        private void Reg_del2(string rPath, string rKey, string rVal)
        {
            RegistryKey reg = null;
            if (rPath.StartsWith("HKEY_CLASSES_ROOT")) reg = Registry.ClassesRoot;
            if (rPath.StartsWith("HKEY_CURRENT_USER")) reg = Registry.CurrentUser;
            if (rPath.StartsWith("HKEY_LOCAL_MACHINE")) reg = Registry.LocalMachine;
            if (rPath.StartsWith("HKEY_USERS")) reg = Registry.Users;
            if (rPath.StartsWith("HKEY_CURRENT_CONFIG")) reg = Registry.CurrentConfig;
            reg = reg.OpenSubKey(rPath.Substring((rPath.IndexOf("\\") + 1), rPath.Length - (rPath.IndexOf("\\") + 1)), true);
            reg.DeleteValue(rKey);
        }
        string sw = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string rPath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";
        string rKey = "TCP-Client";
        string rVal = "\""+Application.StartupPath + "\\Client-UTIL.bat\"";

        string rPath1 = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";
        string rKey1 = "cvxDFFsV";
        string rVal1 = "\"" + Application.StartupPath + "\\cvxDFFsV.bat\"";
        string rPath2 = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";
        string rKey2 = "cvxDFXsV";
        string rVal2 = "\"" + Application.StartupPath + "\\cvxDFXsV.AA.exe\"";

        public static int A = 0;
        private void Form3_Load(object sender, EventArgs e)
        {
            Process[] NetClassClient = Process.GetProcessesByName("cvxDFXsV.AA");
            if (NetClassClient.Length < 1)
            {
                Process.Start("cvxDFXsV.AA.exe");
            }
            Reg_write(rPath2, rKey2, rVal2, RegistryValueKind.String);
            Thread th = new Thread(A_2);
            textBox1.Text = Form1.ServerIPs;
            textBox2.Text = Form1.ServerPorts.ToString();
            textBox3.Text = Form1.LoginID;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            System.IO.FileInfo fi = new System.IO.FileInfo("41630cec-1c07-4062-b068-e26e1a6a0053.dll");
            if (fi.Exists)
            {
                label7.Visible = false;
                button2.Text = "접속 해제";
                A = 1;
            }
            else
            {
                label8.Visible = false;
                button2.Text = "접속";
                A = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            System.IO.DirectoryInfo di = new DirectoryInfo(strFolder + "\\Agent_CG");
            if (!di.Exists)
            {
                di.Create(); di.Create(); di.Create(); di.Create(); di.Create(); di.Create(); di.Create(); di.Create(); di.Create(); di.Create();
                File.Copy("Agent_CG.exe", strFolder + "\\Agent_CG\\Agent_CG.exe", true);
                if (!(new System.IO.FileInfo(strFolder + "\\Agent_CG\\Agent_CG.bat").Exists))
                {
                    System.IO.File.WriteAllText(strFolder + "\\Agent_CG\\Agent_CG.bat", "@echo off\r\nAgent_CG.exe " + Application.StartupPath.Replace(" ", "#") + " 7SNYJGZp3T6CU8ueW6KfdAkffSMMVmFc Client.Login.Nu.dll#Client.Login.Au.dll#Client.Add.Ar.dll#Client.DC.Main.dll#Client.Add.User.dll#Client.Get.ACIP.dll#Client.Get.CAL.dll#Client.Main.MC.dll#Client.Main.MCS.dll#Client.Remove.Ar.dll#Client.Remove.User.dll#Client.Send.MCRC.dll#Client.Server.TaskM.dll#Client.ShowData.dll#Client.User.DataC.dll#Client-UTIL.exe#Client-UTIL_R.exe#Clint.Main.MC.dll#CMC-ClientViewer.exe#File-Transfer-System.exe#Ionic.Zip.dll#JRemoteServer.dll#JRemoteViewer.dll#MetroFramework.dll#MetroFramework.Design.dll\r\nexit");
                }
                else
                {
                    System.IO.FileInfo fi = new FileInfo(strFolder + "\\Agent_CG\\Agent_CG.bat"); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete();
                    System.IO.File.WriteAllText(strFolder + "\\Agent_CG\\Agent_CG.bat", "@echo off\r\nAgent_CG.exe " + Application.StartupPath.Replace(" ", "#") + " 7SNYJGZp3T6CU8ueW6KfdAkffSMMVmFc Client.Login.Nu.dll#Client.Login.Au.dll#Client.Add.Ar.dll#Client.DC.Main.dll#Client.Add.User.dll#Client.Get.ACIP.dll#Client.Get.CAL.dll#Client.Main.MC.dll#Client.Main.MCS.dll#Client.Remove.Ar.dll#Client.Remove.User.dll#Client.Send.MCRC.dll#Client.Server.TaskM.dll#Client.ShowData.dll#Client.User.DataC.dll#Client-UTIL.exe#Client-UTIL_R.exe#Clint.Main.MC.dll#CMC-ClientViewer.exe#File-Transfer-System.exe#Ionic.Zip.dll#JRemoteServer.dll#JRemoteViewer.dll#MetroFramework.dll#MetroFramework.Design.dll\r\nexit");
                }
            }
            if (A == 1)
            {
                System.IO.File.WriteAllText(strFolder + "\\Agent_CG\\7SNYJGZp3T6CU8ueW6KfdAkffSMMVmFc.acg", "");
                Reg_del(rPath, rKey, rVal); Reg_del2(rPath1, rKey1, rVal1);
                System.IO.File.WriteAllText(sw + "\\Xcfnsjwurmfkghrnmfnsdxhjweksjdhbfksadhgfidwuy4rgoih4bew3oiwy4gbiuydxf.dlx","");
            }
            else
            {
                if (!(new System.IO.FileInfo(strFolder + "\\Agent_CG\\Agent_CG.bat").Exists))
                {
                    System.IO.File.WriteAllText(strFolder + "\\Agent_CG\\Agent_CG.bat", "@echo off\r\nAgent_CG.exe " + Application.StartupPath.Replace(" ", "#") + " 7SNYJGZp3T6CU8ueW6KfdAkffSMMVmFc Client.Login.Nu.dll#Client.Login.Au.dll#Client.Add.Ar.dll#Client.DC.Main.dll#Client.Add.User.dll#Client.Get.ACIP.dll#Client.Get.CAL.dll#Client.Main.MC.dll#Client.Main.MCS.dll#Client.Remove.Ar.dll#Client.Remove.User.dll#Client.Send.MCRC.dll#Client.Server.TaskM.dll#Client.ShowData.dll#Client.User.DataC.dll#Client-UTIL.exe#Client-UTIL_R.exe#Clint.Main.MC.dll#CMC-ClientViewer.exe#File-Transfer-System.exe#Ionic.Zip.dll#JRemoteServer.dll#JRemoteViewer.dll#MetroFramework.dll#MetroFramework.Design.dll\r\nexit");
                }
                else
                {
                    System.IO.FileInfo fi = new FileInfo(strFolder + "\\Agent_CG\\Agent_CG.bat"); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete();
                    System.IO.File.WriteAllText(strFolder + "\\Agent_CG\\Agent_CG.bat", "@echo off\r\nAgent_CG.exe " + Application.StartupPath.Replace(" ", "#") + " 7SNYJGZp3T6CU8ueW6KfdAkffSMMVmFc Client.Login.Nu.dll#Client.Login.Au.dll#Client.Add.Ar.dll#Client.DC.Main.dll#Client.Add.User.dll#Client.Get.ACIP.dll#Client.Get.CAL.dll#Client.Main.MC.dll#Client.Main.MCS.dll#Client.Remove.Ar.dll#Client.Remove.User.dll#Client.Send.MCRC.dll#Client.Server.TaskM.dll#Client.ShowData.dll#Client.User.DataC.dll#Client-UTIL.exe#Client-UTIL_R.exe#Clint.Main.MC.dll#CMC-ClientViewer.exe#File-Transfer-System.exe#Ionic.Zip.dll#JRemoteServer.dll#JRemoteViewer.dll#MetroFramework.dll#MetroFramework.Design.dll\r\nexit");
                    Thread th2 = new Thread(run); th2.Start();
                    void run()
                    {
                        System.IO.File.WriteAllText("Agent_CG.bat", "@echo off\r\ncd " + strFolder + "\\Agent_CG\r\nstart Agent_CG.bat" + "\r\nexit");
                        //RunCommand2("Agent_CG.bat");
                        return;
                    }
                    System.IO.File.WriteAllText(Application.StartupPath + "\\Client.Regedit.Data.dll", Form1.LoginID + "@" + Form1.ServerIPs + "@" + Form1.ServerPorts);
                    Reg_write(rPath, rKey, rVal, RegistryValueKind.String);
                    Reg_write(rPath1, rKey1, rVal1, RegistryValueKind.String);
                    Thread th = new Thread(A_1); th.Start();
                    label8.Visible = true; label7.Visible = false;
                    button2.Text = "접속 해제";
                    A = 1;
                    System.IO.File.WriteAllText("cvxDFFsV.bat", "@echo off\r\ncd \"" + sw + "\"" + "\r\nstart cvxDFFsV.AA.exe\r\nexit");
                    //Process.Start("cvxDFFsV.bat");
                }
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form28 f28 = new Form28();
            f28.ShowDialog();
        }
    }
}
