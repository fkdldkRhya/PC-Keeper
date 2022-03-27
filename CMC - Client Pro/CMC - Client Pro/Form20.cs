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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }
        public static String NextEventData = "";
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            string[] userlist = Form4.AllUserText.Split('#');
            for (int i = 0; i < userlist.Length; i++)
            {
                string[] A = userlist[i].Split('%');
                string pass = A[1];
                if(int.Parse(A[3]) == 1)
                {
                    pass = "";
                    for (int i1 = 0; i1 < A[1].Length; i1++)
                    {
                        pass = pass + "*";
                    }
                }
                String EventCode = A[0]+"#"+pass+"#"+A[2]+"#"+A[3];
                listBox1.Items.Add("ID: " + A[0] + " , Pass: " + pass +" , E-mail: " + A[2] + " , Account permissions: " + A[3] +" - EventCode: #" + Base64Encode(EventCode));
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx > -1)
            {
                string indexV = listBox1.Items[idx].ToString();
                string[] indexVSP = indexV.Split('#'); string EventCodeB64E = indexVSP[1];
                NextEventData = EventCodeB64E;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx > -1)
            {
                Thread th = new Thread(A);
                th.Start();
            }
        }
        public void A()
        {
            Application.Run(new Form21());
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
