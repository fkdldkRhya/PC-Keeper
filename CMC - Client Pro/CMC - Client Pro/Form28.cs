using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form28 : Form
    {
        public Form28()
        {
            InitializeComponent();
        }
        public static string A;
        public static string B;
        public static RegistryKey reg;
        private void Form28_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.ONLYIDLOGIN.Equals("@xmdj%djdnxak@vmvjfk;%fgkvjk793jdkas92@"))
            {
                textBox1.Text = Properties.Settings.Default.ONLYIDLOGIN;
            }
            else
            {
                textBox1.Text = "사용하지 않음";
            }

        }
        public static String AD;
        public void RELOAD()
        {
            string A = Form29.Next;
            AD = A;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form30 f30 = new Form30();
            f30.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (AD.Equals("사용하지 않음"))
                {
                    Properties.Settings.Default.ONLYIDLOGIN = "@xmdj%djdnxak@vmvjfk;%fgkvjk793jdkas92@";
                    Properties.Settings.Default.Save();
                    textBox1.Text = AD;
                }
                else
                {
                    Properties.Settings.Default.ONLYIDLOGIN = AD;
                    Properties.Settings.Default.Save();
                    textBox1.Text = AD;
                }
            }
            catch (System.NullReferenceException) { }
        }

        private void Form28_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
