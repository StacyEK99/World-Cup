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
    public partial class game : Form
    {
        public game()
        {
            InitializeComponent();
        }
        DataLayer datalayer;
        private void game_Load(object sender, EventArgs e)
        {
            datalayer = new DataLayer(@"LAPTOP-C230EKGM\SQLEXPRESS", "world_cup");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") || (textBox8.Text == ""))
            {
                MessageBox.Show("something is empty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string req = "Insert into game values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";
                datalayer.SqlComExec(req);
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            welcome w = new welcome();
            w.Show();
            this.Hide();
        }

        private void game_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }
    }
}
