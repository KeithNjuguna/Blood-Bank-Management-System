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

namespace BloodManagement
{
    public partial class Bank : Form
    {
        public Bank()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into banktab values(@bankid,@bloodtype,@orders)", con);
            cmd.Parameters.AddWithValue("@BankID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Bloodtype", textBox2.Text);
            cmd.Parameters.AddWithValue("@Orders", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update banktab set bloodtype=@bloodtype,orders=@orders where bankid=@bankid", con);
            cmd.Parameters.AddWithValue("@BankID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Bloodtype", textBox2.Text);
            cmd.Parameters.AddWithValue("@Orders", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete banktab where bankid=@bankid", con);
            cmd.Parameters.AddWithValue("@BankID", int.Parse(textBox1.Text));
            
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void Bank_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AAQ9IE4;Initial Catalog=bankdb;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from banktab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        
    }
    }
}
