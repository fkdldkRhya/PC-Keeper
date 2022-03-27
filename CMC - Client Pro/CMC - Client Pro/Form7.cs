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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public static String PASS = Form4.nextPW;
        public static String ID = Form4.nextID;
        private void Form7_Load(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
            label5.Text = Form4.nextID+"]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(PASS))
            {
                Form6 f6 = new Form6();
                f6.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid password, please try again.","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Equals(PASS))
                {
                    Form6 f6 = new Form6();
                    f6.Show();
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
