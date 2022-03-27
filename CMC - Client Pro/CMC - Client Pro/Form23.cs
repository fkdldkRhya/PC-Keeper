using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            if (new System.IO.FileInfo("CxzDFFsVdcmWML.dll").Exists)
            {
                label8.Visible = false;
                label9.Visible = true;
                button4.Text = "사용 안함";
            }
            else
            {
                label8.Visible = true;
                label9.Visible = false;
                button4.Text = "사용";
            }
            button3.Enabled = false;
            String FolderName = Application.StartupPath + "\\ServerLogFile";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(FolderName);
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".log") == 0)
                {
                    String FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);
                    String FullFileName = File.FullName;

                    richTextBox1.Text = (FileNameOnly + ".log" + "\r\n" + richTextBox1.Text);
                    button3.Enabled = true;
                }
            }

            if (new System.IO.FileInfo("aLsnxyetensjazcm.dxl").Exists)
            {
                label4.Visible = true;
                label5.Visible = false;
            }
            else
            {
                label4.Visible = false;
                label5.Visible = true;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (new System.IO.FileInfo("aLsnxyetensjazcm.dxl").Exists)
            {
                label4.Visible = false;
                label5.Visible = true;
                System.IO.File.Delete("aLsnxyetensjazcm.dxl");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                if (!textBox1.Text.Equals(null))
                {
                    System.IO.File.WriteAllText("aLsnxyetensjazcm.dxl", SHA256Hash(textBox1.Text));
                    label4.Visible = true;
                    label5.Visible = false;
                }
                else
                {
                    MessageBox.Show("비밀번호를 입력해주세요!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("비밀번호를 입력해주세요!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(" ", "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            System.IO.Directory.CreateDirectory(path + "\\ServerLog");
            String FolderName = Application.StartupPath + "\\ServerLogFile";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(FolderName);
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".log") == 0)
                {

                    String FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);
                    String FullFileName = File.FullName;
                    System.IO.File.Copy(Application.StartupPath + "\\ServerLogFile\\"+ FileNameOnly+".log", path + "\\ServerLog\\" + FileNameOnly + ".log");
                }
            }
            MessageBox.Show("\"" + path + "\\ServerLog\"경로에 로그 파일이 복사 되었습니다.");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public String AESEncrypt256(String Input, String key)
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (new System.IO.FileInfo("CxzDFFsVdcmWML.dll").Exists)
            {
                File.Delete("CxzDFFsVdcmWML.dll");
                label8.Visible = true;
                label9.Visible = false;
                button4.Text = "사용";
            }
            else
            {
                String GETLOGINDATA = Form1.LoginID + "#" + Form1.LoginPassword;
                GETLOGINDATA = AESEncrypt256(GETLOGINDATA, "MfCt{j8@[Y5~8;EH");
                File.WriteAllText("CxzDFFsVdcmWML.dll", GETLOGINDATA);
                label8.Visible = false;
                label9.Visible = true;
                button4.Text = "사용 안함";
            }
        }
    }
}
