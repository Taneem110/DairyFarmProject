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
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
            populateExp();
            Incpopulate();
            FillEmpId();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populateExp()
        {
            con.Open();
            string query = "select * from ExpenditureTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void Incpopulate()
        {
            con.Open();
            string query = "select * from ProfitTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void FilterInc()
        {
            con.Open();
            string query = "select * from ProfitTable where IncomeDate='"+ filterdtb.Value.Date+ "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void FilterExp()
        {
            con.Open();
            string query = "select * from ExpenditureTable where ExpenditureDate='" + filterexpdtp.Value.Date + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void FillEmpId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select EmpId from EmployeeTable", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Load(rdr);
            empidcb.ValueMember = "EmpId";
            empidcb.DataSource = dt;
            con.Close();
        }
        private void clearExp()
        {
            purposecb.SelectedIndex = -1;
            spamttb.Text = "";
        }
        private void clearInc()
        {
            typecb.SelectedIndex = -1;
            inctb.Text = "";
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
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

        private void label16_Click(object sender, EventArgs e)
        {
            CowHealth Ob = new CowHealth();
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (purposecb.SelectedIndex == -1 || spamttb.Text == "" || empidcb.SelectedIndex==-1)
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "insert into ExpenditureTable values ('" + ExpDatedtp.Value.Date + "','" + purposecb.SelectedItem.ToString() + "'," + spamttb.Text + "," + empidcb.SelectedValue.ToString()+ ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expenditure Details Saved Successfully!");
                    con.Close();
                    populateExp();
                    clearExp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (typecb.SelectedIndex == -1 || inctb.Text == "" || empidcb.SelectedIndex==-1)
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "insert into ProfitTable values ('" + incdatedtp.Value.Date + "','" + typecb.SelectedItem.ToString() + "'," + inctb.Text + "," + empidcb.SelectedValue.ToString() + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Details Saved Successfully!");
                    con.Close();
                    Incpopulate();
                    clearInc();
                   }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void filterdtb_ValueChanged(object sender, EventArgs e)
        {
            FilterInc();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Incpopulate();
        }

        private void filterexpdtp_ValueChanged(object sender, EventArgs e)
        {
            FilterExp();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            populateExp();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Normal;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
