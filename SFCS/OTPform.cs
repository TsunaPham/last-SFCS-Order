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
        string username="";
        cnnString cnnstr = new cnnString();
        SqlConnection cnn;
        public OTPform()
        {
            InitializeComponent();
            cnn = cnnstr.cnn;
        }
        bool validateOTP(string OTP)
        {
            if (OTP == valOTP) return true;
            else return false;
        }
        void updateBalance()
        {
                cnn.Open();
                SqlCommand cmd2 = new SqlCommand("Update AccountDB set Balance = @Balance where Username = @Username", cnn);
                cmd2.Parameters.AddWithValue("@Balance", balance);
                cmd2.Parameters.AddWithValue("@Username", username);
                cmd2.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Xác thực thành công. Số dư tài khoản hiện tại của bạn là " + balance + ".");
                this.Hide();
        }
        public void confirmbtn_Click(object sender, EventArgs e)
        {
           string newvalOTP = OTPtxt.Text.ToString().Trim();
            bool isValid = validateOTP(newvalOTP);
            if (isValid == true) updateBalance();
            else { MessageBox.Show("Sai mã OTP. Hãy nhập lại một lần nữa."); }

        }
        public void setvalOTP(string OTP) { valOTP=OTP; }
        public void setbalance(int balance) { this.balance = balance; }
        public void setusername(string Username) { this.username = Username; }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
