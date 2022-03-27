using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form24 : MetroForm
    {
        public Form24()
        {
            InitializeComponent();
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            metroTextBox1.PasswordChar = '*';
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (SHA256Hash(metroTextBox1.Text).Equals(System.IO.File.ReadAllText("aLsnxyetensjazcm.dxl")))
            {
                MessageBox.Show("Passwords match. Authentication successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1.NextINT = 1;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid password. Please re-enter." , "Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        }
    }
}
