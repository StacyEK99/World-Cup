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
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            team t = new team();
            t.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player p = new player();
            p.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game g = new game();
            g.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cards c = new cards();
            c.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            substitutions s = new substitutions();
            s.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            starting_lineup ss = new starting_lineup();
            ss.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            stadium q = new stadium();
            q.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            own_goals o = new own_goals();
            o.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            goals gg = new goals();
            gg.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            login f = new login();
            f.Show();
            this.Hide();
        }

        private void welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }
    }
}
