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
    public partial class MilkSales : Form
    {
        public MilkSales()
        {
            InitializeComponent();
            populate();
            FillEmpId();    
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void populate()
        {
            con.Open();
            string query = "select * from MilkSalesTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SalesDGV.DataSource = ds.Tables[0];
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
        private void clear()
        {
            pricetb.Text = "";
            cnametb.Text = "";
            cphonetb.Text = "";
            empidcb.SelectedIndex = -1;
            qtytb.Text = "";
            totalpricetb.Text = "";
   
        }
        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void MilkSales_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            
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

        private void label15_Click(object sender, EventArgs e)
        {
            Breeding Ob = new Breeding();
            Ob.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            CowHealth Ob = new CowHealth();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void SaveTransaction()
        {

            {

                try
                {
                    string Sales = "Sales";
                    con.Open();
                    string query = "insert into ProfitTable values ('" + datedtp.Value.Date + "','" +Sales + "'," + totalpricetb.Text + "," + empidcb.SelectedValue.ToString() + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Details Saved Successfully!");
                    con.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (empidcb.SelectedIndex == -1 || cnametb.Text == "" || pricetb.Text == "" || cphonetb.Text == "" || qtytb.Text == "" || totalpricetb.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "insert into MilkSalesTable values ('" + datedtp.Value.Date + "'," + pricetb.Text + ",'" + cnametb.Text + "','" + cphonetb.Text + "'," + empidcb.SelectedValue.ToString() + "," + qtytb.Text + ","+totalpricetb.Text+")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Sales Details Saved Successfully!");
                    con.Close();
                    populate();
                    SaveTransaction();
                    clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            }

        private void datedtp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void qtytb_Leave(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(pricetb.Text) * Convert.ToInt32(qtytb.Text) ;
            totalpricetb.Text = "" + total;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
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
            this.WindowState=FormWindowState.Normal;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
