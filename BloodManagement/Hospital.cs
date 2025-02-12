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
    public partial class Hospital : Form
    {
        public Hospital()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into hospitaltab values(@hospitalid,@name,@address,@email)", con);
            cmd.Parameters.AddWithValue("@HospitalID",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully");



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("update hospitaltab set name=@name,address=@address,email=@email where hospitalid=@hospitalid", con);
            cmd.Parameters.AddWithValue("@HospitalID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete hospitaltab where hospitalid=@hospitalid", con);
            cmd.Parameters.AddWithValue("@HospitalID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully");
        }

        private void Hospital_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from hospitaltab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            da.Fill(dt);    
            dataGridView1.DataSource = dt;  
        }
    }
}
