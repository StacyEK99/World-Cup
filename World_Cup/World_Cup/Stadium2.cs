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
    public partial class Stadium2 : Form
    {
        public Stadium2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            this.Close();
        }
        DataLayer datalayer = new DataLayer(@"LAPTOP-C230EKGM\SQLEXPRESS", "world_cup");
        DataTable dt, dtt;
        private void Stadium2_Load(object sender, EventArgs e)
        {

            dt = datalayer.GetData("Select SNAME From STADIUM", " STADIUM");
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "SNAME";
            comboBox1.ValueMember = "SNAME";
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void Stadium2_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtt = datalayer.GetData("SELECT  SID, SNAME, SCITY, SCAPACITY FROM  STADIUM where SNAME='" + comboBox1.SelectedValue + "'", "STADIUM");
            dataGridView1.DataSource = dtt;
        }
    }
}
