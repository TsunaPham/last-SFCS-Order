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
    public partial class LoginControl : UserControl
    {
        cnnString cnnstr = new cnnString();
        SqlConnection cnn;
        public int isActive = 0;
        public int accID = 0;
        public LoginControl()
        {
            InitializeComponent();
            cnn = cnnstr.cnn;
            history1.Hide();
            newRegister1.Hide();
            wrongPassword1.Hide();
            changePassword1.Hide();
        }
        public bool validate(string Username, string Password)
        {

            SqlDataAdapter sqa = new SqlDataAdapter("Select count(*) From AccountDB where Username ='" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", cnn);
            DataTable dt = new DataTable();
            sqa.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1") return true;
            else return false;
        }
        public void memberLogin(string Username, string Password)
        {
            bool isvalid = validate(Username, Password);
            if (isvalid == true)
            {
                MessageBox.Show("Đăng nhập thành công");
                string usname = "";
                string name = "";
                string sql = "select * from AccountDB;";
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    isActive = 1;
                    usname = dr["Username"].ToString();
                    name = dr["Name"].ToString();
                    accID = (int)dr["ID"];
                    if (usname.Trim() == Username) break;
                }
                cnn.Close();
                int active = 1;
                cnn.Open();
                SqlCommand cmd2 = new SqlCommand("Update AccountDB set isActive = @isActive where Username = @Username", cnn);
                cmd2.Parameters.AddWithValue("@isActive", active);
                cmd2.Parameters.AddWithValue("@Username", usname);
                cmd2.ExecuteNonQuery();
                cnn.Close();
                
                history1.setName(name);
                history1.setusName(usname);
                history1.accid = accID;
                history1.refreshing();
                history1.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác, đăng nhập thất bại. ");
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void Signinbtn_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.ToString().Trim();
            string password = textBox2.Text.ToString().Trim();
            memberLogin(username, password);

        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            newRegister1.Show();

        }

        private void linkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            wrongPassword1.Show();
        }

        private void Changebtn_Click(object sender, EventArgs e)
        {
            changePassword1.Show();
        }
    }
}
