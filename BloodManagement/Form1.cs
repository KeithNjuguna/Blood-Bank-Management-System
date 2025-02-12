using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hospital h1 = new Hospital();   
            h1.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Donor dr = new Donor(); 
            dr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Blood bd = new Blood();    
            bd.Show();  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Receptionist rt = new Receptionist();
            rt.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bank bk = new Bank();   
            bk.Show();
        }
    }
}
