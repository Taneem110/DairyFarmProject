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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            Finance();
            Logistics();
            getMax();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
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

        private void label17_Click(object sender, EventArgs e)
        {
            Finance Ob = new Finance();
            Ob.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void Finance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(IncomeAmount) from ProfitTable",con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(ExpenditureAmount) from ExpenditureTable", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int inc;int exp;
            double bal;
            inc = Convert.ToInt32(dt.Rows[0][0].ToString());
            incamt.Text = "Rs. "+dt.Rows[0][0].ToString();
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            exp = Convert.ToInt32(dt1.Rows[0][0].ToString());
            bal = inc - exp;
            ExpRs.Text = "Rs. "+dt1.Rows[0][0].ToString();
            Bal.Text = "Rs. " + bal;
            con.Close();
        }

        private void Logistics()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from CowTable", con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(TotalMilk) from MilkTable", con);
            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from EmployeeTable", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cowcnt.Text = dt.Rows[0][0].ToString();
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            milkcnt.Text = dt.Rows[0][0].ToString()+" Litres";
            DataTable dt3 = new DataTable();
            sda2.Fill(dt3);
            empcnt.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void getMax()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select max(IncomeAmount) from ProfitTable",con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select max(ExpenditureAmount) from ExpenditureTable", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            maxamt.Text = dt.Rows[0][0].ToString();
            maxexp.Text= dt1.Rows[0][0].ToString();
            con.Close() ;


        }

        private void Bal_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

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

        private void label12_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void incamt_Click(object sender, EventArgs e)
        {

        }
    }
}
