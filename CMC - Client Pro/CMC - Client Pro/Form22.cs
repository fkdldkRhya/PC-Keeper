using MetroFramework.Forms;
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
    public partial class Form22 : Form
    {
        public static int ToFormMove = 0;
        public static int MoveValForm_X = 0;
        public static int MoveValForm_Y = 0;
        public Form22()
        {
            InitializeComponent();
        }
        private void Form22_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.INFOFORMPROGRESSBARVAL > 70)
            {
                metroProgressBar1.Value = 100;
                timer1.Stop();
                this.Close();
            }
            metroProgressBar1.Value = Program.INFOFORMPROGRESSBARVAL;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ToFormMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MoveValForm_X, MousePosition.Y - MoveValForm_Y);
            }
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ToFormMove = 1;
            MoveValForm_X = e.X;
            MoveValForm_Y = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ToFormMove = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
