using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace World_Cup
{
    public partial class standing : Form
    {
        public string SqlComExec(string s)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C230EKGM\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
            SqlCommand com = new SqlCommand(s, con);
            con.Open();
            int rep = com.ExecuteNonQuery();
            con.Close();
            return rep.ToString();
        }
        DataLayer datalayer;
        public standing()
        {
            InitializeComponent();
            datalayer = new DataLayer(@"laptop-c230ekgm\sqlexpress", "WORLD_CUP");
        }

        DataTable goalsagainst1, goalsagainst2,stand, ogfor, gfor;

        private void standing_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (datalayer.IsValid)
            {
                stand = datalayer.GetData("select TEAM from TEAM", "TEAM");
                Standing(ref stand);

                gfor = datalayer.GetData("select * from GOALS_PER_TEAM", "GOALS_PER_TEAM");
                ogfor = datalayer.GetData("select * from OG_FOR_TEAM", "OG_FOR_TEAM");
                goalsagainst1 = datalayer.GetData("select * from GOALS_HOME", "GOALS_HOME");
                goalsagainst2 = datalayer.GetData("select * from GOALS_AWAY", "GOALS_AWAY");
                
                DataColumn g = new DataColumn("GOALS_FOR", typeof(int));
                DataColumn ga = new DataColumn("GOALS_AGAINST", typeof(int));
                stand.Columns.Add(g);
                stand.Columns.Add(ga);

                for (int i = 0; i < gfor.Rows.Count; i++)
                {
                    int goal = 0;
                    goal = int.Parse(gfor.Rows[i][1].ToString());
                    for (int j = 0; j < ogfor.Rows.Count; j++)
                    {
                        if (ogfor.Rows[j][0].ToString() == gfor.Rows[i][0].ToString())
                            goal += int.Parse(ogfor.Rows[j][1].ToString());
                    }
                    stand.Rows[i][6] = goal;
                }

                for (int i = 0; i < stand.Rows.Count; i++)
                {
                    int goala = 0;                    
                    for (int j = 0; j < goalsagainst1.Rows.Count; j++)
                    {
                        if (goalsagainst1.Rows[j][0].ToString() == stand.Rows[i][0].ToString())
                            goala += int.Parse(goalsagainst1.Rows[j][1].ToString());
                    }
                    for (int k = 0; k < goalsagainst2.Rows.Count; k++)
                    {
                        if (goalsagainst2.Rows[k][0].ToString() == stand.Rows[i][0].ToString())
                            goala += int.Parse(goalsagainst2.Rows[k][1].ToString());
                    }
                    stand.Rows[i][7] = goala;
                }

                dataGridView1.DataSource = stand;
            }
        }

        public void Standing(ref DataTable dt)
        {
            int pt, gw, gl, gt,gp;
            int sc11, sc12, sc21, sc22;

            DataColumn pts = new DataColumn("POINTS", typeof(int));
            DataColumn gamespl = new DataColumn("GAMES_PLAYED", typeof(int));
            DataColumn gamew = new DataColumn("GAMES_WON", typeof(int));
            DataColumn gamet = new DataColumn("GAMES_TIED", typeof(int));
            DataColumn gamel = new DataColumn("GAMES_LOST", typeof(int));

            dt.Columns.Add(pts);
            dt.Columns.Add(gamespl);
            dt.Columns.Add(gamew);
            dt.Columns.Add(gamet);
            dt.Columns.Add(gamel);

            DataTable teams = datalayer.GetData("select TEAMID from TEAM", "TEAM");

            for (int i = 0; i < teams.Rows.Count; i++)
            {
                pt = gw = gl = gt = gp = 0;


                DataTable score11 =datalayer.GetData("select TEAM1SCCORE FROM WORLD_CUP.dbo.GAME where TEAMID1 ='" + teams.Rows[i][0] + "'","GAME");
                DataTable score12 = datalayer.GetData("select TEAM2SCORE from WORLD_CUP.dbo.GAME where TEAMID1 ='" + teams.Rows[i][0] + "'", "GAME");
                DataTable score21 = datalayer.GetData("select TEAM2SCORE FROM WORLD_CUP.dbo.GAME WHERE TEAMID2 = '" + teams.Rows[i][0] + "'", "GAME");
                DataTable score22 = datalayer.GetData(" SELECT TEAM1SCCORE FROM WORLD_CUP.dbo.GAME WHERE TEAMID2 = '" + teams.Rows[i][0] + "'", "GAME");

                //try to make a table of scores in case a team played more than 1 game

                if (score11.Rows.Count!=0)
                    sc11 = int.Parse(score11.Rows[0][0].ToString());
                else
                    sc11 = -1;
                if (score12.Rows.Count!=0)
                    sc12 = int.Parse(score12.Rows[0][0].ToString());
                else
                    sc12 = -1;
                if (score21.Rows.Count!=0)
                    sc21 = int.Parse(score21.Rows[0][0].ToString());
                else sc21 = -1;
                if (score22.Rows.Count!=0)
                    sc22 = int.Parse(score22.Rows[0][0].ToString());
                else sc22 = -1;

                if ((sc11 != -1) && (sc12 != -1))
                {
                    if (sc11 > sc12)
                    {
                        pt += 3;
                        gw++;
                        gp++;
                    }
                    else {
                        if (sc11 == sc12)
                        {
                            pt += 1;
                            gp++;
                            gt++;
                        }
                        else {
                            gl++;
                            gp++;
                        }
                    }
                }
                if ((sc21 != -1) && (sc22 != -1))
                {
                    if (sc21 > sc22)
                    {
                        pt += 3;
                        gw++;
                        gp++;
                    }
                    else {
                        if (sc21 == sc22)
                        {
                            pt += 1;
                            gt++;
                            gp++;
                        }
                        else {
                            gl++;
                            gp++;
                        }
                    }
                }
                dt.Rows[i][1] = pt;
                dt.Rows[i][2] = gp;
                dt.Rows[i][3] = gw;
                dt.Rows[i][4] = gt;
                dt.Rows[i][5] = gl;
            }
        }
    }
}
