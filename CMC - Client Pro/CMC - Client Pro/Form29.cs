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
    public partial class Form29 : Form
    {
        public Form29()
        {
            InitializeComponent();
        }
        public static String Next;
        private void Form29_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String D = Form30.NextPTData;
            String[] DS = D.Split('#');
            for(int i = 0; i < DS.Length; i++)
            {
                String[] DSS = DS[i].Split('%');
                if (DSS[1].Equals("1"))
                {
                    listBox1.Items.Add("ID: " + DSS[0] + " / 권한: 있음");
                }
                else
                {
                    listBox1.Items.Add("ID: " + DSS[0] + " / 권한: 없음");
                }
            }
            listBox1.Items.Add("사용하지 않음");
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx > -1)
            {
                string indexV = listBox1.Items[idx].ToString();
                indexV = indexV.Replace(" / 권한: 있음" , "");
                indexV = indexV.Replace(" / 권한: 없음", "");
                indexV = indexV.Replace("ID: ", "");
                Next = indexV;
                Form28 f28 = new Form28();
                f28.RELOAD();
                this.Close();
            }
        }
    }
}
