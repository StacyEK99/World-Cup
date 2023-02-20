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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        int c = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (c % 2 == 0)
            {
                textBox2.UseSystemPasswordChar = false;
                c++;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                c++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Username couldn't be null!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = textBox2.Text = "";
                textBox1.Focus();
            }
            else
            {


                if (textBox2.Text == "")
                {
                    MessageBox.Show("You haven't entred a password!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = textBox2.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    if (textBox1.Text != "user")
                    {
                        MessageBox.Show("Invalid Id!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (textBox2.Text != "0000")
                        {
                            MessageBox.Show("Invalid password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            welcome f = new welcome();
                            f.Show();
                            this.Close();
                        }
                    }

                    
                        }
                    }
                }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            open p = new open();
            p.Show();
            this.Hide();
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }
    }
    }

