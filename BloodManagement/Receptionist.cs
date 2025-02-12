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
    public partial class Receptionist : Form
    {
        public Receptionist()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into receptab values(@rid,@name,@address,@phone)", con);
            cmd.Parameters.AddWithValue("@RID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update receptab set name=@name,address=@address,phone=@phone where rid=@rid", con);
            cmd.Parameters.AddWithValue("@RID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete  receptab where rid=@rid", con);
            cmd.Parameters.AddWithValue("@RID", int.Parse(textBox1.Text));
            
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully");
        }

        private void Receptionist_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from receptab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
