using Ionic.Zip;
using MetroFramework.Forms;
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
    public partial class Form18 : MetroForm
    {
        public Form18()
        {
            InitializeComponent();
        }
        public void A_1()
        {
            String Data = null;
            WebRequest request = null;
            WebResponse response = null;
            Stream resStream = null;
            StreamReader resReader = null;
            try
            {
                String uriString = URL;
                request = WebRequest.Create(uriString.Trim());
                response = request.GetResponse();
                resStream = response.GetResponseStream();
                resReader = new StreamReader(resStream);
                string resString = resReader.ReadToEnd();
                Data = resString;
            }
            catch (Exception) { }
            finally { if (resReader != null) resReader.Close(); if (response != null) response.Close(); }
            string A = "<!DOCTYPE html PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">\r\n" +
        "<html>\r\n" +
        "<head>\r\n" +
        "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=EUC-KR\">\r\n" +
        "<title>PCK-Update</title>\r\n" +
        "</head>\r\n" +
        "<body>";
            Data = Data.Replace(A,"");
            Data = Data.Replace("<html>", ""); Data = Data.Replace("<head>", ""); Data = Data.Replace("<title>PCK-Update</title>", ""); Data = Data.Replace("</body>", ""); Data = Data.Replace("</html>", ""); Data = Data.Replace("\r\n", "");
            File.WriteAllBytes(@"PCK_unzpUD.zip", Convert.FromBase64String(Data));
            for (int i = 0; i < 90; i++)
            {
                Thread.Sleep(100);
                this.Invoke(new Action(delegate ()
                {
                    metroProgressBar1.PerformStep();
                    metroProgressBar2.PerformStep();
                }));
            }
            ExtractZipfile("PCK_unzpUD.zip", "PCK_unzp\\v" + Program.Version);
            RunCommand("PCKUD_unZip.exe PCK_unzp\\v" + Program.Version);
            this.Invoke(new Action(delegate ()
            {
                MessageBox.Show("업데이트 성공! 런처를 다시 실행해 주십시오.","INFO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Application.Exit();
                Application.ExitThread();
                Environment.Exit(0);
                this.Close();
            }));
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
        void ExtractZipfile(string sourceFilePath, string targetPath)
        {
            Encoding ibm437 = Encoding.GetEncoding("IBM437");
            Encoding euckr = Encoding.GetEncoding("euc-kr");
            using (ZipFile zip = new ZipFile(sourceFilePath))
            {
                foreach (ZipEntry entry in zip.Entries)
                {
                    byte[] ibm437_byte = ibm437.GetBytes(entry.FileName);
                    string euckr_fileName = euckr.GetString(ibm437_byte);
                    entry.FileName = euckr_fileName;
                    entry.Extract(targetPath, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
        public static string URL;
        private void Form18_Load(object sender, EventArgs e)
        {

            if(new System.IO.FileInfo("PCK_unzpUD.zip").Exists)
            {
                File.Delete("PCK_unzpUD.zip"); File.Delete("PCK_unzpUD.zip"); File.Delete("PCK_unzpUD.zip"); File.Delete("PCK_unzpUD.zip"); File.Delete("PCK_unzpUD.zip"); File.Delete("PCK_unzpUD.zip");
            }

            System.IO.DirectoryInfo di = new DirectoryInfo("PCK_unzp\\v" + Program.Version);
            if (di.Exists)
            {
                DirectoryInfo dir = new DirectoryInfo(di.ToString());
                System.IO.FileInfo[] files = dir.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (System.IO.FileInfo file in files)
                {
                    file.Attributes = FileAttributes.Normal;
                }
                Directory.Delete(di.ToString(), true);
            }
            di.Create();
            //URL = Program.URL;
            Thread th = new Thread(A_1);
            th.Start();
        }
    }
}
