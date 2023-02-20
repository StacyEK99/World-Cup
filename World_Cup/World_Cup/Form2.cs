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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataLayer datalayer = new DataLayer(@"LAPTOP-C230EKGM\SQLEXPRESS", "WORLD_CUP");
        DataTable dt, dtt, dd;

        private void button2_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = l.ToString();
            id += s[1].ToString();
            id = id.ToUpper();
            Form1 f1 = new Form1(id);
            f1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (datalayer.IsValid)
            {
                dt = datalayer.GetData("Select Team From team", " team");
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "team";
                comboBox1.ValueMember = "team";
                comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            }
        }
        string s;

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        char l;
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            s = datalayer.GetValue("select teamid from team where team.team='" + comboBox1.SelectedValue.ToString() + "'").ToString();
            l = s[0];
            dtt = datalayer.GetData("SELECT GAME.MATCH_DATE, GAME.TEAM1SCCORE, GAME.TEAM2SCORE, TEAM.TEAM as TEAM2 , STADIUM.SNAME as STADIUM_NAME FROM GAME  INNER JOIN STADIUM ON GAME.SID = STADIUM.SID INNER JOIN TEAM ON GAME.TEAMID2 = TEAM.TEAMID where GAME.GAMEID like '" + l + "__'", "game");
            dataGridView1.DataSource = dtt;
            dd = datalayer.GetData("select MATCH_DATE, TEAM1SCCORE, TEAM2SCORE, TEAM.TEAM as TEAM1, STADIUM.SNAME as STADIUM_NAME from GAME INNER JOIN STADIUM ON GAME.SID = STADIUM.SID inner join TEAM on GAME.TEAMID1 = TEAM.TEAMID where GAME.GAMEID like '_" + l + "_'", "game");
            dataGridView2.DataSource = dd;
        }
    }
}
