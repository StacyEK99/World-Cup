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
    public partial class matchStats : Form
    {
        DataLayer dl;
        public matchStats()
        {
            InitializeComponent();
            dl = new DataLayer(@"laptop-c230ekgm\sqlexpress", "WORLD_CUP");
        }

        string id;
        DataTable dt;
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel6.Hide();
            panel7.Hide();

            if (dl.IsValid)
            {
                dt = dl.GetData("select GAMEID from GAME", "GAME");
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "GAMEID";
                comboBox1.ValueMember = "GAMEID";
                comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;              
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            panel6.Hide();
            panel7.Hide();
            id = comboBox1.SelectedValue.ToString();

            string t1 = dl.GetValue("select TEAMID1 from GAME where GAMEID='" + id + "'").ToString();
            string t2 = dl.GetValue("select TEAMID2 from GAME where GAMEID='" + id + "'").ToString();

            label1.Text = (dl.GetValue("select TEAM from TEAM where TEAMID ='"+t1+"'").ToString());
            label2.Text = (dl.GetValue("select TEAM from TEAM where TEAMID ='"+t2+"'").ToString());

            label5.Text = (dl.GetValue("select TEAM1SCCORE from GAME where GAMEID='" + id + "'").ToString());
            label6.Text = (dl.GetValue("select TEAM2SCORE from GAME where GAMEID='" + id + "'").ToString());

            DataTable sl1 = dl.GetData("SELECT PLAYER.Shirt_Name, PLAYER.Position, PLAYER.PlayerID as NUMBER FROM PLAYER INNER JOIN STARTING_LINEUP ON STARTING_LINEUP.PlayerID = PLAYER.PlayerID AND STARTING_LINEUP.TEAMID = PLAYER.TEAMID where STARTING_LINEUP.GAMEID = '" + id + "' and STARTING_LINEUP.TEAMID = '"+t1+"'", "PLAYER");
            DataTable sl2 = dl.GetData("SELECT PLAYER.Shirt_Name, PLAYER.Position, PLAYER.PlayerID as NUMBER FROM PLAYER INNER JOIN STARTING_LINEUP ON STARTING_LINEUP.PlayerID = PLAYER.PlayerID AND STARTING_LINEUP.TEAMID = PLAYER.TEAMID where STARTING_LINEUP.GAMEID = '" + id + "' and STARTING_LINEUP.TEAMID = '"+t2+"'", "PLAYER");
            dataGridView1.DataSource = sl1;
            dataGridView2.DataSource = sl2;

            DataTable sub11 = dl.GetData("SELECT PLAYER.Shirt_Name, PLAYER.PlayerID as NUMBER, PLAYER.Position,  SUBSTITUTIONS.TIME_of_sub as SUB_TIME FROM PLAYER INNER JOIN SUBSTITUTIONS ON SUBSTITUTIONS.Replace_player_ID = PLAYER.PlayerID AND SUBSTITUTIONS.TEAMID = PLAYER.TEAMID where SUBSTITUTIONS.GAMEID = '" + id + "' and SUBSTITUTIONS.TEAMID = '"+t1+"'", "PLAYER");
            DataTable sub21 = dl.GetData("SELECT PLAYER.Shirt_Name, PLAYER.PlayerID as NUMBER, PLAYER.Position,  SUBSTITUTIONS.TIME_of_sub as SUB_TIME FROM PLAYER INNER JOIN SUBSTITUTIONS ON SUBSTITUTIONS.Replace_player_ID = PLAYER.PlayerID AND SUBSTITUTIONS.TEAMID = PLAYER.TEAMID where SUBSTITUTIONS.GAMEID = '" + id + "' and SUBSTITUTIONS.TEAMID = '"+t2+"'", "PLAYER");
            DataTable sub12 = dl.GetData("SELECT PLAYER.Shirt_Name, PLAYER.PlayerID as NUMBER FROM PLAYER INNER JOIN SUBSTITUTIONS ON SUBSTITUTIONS.Substitute_player_ID = PLAYER.PlayerID AND SUBSTITUTIONS.TEAMID = PLAYER.TEAMID where SUBSTITUTIONS.GAMEID = '" + id + "' and SUBSTITUTIONS.TEAMID = '"+t1+"'", "PLAYER");
            DataTable sub22 = dl.GetData("SELECT PLAYER.Shirt_Name, PLAYER.PlayerID as NUMBER FROM PLAYER INNER JOIN SUBSTITUTIONS ON SUBSTITUTIONS.Substitute_player_ID = PLAYER.PlayerID AND SUBSTITUTIONS.TEAMID = PLAYER.TEAMID where SUBSTITUTIONS.GAMEID = '" + id + "' and SUBSTITUTIONS.TEAMID = '"+t2+"'", "PLAYER");
            dataGridView3.DataSource = sub11;
            dataGridView4.DataSource = sub12;
            dataGridView5.DataSource = sub21;
            dataGridView6.DataSource = sub22;
            if (sub11.Rows.Count == 0)
                panel6.Show();
            if (sub21.Rows.Count == 0)
                panel7.Show();

            DataTable goals = dl.GetData("SELECT GOALS.TIME_of_goal, GOALS.Penalty, PLAYER.Shirt_Name, PLAYER.PlayerID as NUMBER, PLAYER.Position, TEAM.TEAM FROM GOALS  INNER JOIN PLAYER ON GOALS.PlayerID = PLAYER.PlayerID INNER JOIN TEAM ON GOALS.TEAMID = TEAM.TEAMID AND PLAYER.TEAMID = TEAM.TEAMID where GOALS.GAMEID = '" + id + "' order by TIME_of_goal", "GOALS");
            dataGridView7.DataSource = goals;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            label11.Text = dl.GetValue("select MATCH_DATE from GAME where GAMEID='"+id+"'").ToString();
            label12.Text = dl.GetValue("select STADIUM.SNAME as STADIUM from GAME inner join STADIUM on STADIUM.SID= GAME.SID where GAMEID='" + id + "'").ToString();
            label13.Text = dl.GetValue("select MATCH_TYPE from GAME where GAMEID='" + id + "'").ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel4.Hide();
            DataTable cards = dl.GetData("SELECT CARDS.Time_of_card, PLAYER.Shirt_Name, PLAYER.PlayerID, PLAYER.Position, CARDS.Color_Card, TEAM.TEAM FROM CARDS  INNER JOIN PLAYER ON CARDS.PlayerID = PLAYER.PlayerID INNER JOIN TEAM ON CARDS.TEAMID = TEAM.TEAMID AND PLAYER.TEAMID = TEAM.TEAMID where CARDS.GAMEID = '"+id+"' order by Time_of_card", "CARDS");
            if (cards.Rows.Count == 0)
                panel4.Show();
            dataGridView8.DataSource = cards;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel5.Hide();
            DataTable og = dl.GetData("SELECT OWN_GOALS.Time_of_og, PLAYER.Shirt_Name, PLAYER.PlayerID as NUMBER, PLAYER.Position, TEAM.TEAM FROM OWN_GOALS INNER JOIN PLAYER ON OWN_GOALS.PlayerID = PLAYER.PlayerID INNER JOIN TEAM ON OWN_GOALS.TEAMID = TEAM.TEAMID AND PLAYER.TEAMID = TEAM.TEAMID where OWN_GOALS.GAMEID = '" + id + "' ORDER BY Time_of_og", "OWN_GOALS");
            if (og.Rows.Count == 0)
                panel5.Show();
            dataGridView9.DataSource = og;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            this.Hide();
        }

        private void matchStats_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  Application.Exit();
        }
    }
}
