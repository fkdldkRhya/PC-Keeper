using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        public static String A = "";
        private void button1_Click(object sender, EventArgs e)
        {
            String PASS = Form1.LoginPassword;
            if (textBox1.Text.Equals(PASS))
            {
                A = "YES";
                MessageBox.Show("변경 버튼을 한번더 눌러주세요.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid password, please try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
            A = "NO";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                String PASS = Form1.LoginPassword;
                if (textBox1.Text.Equals(PASS))
                {
                    A = "YES";
                    MessageBox.Show("변경 버튼을 한번더 눌러주세요.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid password, please try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
