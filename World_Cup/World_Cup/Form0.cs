using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace World_Cup
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = @"video\VID-20200715-WA0174.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            open o = new open();
            o.Show();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            this.Hide();
        }
    }
}
