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
using System.Windows.Forms.Design;

namespace DairyFarm
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void populate()
        {
            con.Open();
            string query = "select * from EmployeeTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void clear()
        {
            phonetb.Text = "";
            nametb.Text = "";
            gencb.SelectedIndex = -1;
            addrtb.Text = "";
            pwd.Text = "";
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void datedtp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cowidcb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cownametb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nametb.Text == "" || gencb.SelectedIndex == -1 || phonetb.Text == "" || addrtb.Text == "" || pwd.Text=="")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "insert into EmployeeTable values ('" + nametb.Text + "','" + dobdtp.Value.Date + "','" + gencb.SelectedItem.ToString() + "','" + phonetb.Text + "','" + addrtb.Text + "','"+pwd.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Details Saved Successfully!");
                    con.Close();
                    populate();
                    clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
        int key = 0;
        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            nametb.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
            dobdtp.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
            gencb.SelectedItem = EmpDGV.SelectedRows[0].Cells[3].Value.ToString();
            phonetb.Text = EmpDGV.SelectedRows[0].Cells[4].Value.ToString();
            addrtb.Text = EmpDGV.SelectedRows[0].Cells[5].Value.ToString();
            pwd.Text = EmpDGV.SelectedRows[0].Cells[6].Value.ToString();

            if (nametb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(EmpDGV.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Employee to delete!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "delete from EmployeeTable where EmpId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Details Deleted Successfully!");
                    con.Close();
                    populate();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nametb.Text == "" || gencb.SelectedIndex == -1 || phonetb.Text == "" || addrtb.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "update EmployeeTable set EmpName='" + nametb.Text + "',EmpDob='" + dobdtp.Value.Date + "',Gender='" + gencb.SelectedItem.ToString() + "',Phone='" + phonetb.Text + "',Address='" + addrtb.Text + "',EmpPass='"+pwd.Text+"' where EmpId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Details Updated Successfully!");
                    con.Close();
                    populate();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Normal;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
           
        }
    }
}
