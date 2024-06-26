using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DairyFarm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            un.Text = "";
            pwd.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pwd.Text == "" || un.Text == "")
            {
                MessageBox.Show("Enter Username and Passsword!");
            }
            else {
                if (rolecb.SelectedIndex > -1)
                {
                    if ((rolecb.SelectedItem.ToString() == "Admin"))
                    {
                        if (un.Text == "Admin" && pwd.Text == "Admin123")
                        {
                            Employee emp = new Employee();
                            this.Hide();
                            emp.Show();
                        }
                        else
                        {
                            MessageBox.Show("If you are admin,Enter correct username and password!");
                        }

                    }
                    else
                    {
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("select count(*) from EmployeeTable where EmpName='" + un.Text + "' and EmpPass='" + pwd.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Cows c = new Cows();
                            c.Show();
                            this.Hide();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username and Password!");
                        }
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select a Role!");
                }

            }

        }
        private void pwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
    }

        
    }

