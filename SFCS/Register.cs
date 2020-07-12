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
using System.Data.Sql;

namespace SFCS
{
    public partial class Register : UserControl
    {
        cnnString cnnstr = new cnnString();
        SqlConnection cnn;
        public Register()
        {
            InitializeComponent();
            cnn = cnnstr.cnn;
        }
        public bool checkMail(string Email)
        {
            bool checkmail = false;
            string sql = "select * from AccountDB;";
            cnn.Open();
            SqlCommand cmd2 = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                string mail = dr["Email"].ToString().Trim();
                if (Email == mail) checkmail = true;

            }
            cnn.Close();
            return checkmail;
        }
        public bool checkUsername(string Username)
        {
            bool checkusername = false;
            string sql = "select * from AccountDB;";
            cnn.Open();
            SqlCommand cmd2 = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                string username = dr["Username"].ToString().Trim();
                if (Username == username) checkusername = true;
                
            }
            cnn.Close();
            return checkusername;
        }
        public void signup()
        {
            string Username = UserTxt.Text.Trim();
            string Email = Emailtxt.Text.Trim();


            bool ischeckuser = checkUsername(Username);
            bool ischeckmail = checkMail(Email);
            if (ischeckuser == true) MessageBox.Show("Tên đăng nhập này đã tồn tại");
            if (ischeckmail == true) MessageBox.Show("Email này đã được người khác đăng kí");
            if (Confirmtxt.Text != Passtxt.Text) MessageBox.Show("Mật khẩu nhập lại không chính xác");
            if (ischeckuser == false && ischeckmail == false && Confirmtxt.Text == Passtxt.Text)
            {
                int active = 0;
                int balance = 0;
                cnn.Open();
                String query = "INSERT INTO AccountDB(Name,Email,PhoneNumber,Username,Password,Balance,isActive) VALUES(@Name,@Email,@PhoneNumber,@Username,@Password,@Balance,@isActive)";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Name", Nametxt.Text.ToString());
                cmd.Parameters.AddWithValue("@Email", Emailtxt.Text.Trim());
                cmd.Parameters.AddWithValue("@PhoneNumber", Phonetxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Username", UserTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", Passtxt.Text.Trim());
                cmd.Parameters.AddWithValue("@Balance", balance);
                cmd.Parameters.AddWithValue("@isActive", active);
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Bạn đã đăng kí thành công");
                this.Hide();
            }
        }
        private void Signinbtn_Click(object sender, EventArgs e)
        {
            signup();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Passtxt_TextChanged(object sender, EventArgs e)
        {
            Passtxt.UseSystemPasswordChar = true;
        }

        private void Confirmtxt_TextChanged(object sender, EventArgs e)
        {
            Confirmtxt.UseSystemPasswordChar = true;
        }
    }
}
