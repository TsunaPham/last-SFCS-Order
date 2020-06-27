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
        public ChangePassword()
        {
            InitializeComponent();
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox2.Text == "") MessageBox.Show("Please enter all information");
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khoai.LAPTOP-SHJHO9TV\Desktop\SFCSDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                string username = Usertxt.Text.ToString().Trim();
                string old_password = textBox1.Text.ToString().Trim();
                string new_password = textBox2.Text.ToString().Trim();
                bool checkus = false;
                bool checkpass = false;
                string sql = "select * from AccountDB;";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string usname = dr["Username"].ToString().Trim();
                    string pass = dr["Password"].ToString().Trim();
                    if (usname == username)
                    {
                        checkus = true;
                        if (pass == old_password) checkpass = true;
                        break;
                    }
                }
                con.Close();
                if (checkus == false) { MessageBox.Show("You have entered wrong username"); }
                else if (checkpass == false) MessageBox.Show("You have entered wrong password");
                else
                {
                    if (old_password == new_password) MessageBox.Show("New Password must not be the same as Old Password");
                    else
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("Update AccountDB set Password = @Password where Username = @Username", con);
                        cmd2.Parameters.AddWithValue("@Password", new_password);
                        cmd2.Parameters.AddWithValue("@Username", username);
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Your Password had been changed successful!");
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
