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
    public partial class Form3 : Form
    {
        public Form3(string tid)
        {
            InitializeComponent();
            id = tid;
        }
        string id;
        DataLayer datalayer = new DataLayer(@"LAPTOP-C230EKGM\SQLEXPRESS", "world_cup");
        DataTable dt, dtt;
        private void Form3_Load(object sender, EventArgs e)
        {
            dt = datalayer.GetData("Select FIFA_Popular_Name From PLAYER where TEAMID='"+id+"'", " PLAYER");
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "FIFA_Popular_Name";
            comboBox1.ValueMember = "FIFA_Popular_Name";
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(id);
            f.Show();
            this.Hide();
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s =int.Parse(datalayer.GetValue("select playerid from player where FIFA_Popular_Name='" + comboBox1.SelectedValue.ToString()+"'").ToString());
            dtt = datalayer.GetData("SELECT  TEAM, FIFA_Popular_Name, Shirt_Name, Club, Position, BirthDate, Height, Weight, PlayerID AS NUMBER FROM   PLAYER where player.playerid='"+s+ "' and TEAMID='"+id+"'", "player");
            dataGridView1.DataSource = dtt;
            int a = int.Parse(datalayer.GetValue("select count(GAMEID) from GOALS where PlayerID ='" + s+"' and TEAMID='" + id+"'").ToString());
            textBox1.Text = a.ToString();
            int b = int.Parse(datalayer.GetValue("select count(GAMEID) from OWN_GOALS where PlayerID ='" + s+"' and TEAMID='" + id+"'").ToString());
            textBox2.Text = b.ToString();
            int c = int.Parse(datalayer.GetValue("select count(GAMEID) from CARDS where PlayerID = '"+s+"' and  Color_Card='YELLOW' and TEAMID='" + id+"'").ToString());
            textBox3.Text = c.ToString();
            int d = int.Parse(datalayer.GetValue("select count(GAMEID) from CARDS where PlayerID ='"+s+ "' and Color_Card='RED'and TEAMID = '"+id+"'").ToString());
            textBox4.Text = d.ToString();
            int g1= int.Parse(datalayer.GetValue("select count(GAMEID) from STARTING_LINEUP where PlayerID='"+s+ "' and TEAMID='" + id+"'").ToString());
            int g2 = int.Parse(datalayer.GetValue("select count(GAMEID) from SUBSTITUTIONS where Substitute_Player_ID='" + s+ "' and TEAMID='" + id+"'").ToString());
            int g = g1 + g2;
            textBox5.Text = g.ToString();
            
        }
    }
}
