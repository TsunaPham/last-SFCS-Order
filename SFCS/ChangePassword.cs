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
    public partial class ChangePassword : UserControl
    {
        cnnString cnnstr = new cnnString();
        SqlConnection cnn;
        public ChangePassword()
        {
            InitializeComponent();
            cnn = cnnstr.cnn;
        }
        public bool checkInfo(string Username, string Password)
        {
            bool checkus = false;
            bool checkpass = false;
            string sql = "select * from AccountDB;";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string usname = dr["Username"].ToString().Trim();
                string pass = dr["Password"].ToString().Trim();
                if (usname == Username)
                {
                    checkus = true;
                    if (pass == Password) checkpass = true;
                    break;
                }
            }
            cnn.Close();
            return (checkpass&&checkus);
        }
        public void resetPassword(string Username, string newPassword)
        {
            cnn.Open();
            SqlCommand cmd2 = new SqlCommand("Update AccountDB set Password = @Password where Username = @Username", cnn);
            cmd2.Parameters.AddWithValue("@Password", newPassword);
            cmd2.Parameters.AddWithValue("@Username", Username);
            cmd2.ExecuteNonQuery();
            cnn.Close();
           
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox2.Text == "") MessageBox.Show("Bạn phải điền đầy đủ các thông tin cần thiết");
            else
            {
                
                string username = Usertxt.Text.ToString().Trim();
                string old_password = textBox1.Text.ToString().Trim();
                string new_password = textBox2.Text.ToString().Trim();
                bool check = checkInfo(username, old_password);
                if (check == false) MessageBox.Show("Thay đổi mật khẩu thất bại. Tên đăng nhập hoặc mật khẩu cũ không đúng");
                else
                {
                    if (old_password == new_password) MessageBox.Show("Mật khẩu mới phải khác với mật khẩu cũ");
                    else
                    {
                        resetPassword(username, new_password);
                        MessageBox.Show("Thay đổi mật khẩu thành công");
                    }
                }

            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
