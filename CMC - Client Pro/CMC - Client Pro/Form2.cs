using System;
using MetroFramework.Forms;
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
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            String IP = Form1.ServerIPs;
            String Port = Form1.ServerPorts.ToString();
            textBox1.Text = IP;
            textBox2.Text = Port;
            button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(Form1.ServerIPs))
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals(Form1.ServerPorts.ToString()))
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("succeed! save complete","Sava",MessageBoxButtons.OK,MessageBoxIcon.Information);
            System.IO.File.WriteAllText("Client.ServerData.IPT.dll","[LOGIN]\r\nIP="+textBox1.Text+"\r\nPORT="+textBox2.Text);
            this.Close();
        }
    }
}
