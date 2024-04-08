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

namespace Midterm_Project_Programming_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SQL Interaction
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\laczk\Downloads\WSCC\Programming 2\Midterm Programming 2\Midterm Project Programming 2\Midterm Project Programming 2\Database Mid.mdf"";Integrated Security=True;Connect Timeout=30;";
            if (txbCustomerNumber.Text == "" || txbPIN.Text == "")
            {
                MessageBox.Show("Please provide Customer Number and PIN");
                return;
            }
            try
            {
                //Create SqlConnection
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Select * from [BankCustomer] where CustomerNumber=@customernum and PIN = @PIN", con);
                cmd.Parameters.AddWithValue("@customernum", txbCustomerNumber.Text);
                cmd.Parameters.AddWithValue("@PIN", txbPIN.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;

                //Output
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    frmAccount fm = new frmAccount();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbCustomerNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
