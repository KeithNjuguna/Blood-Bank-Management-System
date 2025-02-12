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
    public partial class Blood : Form
    {
        public Blood()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into bloodtab values(@bloodcode,@donorname,@bloodamount,@donatedate,@bloodtype)", con);
            cmd.Parameters.AddWithValue("@BloodCode", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@DonorName", textBox2.Text);
            cmd.Parameters.AddWithValue("@BloodAmount", textBox3.Text);
            cmd.Parameters.AddWithValue("@DonateDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@BloodType", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update bloodtab set donorname=@donorname,bloodamount=@bloodamount,donatedate=@donatedate,bloodtype=@bloodtype where bloodcode=@bloodcode)", con);
            cmd.Parameters.AddWithValue("@BloodCode", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@DonorName", textBox2.Text);
            cmd.Parameters.AddWithValue("@BloodAmount", textBox3.Text);
            cmd.Parameters.AddWithValue("@DonateDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@BloodType", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete bloodtab where bloodcode=@bloodcode", con);
            cmd.Parameters.AddWithValue("@BloodCode", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully");
        }

        private void Blood_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from bloodtab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
                
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
