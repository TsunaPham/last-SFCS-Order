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
    public partial class NewLoginControl : UserControl
    {
        public NewLoginControl()
        {
            InitializeComponent();
            loginSuccess1.Hide();
            newRegister1.Hide();
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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Desktop\SFCS\SFCS\AccountDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sqa = new SqlDataAdapter("Select count(*) From Acctbl where Username ='" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sqa.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                
                MessageBox.Show("Login Successful");

                string text = textBox1.Text;
                string usname = "";
                string name = "";
                string sql = "select * from Acctbl;";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
              while (dr.Read())
                {
                    usname = dr["Username"].ToString();
                    name = dr["Name"].ToString();
                    if (usname.Trim() == text.Trim()) break;
                }
                con.Close();
                int active = 1;
                con.Open();
                SqlCommand cmd2 = new SqlCommand("Update Acctbl set isActive = @isActive where Username = @Username", con);
                cmd2.Parameters.AddWithValue("@isActive", active);
                cmd2.Parameters.AddWithValue("@Username", usname);
                cmd2.ExecuteNonQuery();
                con.Close();
                loginSuccess1.setName(name);
                loginSuccess1.setusName(usname);
                loginSuccess1.refreshing();
                loginSuccess1.Show();
            }
            else MessageBox.Show("Login Failed. Please sign in again!");
        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            newRegister1.Show();

        }
    }
}
