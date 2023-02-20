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
    public partial class player : Form
    {
        public player()
        {
            InitializeComponent();
        }
        DataLayer datalayer;
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") || (textBox8.Text == "") || (textBox9.Text == "") || (textBox10.Text == ""))
            {
                MessageBox.Show("something is empty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string req = "Insert into player values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text +  "','" +textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" +textBox7.Text + "','"+ textBox8.Text + "','"+ textBox9.Text + "','"+textBox10.Text + "')";
                datalayer.SqlComExec(req);
                textBox1.Text = textBox10.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = "";
            }
        }

        private void player_Load(object sender, EventArgs e)
        {
            datalayer = new DataLayer(@"LAPTOP-C230EKGM\SQLEXPRESS", "world_cup");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            welcome w = new welcome();
            w.Show();
            this.Hide();
        }

        private void player_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  Application.Exit();
        }
    }
}
