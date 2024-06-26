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
    public partial class Cows : Form
    {
        public Cows()
        {
            InitializeComponent();
            populate();
            
            
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tejas\OneDrive\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CowNameTb.Text == "" || EartagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" || AgeTb.Text == "" || WeightTb.Text == "" || PastureTb.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "update CowTable set CowName='" + CowNameTb.Text + "',EarTag='" + EartagTb.Text + "',Color='" + ColorTb.Text + "',Breed='" + BreedTb.Text + "',Age=" + age + ",WeightAtBirth=" + WeightTb.Text + ",Pasture='" + PastureTb.Text + "' where CowId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Details Updated Successfully!");
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cows_Load(object sender, EventArgs e)
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

        private void label18_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            
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
        private void populate()
        {
            con.Open();
            string query = "select * from CowTable";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CowDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void clear()
        {
            CowNameTb.Text = "";
            EartagTb.Text = "";
            ColorTb.Text = "";
            BreedTb.Text = "";
            AgeTb.Text = "";
            WeightTb.Text = "";
            PastureTb.Text = "";
            key = 0;
        }
        int age = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if(CowNameTb.Text=="" || EartagTb.Text=="" ||ColorTb.Text=="" ||BreedTb.Text==""||AgeTb.Text==""||WeightTb.Text==""||PastureTb.Text=="")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "insert into CowTable values ('"+CowNameTb.Text+"','"+EartagTb.Text+"','"+ColorTb.Text+"','"+BreedTb.Text+"',"+age+",'"+WeightTb.Text+"','"+PastureTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Details Saved Successfully!");
                    con.Close();
                    populate();
                    clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void DobDate_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DobDate.Value.Date).Days) / 365;
        }
        private void DobDate_MouseLeave(object sender, EventArgs e)
        {
            age =  Convert.ToInt32((DateTime.Today.Date - DobDate.Value.Date).Days)/365;
            AgeTb.Text = "" +age;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        int key = 0;
        private void CowDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowNameTb.Text = CowDGV.SelectedRows[0].Cells[1].Value.ToString();
            EartagTb.Text = CowDGV.SelectedRows[0].Cells[2].Value.ToString();
            ColorTb.Text = CowDGV.SelectedRows[0].Cells[3].Value.ToString();
            BreedTb.Text = CowDGV.SelectedRows[0].Cells[4].Value.ToString();
            WeightTb.Text = CowDGV.SelectedRows[0].Cells[6].Value.ToString();
            PastureTb.Text = CowDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key= 0;
                age= 0;
            }
            else
            {
                key = Convert.ToInt32(CowDGV.SelectedRows[0].Cells[0].Value.ToString());
                age = Convert.ToInt32(CowDGV.SelectedRows[0].Cells[5].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Select the Cow to delete!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "delete from CowTable where CowId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Details Deleted Successfully!");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
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
        private void SearchCow()
        {
            con.Open();
            string query = "select * from CowTable where CowName like '%"+cowsearch.Text+"%'";
            SqlDataAdapter adapter = new SqlDataAdapter(query,con);
            SqlCommandBuilder s1 = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            CowDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void cowsearch_TextChanged(object sender, EventArgs e)
        {
            SearchCow();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
