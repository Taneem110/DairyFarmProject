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
    public partial class CowHealth : Form
    {
        public CowHealth()
        {
            InitializeComponent();
            FillCowId();
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void FillCowId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select CowId from CowTable", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(rdr);
            cowidcb.ValueMember = "CowId";
            cowidcb.DataSource = dt;
            con.Close();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from CowHealthTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            healthDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void GetCowName()
        {
            con.Open();
            string query = "select * from CowTable where CowId = " + cowidcb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cownametb.Text = dr["CowName"].ToString();
            }
            con.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Breeding Ob = new Breeding();
            Ob.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            DashBoard Ob = new DashBoard();
            Ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Finance Ob = new Finance();
            Ob.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cowidcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void clear()
        {
            cownametb.Text = "";
            eventtb.Text = "";
            diagnosistb.Text = "";
            treatmenttb.Text = "";
            costtb.Text = "";
            vettb.Text = "";
            key = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cowidcb.SelectedIndex == -1 || cownametb.Text == "" || eventtb.Text == "" || diagnosistb.Text == "" || treatmenttb.Text == "" || costtb.Text == "" || vettb.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "insert into CowHealthTable values (" + cowidcb.SelectedValue.ToString() + ",'" + cownametb.Text + "','" + datedtp.Value.Date + "','" + eventtb.Text + "','" + diagnosistb.Text + "','" + treatmenttb.Text + "'," + costtb.Text + ",'" + vettb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Health Details Saved Successfully!");
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
        private void healthDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cowidcb.SelectedValue = healthDGV.SelectedRows[0].Cells[1].Value.ToString();
            cownametb.Text = healthDGV.SelectedRows[0].Cells[2].Value.ToString();
            datedtp.Text = healthDGV.SelectedRows[0].Cells[3].Value.ToString();
            eventtb.Text = healthDGV.SelectedRows[0].Cells[4].Value.ToString();
            diagnosistb.Text = healthDGV.SelectedRows[0].Cells[5].Value.ToString();
            treatmenttb.Text = healthDGV.SelectedRows[0].Cells[6].Value.ToString();
            costtb.Text = healthDGV.SelectedRows[0].Cells[7].Value.ToString();
            vettb.Text = healthDGV.SelectedRows[0].Cells[8].Value.ToString();
            if (cownametb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(healthDGV.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Health Details to delete!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "delete from CowHealthTable where ReportId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Health Details Deleted Successfully!");
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
            if (cowidcb.SelectedIndex == -1 || cownametb.Text == "" || eventtb.Text == "" || diagnosistb.Text == "" || treatmenttb.Text == "" || costtb.Text == "" || vettb.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "update CowHealthTable set CowName='" + cownametb.Text + "',ReportDate='" + datedtp.Value.Date + "',Event='" + eventtb.Text + "',Diagnosis='" + diagnosistb.Text + "',Treatment='" + treatmenttb.Text + "',Cost=" + costtb.Text + ",VetName='" + vettb.Text + "' where ReportId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Health Details Updated Successfully!");
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

        private void label6_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void cowidcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }
    }
}
