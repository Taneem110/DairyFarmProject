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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DairyFarm
{
    public partial class MilkProduction : Form
    {
        public MilkProduction()
        {
            InitializeComponent();
            FillCowId();
            populate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
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

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
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

        private void label19_Click(object sender, EventArgs e)
        {
            DashBoard Ob = new DashBoard();
            Ob.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void FillCowId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select CowId from CowTable", con); 
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId",typeof(int));
            dt.Load(rdr);
            cowidcb.ValueMember = "CowId";
            cowidcb.DataSource =dt;
            con.Close();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from MilkTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MilkDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void clear()
        {
            cownametb.Text = "";
            amtb.Text = "";
            pmtb.Text = "";
            noontb.Text = "";
            totalmilktb.Text = "";
            key = 0;
        }
        private void GetCowName()
        {
            con.Open();
            string query = "select * from CowTable where CowId = "+cowidcb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach( DataRow dr in dt.Rows)
            {
                cownametb.Text = dr["CowName"].ToString();
            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cowidcb.SelectedIndex == -1 || cownametb.Text == "" || amtb.Text == "" || pmtb.Text == "" || noontb.Text == "" || totalmilktb.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "insert into MilkTable values ("+cowidcb.SelectedValue.ToString()+",'" + cownametb.Text + "'," + amtb.Text + "," + pmtb.Text + "," + noontb.Text + ","+ totalmilktb.Text + ",'" + datedtp.Value.Date + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Details Saved Successfully!");
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

        private void cowidcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void pmtb_MouseUp(object sender, MouseEventArgs e)
        {
            int total = Convert.ToInt32(amtb.Text) + Convert.ToInt32(pmtb.Text) + Convert.ToInt32(noontb.Text);
            totalmilktb.Text = "" + total;
        }

        private void pmtb_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pmtb_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pmtb_Leave(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(amtb.Text) + Convert.ToInt32(pmtb.Text) + Convert.ToInt32(noontb.Text);
            totalmilktb.Text =  ""+ total;

        }
        int key = 0;
        private void MilkDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cowidcb.SelectedValue = MilkDGV.SelectedRows[0].Cells[1].Value.ToString();
            cownametb.Text = MilkDGV.SelectedRows[0].Cells[2].Value.ToString();
            amtb.Text = MilkDGV.SelectedRows[0].Cells[3].Value.ToString();
            noontb.Text = MilkDGV.SelectedRows[0].Cells[4].Value.ToString();
            pmtb.Text = MilkDGV.SelectedRows[0].Cells[5].Value.ToString();
            totalmilktb.Text = MilkDGV.SelectedRows[0].Cells[6].Value.ToString();
            datedtp.Text= MilkDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (cownametb.Text == "")
            {
                key = 0;
               
            }
            else
            {
                key = Convert.ToInt32(MilkDGV.SelectedRows[0].Cells[0].Value.ToString());
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Milk Details to delete!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "delete from MilkTable where MilkId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Details Deleted Successfully!");
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
            if (cowidcb.SelectedIndex == -1 || cownametb.Text == "" || amtb.Text == "" || pmtb.Text == "" || noontb.Text == "" || totalmilktb.Text == "")
            { 
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "update MilkTable set CowName='" + cownametb.Text + "',AmMilk=" + amtb.Text + ",NoonMilk=" + noontb.Text + ",PmMilk=" + pmtb.Text + ",TotalMilk=" + totalmilktb.Text + ",Date_Milk='" + datedtp.Value.Date + "' where MilkId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Details Updated Successfully!");
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

        private void label4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
    }

