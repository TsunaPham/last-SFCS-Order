using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SFCS
{
    public partial class OTPform : UserControl
    {   string valOTP = "";
        int balance = 0;
        string name="";
        public OTPform()
        {
            InitializeComponent();
        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
           string newvalOTP = OTPtxt.Text.ToString().Trim();
            if (newvalOTP == valOTP)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Desktop\SFCS\SFCS\AccountDB.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd2 = new SqlCommand("Update Acctbl set Balance = @Balance where Name = @Name", con);
                cmd2.Parameters.AddWithValue("@Balance", balance);
                cmd2.Parameters.AddWithValue("@Name", name);
                cmd2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Validate Successful. Your new balance is "+balance+". Please reset this page to see the update");
                this.Hide();
            }
            else { MessageBox.Show("Wrong OTP. Please enter again"); }
            
        }
        public void setvalOTP(string OTP) { valOTP=OTP; }
        public void setbalance(int balance) { this.balance = balance; }
        public void setname(string name) { this.name = name; }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
