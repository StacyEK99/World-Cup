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
    public partial class Form1 : Form
    {
        public Form1( string id)
        {
            InitializeComponent();
            i = id;
        }
        string i;
        DataLayer datalayer = new DataLayer(@"LAPTOP-C230EKGM\SQLEXPRESS", "world_cup");
        DataTable dtt;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(i);
            f3.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (datalayer.IsValid)
            {
                label2.Text = datalayer.GetValue("select TEAM FROM TEAM where TEAMID='" + i + "'").ToString();
                dtt = datalayer.GetData("SELECT PLAYER.FIFA_Popular_Name, PLAYER.PlayerID as NUMBER, PLAYER.Shirt_Name, PLAYER.Position FROM PLAYER INNER JOIN TEAM ON PLAYER.TEAMID = TEAM.TEAMID where TEAM.TEAMID ='" + i + "'ORDER BY PLAYER.PlayerID", "TEAM");
                dataGridView1.DataSource = dtt;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
