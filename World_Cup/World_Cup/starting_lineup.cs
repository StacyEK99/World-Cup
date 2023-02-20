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
    public partial class starting_lineup : Form
    {
        public starting_lineup()
        {
            InitializeComponent();
        }
        DataLayer datalayer;
        private void starting_lineup_Load(object sender, EventArgs e)
        {
            datalayer = new DataLayer(@"LAPTOP-C230EKGM\SQLEXPRESS", "world_cup");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("something is empty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string req = "Insert into starting_lineup values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                datalayer.SqlComExec(req);
                textBox1.Text = textBox2.Text = textBox3.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            welcome w = new welcome();
            w.Show();
            this.Hide();
        }

        private void starting_lineup_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }
    }
}
