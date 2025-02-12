using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BloodManagement
{
    public partial class Donor : Form
    {
        public Donor()
        {
            InitializeComponent();
        }

        private void Donor_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from donortab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into donortab values(@donorid,@donorname,@gender,@address,@phone)", con);
            cmd.Parameters.AddWithValue("@DonorID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@DonorName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", textBox3.Text);
            cmd.Parameters.AddWithValue("@Address", textBox4.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update donortab set donorname=@donorname,gender=@gender,address=@address,phone=@phone where donorid=@donorid", con);
            cmd.Parameters.AddWithValue("@DonorID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@DonorName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", textBox3.Text);
            cmd.Parameters.AddWithValue("@Address", textBox4.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete donortab where donorid=@donorid", con);
            cmd.Parameters.AddWithValue("@DonorID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully");
        }
    }
}
