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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            standing s = new standing();
            s.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            matchStats m = new matchStats();
            m.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            open p = new open();
            p.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            player2 p = new player2();
            p.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stadium2 s = new Stadium2();
            s.Show();
            this.Hide();
        }

        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }
    }
}
