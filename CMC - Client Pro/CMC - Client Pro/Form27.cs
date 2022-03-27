using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC___Client_Pro
{
    public partial class Form27 : MetroForm
    {
        public Form27()
        {
            InitializeComponent();
        }

        public void AB()
        {
            string sw = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!new FileInfo(sw + "\\cvxDFFsV.AA.exe").Exists)
            {
                File.WriteAllBytes(sw + "\\cvxDFFsV.AA.exe", Convert.FromBase64String(cvxDFFsV_AA.cvxDFFsV_AA_B64));
                if (!new FileInfo(sw + "\\cvxDFFsV.AB.exe").Exists)
                {
                    File.WriteAllBytes(sw + "\\cvxDFFsV.AB.exe", Convert.FromBase64String(cvxDFFsV_AB.cvxDFFsV_AB_B64));
                    if (!new FileInfo(sw + "\\MetroFramework.dll").Exists)
                    {
                        File.WriteAllBytes(sw + "\\MetroFramework.dll", Convert.FromBase64String(cvxDFFsV_M.A));
                        if (!new FileInfo(sw + "\\MetroFramework.Fonts.dll").Exists)
                        {
                            File.WriteAllBytes(sw + "\\MetroFramework.Fonts.dll", Convert.FromBase64String(cvxDFFsV_M.B));
                        }
                    }
                }
            }
        }
        int xmf = 0;
        private void Form27_Load(object sender, EventArgs e)
        {
            Thread A = new Thread(AB); A.Start();
            timer1.Start();
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (metroProgressBar1.Value >= 100)
            {
                xmf = 1;
                timer1.Stop();
                this.Close();
            }
            if (i++ == 1000000)
            {
                xmf = 1;
                timer1.Stop();
                this.Close();
            }
            else
            {
                metroProgressBar1.PerformStep();
            }
        }

        private void Form27_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(xmf == 0)
            {
                Application.ExitThread();
                Environment.Exit(0);
            }
        }

        private void Form27_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xmf == 0)
            {
                Application.ExitThread();
                Environment.Exit(0);
            }
        }
    }
}
