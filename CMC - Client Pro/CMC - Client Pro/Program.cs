using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    static class Program
    {
        ///Version=================================///
        public static String Version = "1.0.00000";
        ///Version=================================///

        /// <PC-Keeper_INFO>
        /// 
        /// Copyright 2019 Sihun. All rights reserved.
        /// JRemoteServer.dll,JRemoteViewer.dll - http://blog.naver.com/PostView.nhn?bllogId=jjjy3742&logNo=220952097632
        /// FormStyle - MetroFramework.dll
        /// TCP_Thread_Server (PC-Keeper Server) - Sihun
        /// 
        /// <MetroFramework Copyright>
        /// MetroFramework - Modern UI for WinForms
        /// Copyright(c) 2013 Jens Thiel, http://thielj.github.io/MetroFramework
        /// Permission is hereby granted, free of charge, to any person obtaining a copy of 
        /// this software and associated documentation files(the "Software"), to deal in the
        /// Software without restriction, including without limitation the rights to use, copy,
        /// modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
        /// and to permit persons to whom the Software is furnished to do so, subject to the
        /// following conditions:
        /// The above copyright notice and this permission notice shall be included in
        /// all copies or substantial portions of the Software.
        /// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
        /// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
        /// PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
        /// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
        /// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
        /// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
        /// Portions of this software are:
        /// Copyright (c) 2011 Sven Walter, http://github.com/viperneo
        /// 
        /// <PC-Keeper Client Module Copyright>
        /// ---------------------------------------------
        /// Client.Add.Ar.dll , Client.Add.User.dll
        /// Client.DC.Main.dll , Client.Debug.SendJM.dll
        /// Client.Get.ACIP.dll , Client.Get.CAL.dll
        /// Client.Login.Au.dll , Client.Login.Nu.dll
        /// Client.Main.Key.dll , Client.Main.MC.dll
        /// Client.Main.MCS.dll , Client.Remove.Ar.dll
        /// Client.Remove.User.dll , Client.Send.MCRC.dll
        /// Client.Server.TaskM.dll , Client.ShowData.dll
        /// Client.User.DataC.dll , Clint.Main.MC.dll
        /// ----------------------------- Create By: Sihun
        /// 
        /// <PC-Keeper 이용약관>
        /// ====================================================================================================
        ///  1. 개인 정보 수집 동의
        ///  본 프로그램은 정품 인증 처리를 위해 아래에 명시되어있는 사용자의 정보를 수집하게
        ///  됩니다.그리고 버그 신고 기능을 이용할 때 사용자의 아이피(IP) 를 수집하게 됩니다.
        ///  - MAC 주소
        ///  - 사용자의 아이피(IP)
        ///  
        ///  2. 프로그램 저작권
        ///  PC-Keeper라는 프로그램은 Sihun이 제작한 것으로 모든 권한은 개발자에게 있습니다.
        ///  PC-Keeper에 관련된 프로그램들을 재배포 및 수정 등을 할 경우에는 모든 법적 책임을
        ///  받을 것입니다.
        ///  
        ///  3. 기타 문제 발생
        ///  이 프로그램으로 인해 발생한 모든 비용적 문제 등은 원저작자인 Sihun이 처벌을 받지
        ///  않고 모든 책임은 사용자에게 있습니다.
        ///  
        ///  4. 재판권 및 준거법
        ///  이 약관에 명시되지 않은 사항은 저작자 및 개발사의 소프트웨어 사용권 동의(EULA) 에 따르며, 그 외 사항은 정보통신망이용촉진 및 정보보호에관한법률 등 관계법령과 상관행에 따릅니다.“소프트웨어(PC-Keeper Sihun)” 이용으로 발생한 분쟁에 대해 소송이 제기되는 경우 민사소송법 상의 관할 법원으로 합니다.
        ///  
        ///  5. 이용자의 의무
        ///  "이용자”는 본 약관에서 규정하는 사항과 기타 “Sihun”(이) 가 정한 제반 규정, 공지사항 및 관계법령을 준수하여야 하며, 기타 “Sihun”의 업무에 방해가 되는 행위, “Sihun”의 명예를 손상시키는 행위를 해서는 안됩니다.“이용자”는 “Sihun”가 제공하는 “서비스” 혹은 “소프트웨어(PC-Keeper Sihun)”를 이용해야 하며, 다른 방법으로 이용하거나 제공 서버 등에 접근을 시도해서는 안됩니다“이용자”는 “Sihun” 및 제 3자의 지적 재산권을 침해해서는 안됩니다.
        ///  해당 약관은 2019년 10월 18일 오전 1시 42분 원저작자가 작성한 내용입니다.
        ///  이 프로그램은 상업적 용도로 사용하지 않습니다.
        ///  Copyright 2019 Sihun / All rights reserved.
        /// ====================================================================================================
        /// 위의 내용은 "PC Keeper Setup Wizard"를 통해 볼수있습니다.
        /// 
        /// </PC-Keeper_INFO>

        public static String KeySPD = "";
        public static String XczADDF = "";
        public static String URL;
        public static String ResultUpdateData;
        public static String NextData = "";
        public static int INFOFORMPROGRESSBARVAL = 0;
        public static bool IsAdministrator() { WindowsIdentity identity = WindowsIdentity.GetCurrent(); if (null != identity) { WindowsPrincipal principal = new WindowsPrincipal(identity); return principal.IsInRole(WindowsBuiltInRole.Administrator); } return false; }
        public static byte[] A000x05(String A0x001) { return Convert.FromBase64String(A0x001); }
        private static string GetMacAddress() { return NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString(); }
        public static string[] publicServerINFO = null;
        public static void OpenNextForm()
        {
            Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new Form1());
            
            String[] KeySP = KeySPD.Split('%');
            Guid g = Guid.NewGuid(); String MainServerKey = g.ToString();
            RunCommand("java -jar Client.Main.Key.dll " + KeySP[0] + " " + KeySP[1] + " Add " + System.IO.File.ReadAllText("PC-Keeper_Key.pky") + " " + GetMacAddress() + " " + MainServerKey);
            INFOFORMPROGRESSBARVAL = 100;
            if (new System.IO.FileInfo("PCK_LOGFSTMC.cxDFF").Exists)
            {
                Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new Form1());
            }
            else
            {
                DialogResult result = MessageBox.Show("PC-Keeper 실행이 처음이신가요? PC-Keeper 서버 / 클라이언트 사용 방법을 확인하시겠습니까?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new Form26());
                }
                else
                {
                    Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new Form1());
                }
            }
        }
        public static String AESEncrypt256(String Input, String key)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Encoding.UTF8.GetBytes(Input);
                    cs.Write(xXml, 0, xXml.Length);
                }

                xBuff = ms.ToArray();
            }

            String Output = Convert.ToBase64String(xBuff);
            return Output;
        }

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>

        [STAThread]
        static void Main(String[] args)
        {
            if (IsAdministrator() == false) { try { ProcessStartInfo procInfo = new ProcessStartInfo(); procInfo.UseShellExecute = true; procInfo.FileName = Application.ExecutablePath; procInfo.WorkingDirectory = Environment.CurrentDirectory; procInfo.Verb = "runas"; Process.Start(procInfo); } catch (Exception) {  } return; }
            //AgentCG - Check//
            string exeAgentCG_File_Name = "Agent_CG.exe";
            string exeClientUTIL_File_Name = "Client-UTIL.exe";
            string exeClientUTIL_R_File_Name = "Client-UTIL_R.exe";
            if(!new FileInfo(exeAgentCG_File_Name).Exists)
            {
                File.WriteAllBytes(@exeAgentCG_File_Name, Convert.FromBase64String(AgentCG_Base64Code.AgentCG));
                if (!new FileInfo(exeClientUTIL_File_Name).Exists)
                {
                    File.WriteAllBytes(@exeClientUTIL_File_Name, Convert.FromBase64String(ClientUTIL_Base64Code.Client_UTIL));
                    if (!new FileInfo(exeClientUTIL_R_File_Name).Exists)
                    {
                        File.WriteAllBytes(@exeClientUTIL_R_File_Name, Convert.FromBase64String(ClientUTIL_R_Base64Code.ClientUTIL_R));
                    }
                }
            }
            //AgentCG - Check//
            //Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new Form28());
            
            //INT Java Check//
            RunCommand("start PCK.JavaINTCheckProcessHost.exe");
            Guid guid1 = Guid.NewGuid(); Guid guid2 = Guid.NewGuid();
            string Key = guid1.ToString(); string KeyV = guid2.ToString();
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
            process.StandardInput.Write(@"java -jar PCK_JavaINTCheck.dll " + Key + ".temp " + KeyV + "" + Environment.NewLine);
            process.StandardInput.Close();
            string resultCMD = process.StandardOutput.ReadToEnd();
            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(resultCMD);
            sb.Append("\r\n");
            process.WaitForExit();
            process.Close();
            Thread.Sleep(100);
            if (new System.IO.FileInfo(Key + ".temp").Exists)
            {
                string FileV = System.IO.File.ReadAllText(Key + ".temp");
                if (FileV.Equals(KeyV))
                {
                    System.IO.File.Delete(Key + ".temp");
                }
                else
                {
                    MessageBox.Show("Error! Java 1.8.0 or higher is not installed or Java environment variable is not registered.Please install Java 1.8.0 version and try.\r\n" + sb.ToString());
                    return;
                }
            }
            else
            {
                MessageBox.Show("Error! Java 1.8.0 or higher is not installed or Java environment variable is not registered.Please install Java 1.8.0 version and try.\r\n" + sb.ToString());
                return;
            }
            //INT Java Check//

            //PCK-PP AFL//
            String Axmd = "";
            string sw = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (System.IO.Directory.Exists(Application.StartupPath))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath);
                foreach (var item in di.GetFiles())
                {
                    if (!item.Name.Equals("PCK_LOGFSTMC.cxDFF"))
                    {
                        if (!item.Name.Equals("PC-Keeper_Key.pky"))
                        {
                            if (!item.Name.Equals("41630cec-1c07-4062-b068-e26e1a6a0053.dll"))
                            {
                                if (!item.Name.Equals("51045342-c7bd-4a0c-a3d3-a151bf4053bx.dll"))
                                {
                                    Axmd = Axmd + "#" + Application.StartupPath + "\\" + item.Name;
                                }
                            }
                        }
                    }
                }
            }
            
            Axmd = Axmd.Substring(1);
            Axmd = AESEncrypt256(Axmd, "MfCt{j8@[Y5~8;EH");

            File.WriteAllText(sw + "\\cvxDFFsVLF.dxl",Axmd);
            File.WriteAllText("Client-UTIL.bat", "@echo off\r\ncd \""+Application.StartupPath+ "\"\r\nstart Client-UTIL.exe\r\nexit");
            //PCK-PP AFL//
            
            Thread openFormINFO = new Thread(OFINFO); openFormINFO.Start();
            void OFINFO()
            {
                Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new Form22());
            }
            //OpenNextForm();
            

            string strFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.Windows);
            bool bNew;
            Mutex mutex = new Mutex(true, "MutexName", out bNew);
            if (bNew)
            { 
                INFOFORMPROGRESSBARVAL = 10;
                //mutex.ReleaseMutex();
                String A0x004 = "aHR0cDovL3d3dy4ydnluZmQ0aHRwcGxqa3RibWd0dC5rcm8ua3Iv";
                byte[] A0x002 = A000x05(A0x004); String A0x001 = Encoding.UTF8.GetString(A0x002);
                String Data = null;
                WebRequest request = null;
                WebResponse response = null;
                Stream resStream = null;
                StreamReader resReader = null;
                try
                {
                    String uriString = A0x001;
                    request = WebRequest.Create(uriString.Trim());
                    response = request.GetResponse();
                    resStream = response.GetResponseStream();
                    resReader = new StreamReader(resStream);
                    string resString = resReader.ReadToEnd();
                    Data = resString;
                    INFOFORMPROGRESSBARVAL = 20;
                }
                catch (Exception) { }
                finally { if (resReader != null) resReader.Close(); if (response != null) response.Close(); }
                Data = Data.Replace("<html>", ""); Data = Data.Replace("<head>", ""); Data = Data.Replace("<title>PC-Keeper_Key</title>", ""); Data = Data.Replace("</body>", "");
                Data = Data.Replace("</html>", ""); Data = Data.Replace("\r\n", "");
                NextData = Data;
                if (new System.IO.FileInfo("PC-Keeper_Key.pky").Exists)
                {
                    INFOFORMPROGRESSBARVAL = 30;
                    int C = 0;
                    string ReadFile = System.IO.File.ReadAllText("PC-Keeper_Key.pky");
                    string OKey = ReadFile;
                    ReadFile = SHA256Hash(System.IO.File.ReadAllText("PC-Keeper_Key.pky"));
                    string[] sp = Data.Split('#');
                    for (int i = 0; i < sp.Length; i++)
                    {
                        INFOFORMPROGRESSBARVAL = 40;
                        String UpdateResult = CheckUpdate();
                        String[] AAA = UpdateResult.Split('#');
                        String VersionR = AAA[0]; URL = AAA[1];
                        UpdateResult = VersionR; publicServerINFO = AAA;
                        INFOFORMPROGRESSBARVAL = 50; KeySPD = AAA[3];
                        String[] XNC = AAA[3].Split('%');
                        XczADDF = XNC[0];
                        if (ReadFile.Equals(sp[i]))
                        {
                            INFOFORMPROGRESSBARVAL = 60;
                            if (int.Parse(Version.Replace(".", "")) >= int.Parse(UpdateResult.Replace(".", "")))
                            {
                                INFOFORMPROGRESSBARVAL = 80;
                                String[] KeySP = AAA[3].Split('%'); Guid g = Guid.NewGuid(); String MainServerKey = g.ToString();
                                RunCommand("java -jar Client.Main.Key.dll " + KeySP[0] + " " + KeySP[1] + " Check " + OKey + " " + GetMacAddress() + " " + MainServerKey);
                                Thread.Sleep(1000);
                                String ReadFileKeyRS = System.IO.File.ReadAllText("PC-KeeperKeyCheck.data");
                                String[] ReadFileKeySP = ReadFileKeyRS.Split('#');
                                if (ReadFileKeySP[1].Equals(MainServerKey))
                                {
                                    if (ReadFileKeySP[0].Equals("true"))
                                    {
                                        INFOFORMPROGRESSBARVAL = 90;
                                        MainServerKey = g.ToString();
                                        RunCommand("java -jar Client.Main.Key.dll " + KeySP[0] + " " + KeySP[1] + " Check " + OKey + " " + GetMacAddress() + " " + MainServerKey);
                                        Thread.Sleep(1000);
                                        ReadFileKeyRS = System.IO.File.ReadAllText("PC-KeeperKeyCheck.data");
                                        ReadFileKeySP = ReadFileKeyRS.Split('#');
                                        if (ReadFileKeySP[1].Equals(MainServerKey))
                                        {
                                            if (ReadFileKeySP[0].Equals("true"))
                                            {
                                                OpenNextForm();
                                            }
                                            else
                                            {
                                                if (GetMacAddress().Equals(ReadFileKeySP[0]))
                                                {
                                                    OpenNextForm();
                                                }
                                                else
                                                {
                                                    INFOFORMPROGRESSBARVAL = 100;
                                                    MessageBox.Show("The key entered is already in use by another user.Please enter another key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    System.IO.FileInfo fi = new System.IO.FileInfo("PC-Keeper_Key.pky");
                                                    fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete();
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            INFOFORMPROGRESSBARVAL = 100;
                                            MessageBox.Show("The authentication key received from the PC-Keeper activation key server does not match.");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        INFOFORMPROGRESSBARVAL = 80;
                                        if (GetMacAddress().Equals(ReadFileKeySP[0]))
                                        {
                                            MainServerKey = g.ToString();
                                            RunCommand("java -jar Client.Main.Key.dll " + KeySP[0] + " " + KeySP[1] + " Check " + OKey + " " + GetMacAddress() + " " + MainServerKey);
                                            Thread.Sleep(1000);
                                            ReadFileKeyRS = System.IO.File.ReadAllText("PC-KeeperKeyCheck.data");
                                            ReadFileKeySP = ReadFileKeyRS.Split('#');
                                            if (ReadFileKeySP[1].Equals(MainServerKey))
                                            {
                                                if (ReadFileKeySP[0].Equals("true"))
                                                {
                                                    OpenNextForm();
                                                }
                                                else
                                                {
                                                    if (GetMacAddress().Equals(ReadFileKeySP[0]))
                                                    {
                                                        OpenNextForm();
                                                    }
                                                    else
                                                    {
                                                        INFOFORMPROGRESSBARVAL = 100;
                                                        MessageBox.Show("The key entered is already in use by another user.Please enter another key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        System.IO.FileInfo fi = new System.IO.FileInfo("PC-Keeper_Key.pky");
                                                        fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete();
                                                        return;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                INFOFORMPROGRESSBARVAL = 100;
                                                MessageBox.Show("The authentication key received from the PC-Keeper activation key server does not match.");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            INFOFORMPROGRESSBARVAL = 100;
                                            MessageBox.Show("The key entered is already in use by another user.Please enter another key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            System.IO.FileInfo fi = new System.IO.FileInfo("PC-Keeper_Key.pky");
                                            fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete();
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    INFOFORMPROGRESSBARVAL = 100;
                                    MessageBox.Show("The authentication key received from the PC-Keeper activation key server does not match.");
                                    return;
                                }
                            }
                            else
                            {
                                INFOFORMPROGRESSBARVAL = 80;
                                if (AAA[2].Equals("T"))
                                {
                                    INFOFORMPROGRESSBARVAL = 100;
                                    DialogResult result = MessageBox.Show("A new version has been found. Would you like to download and install the setup of the new version?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (result == DialogResult.Yes)
                                    {
                                        ResultUpdateData = UpdateResult;
                                        Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new Form18());
                                    }
                                    else
                                    {
                                        INFOFORMPROGRESSBARVAL = 80;
                                        String[] KeySP = AAA[3].Split('%'); Guid g = Guid.NewGuid(); String MainServerKey = g.ToString();
                                        RunCommand("java -jar Client.Main.Key.dll " + KeySP[0] + " " + KeySP[1] + " Check " + OKey + " " + GetMacAddress() + " " + MainServerKey);
                                        Thread.Sleep(1000);
                                        String ReadFileKeyRS = System.IO.File.ReadAllText("PC-KeeperKeyCheck.data");
                                        String[] ReadFileKeySP = ReadFileKeyRS.Split('#');
                                        if (ReadFileKeySP[1].Equals(MainServerKey))
                                        {
                                            if (ReadFileKeySP[0].Equals("true"))
                                            {
                                                OpenNextForm();
                                            }
                                            else
                                            {
                                                if (GetMacAddress().Equals(ReadFileKeySP[0]))
                                                {
                                                    OpenNextForm();
                                                }
                                                else
                                                {
                                                    INFOFORMPROGRESSBARVAL = 100;
                                                    MessageBox.Show("The key entered is already in use by another user.Please enter another key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    System.IO.FileInfo fi = new System.IO.FileInfo("PC-Keeper_Key.pky");
                                                    fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete();
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            INFOFORMPROGRESSBARVAL = 100;
                                            MessageBox.Show("The authentication key received from the PC-Keeper activation key server does not match.");
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    String[] KeySP = AAA[3].Split('%'); Guid g = Guid.NewGuid(); String MainServerKey = g.ToString();
                                    RunCommand("java -jar Client.Main.Key.dll " + KeySP[0] + " " + KeySP[1] + " Check " + OKey + " " + GetMacAddress() + " " + MainServerKey);
                                    Thread.Sleep(1000);
                                    String ReadFileKeyRS = System.IO.File.ReadAllText("PC-KeeperKeyCheck.data");
                                    String[] ReadFileKeySP = ReadFileKeyRS.Split('#');
                                    INFOFORMPROGRESSBARVAL = 80;
                                    if (ReadFileKeySP[1].Equals(MainServerKey))
                                    {
                                        if (ReadFileKeySP[0].Equals("true"))
                                        {
                                            OpenNextForm();
                                        }
                                        else
                                        {
                                            if (GetMacAddress().Equals(ReadFileKeySP[0]))
                                            {
                                                OpenNextForm();
                                            }
                                            else
                                            {
                                                INFOFORMPROGRESSBARVAL = 100;
                                                MessageBox.Show("The key entered is already in use by another user.Please enter another key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                System.IO.FileInfo fi = new System.IO.FileInfo("PC-Keeper_Key.pky");
                                                fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete(); fi.Delete();
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        INFOFORMPROGRESSBARVAL = 100;
                                        MessageBox.Show("The authentication key received from the PC-Keeper activation key server does not match.");
                                        return;
                                    }
                                }
                                break;

                            }
                        }
                        else
                        {   
                            C = 1;
                        }
                    }
                    if (C == 1)
                    {
                        INFOFORMPROGRESSBARVAL = 100;
                        Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new Form16());
                    }
                }
                else
                {
                    INFOFORMPROGRESSBARVAL = 100; 
                    Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new Form16());
                }
            }
            else
            {
                INFOFORMPROGRESSBARVAL = 100;
                MessageBox.Show("The program is already running. Please exit and run the program.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
        public static void RunCommand(String command)
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
            Data = Data.Replace("<html>", ""); Data = Data.Replace("<head>", ""); Data = Data.Replace("<title>PC-Keeper_Update</title>", "");
            Data = Data.Replace("</body>", ""); Data = Data.Replace("</html>", ""); Data = Data.Replace("\r\n", "");
            return Data;
        }

        public static string SHA256Hash(string data)
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
    }
}
