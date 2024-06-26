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
    public partial class Breeding : Form
    {
        public Breeding()
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
            string query = "select * from BreedTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BreedDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        string cowage;
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
                age.Text = dr["Age"].ToString();
            }
            con.Close();
        }
        private void clear()
        {
            cownametb.Text = "";
            age.Text = "";
            remarktb.Text = "";
            key = 0;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
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

        private void label16_Click(object sender, EventArgs e)
        {
            CowHealth Ob = new CowHealth();
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

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cowidcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cowidcb.SelectedIndex == -1 || cownametb.Text == "" || remarktb.Text == "" || age.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "insert into BreedTable values ('" + htdate.Value.Date + "','" + brdate.Value.Date + "'," + cowidcb.SelectedValue.ToString() + ",'" + cownametb.Text + "','" + prdate.Value.Date + "','" + Expdate.Value.Date + "','" + dateclv.Value.Date + "'," + age.Text + ",'" + remarktb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breeding Details Saved Successfully!");
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

        private void button3_Click(object sender, EventArgs e)
        {

            if (key == 0)
            {
                MessageBox.Show("Select the Breeding Details to delete!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "delete from BreedTable where BreedId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breed Details Deleted Successfully!");
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
        int key = 0;
        private void BreedDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            htdate.Text = BreedDGV.SelectedRows[0].Cells[1].Value.ToString();
            brdate.Text = BreedDGV.SelectedRows[0].Cells[2].Value.ToString();
            cowidcb.SelectedValue = BreedDGV.SelectedRows[0].Cells[3].Value.ToString();
            cownametb.Text = BreedDGV.SelectedRows[0].Cells[4].Value.ToString();
            prdate.Text = BreedDGV.SelectedRows[0].Cells[5].Value.ToString();
            Expdate.Text = BreedDGV.SelectedRows[0].Cells[6].Value.ToString();
            dateclv.Text = BreedDGV.SelectedRows[0].Cells[7].Value.ToString();
            age.Text = BreedDGV.SelectedRows[0].Cells[8].Value.ToString();
            remarktb.Text = BreedDGV.SelectedRows[0].Cells[9].Value.ToString();
            if (cownametb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(BreedDGV.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cowidcb.SelectedIndex == -1 || cownametb.Text == "" || remarktb.Text == "" || age.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "update BreedTable set HeatDate='" + htdate.Value.Date + "',BreedDate='" + brdate.Value.Date + "',CowName='" + cownametb.Text + "',PregDate='" + prdate.Value.Date + "',ExpectedDateCalve='" + Expdate.Value.Date + "',DateCalved='" + dateclv.Value.Date + "',CowAge=" + age.Text + ",Remarks='" + remarktb.Text + "' where BreedId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breed Details Updated Successfully!");
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

        private void label12_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
