﻿using System;
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
    public partial class NewRegister : UserControl
    {
        public NewRegister()
        {
            InitializeComponent();
        }

        private void Signinbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khoai.LAPTOP-SHJHO9TV\Desktop\SFCSDatabase.mdf;Integrated Security=True;Connect Timeout=30");

            if (UserTxt.Text == "" || Passtxt.Text == "" || Nametxt.Text == "" || Emailtxt.Text == "") MessageBox.Show("Please fill in all mandatory information");
            else
            {
                bool checkmail = false;
                bool checkusername = false;
                string sql = "select * from AccountDB;";
                con.Open();
                SqlCommand cmd2 = new SqlCommand(sql, con);
                SqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {   
                    string mail= dr["Email"].ToString().Trim();
                    string username = dr["Username"].ToString().Trim();
                    if (UserTxt.Text.Trim() == username) checkusername = true;
                    if (Emailtxt.Text.Trim() == mail) checkmail = true;
                   
                }
                con.Close();
                if (checkusername == true) MessageBox.Show("This username has exited!");
                if (checkmail == true) MessageBox.Show("This email has been registered before");
                if (Confirmtxt.Text != Passtxt.Text) MessageBox.Show("Password do not match");
                if(checkusername ==false && checkmail==false && Confirmtxt.Text==Passtxt.Text)
                {
                    int active = 0;
                    int balance = 0;
                    con.Open();
                    String query = "INSERT INTO AccountDB(Name,Email,PhoneNumber,Username,Password,Balance,isActive) VALUES(@Name,@Email,@PhoneNumber,@Username,@Password,@Balance,@isActive)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", Nametxt.Text.ToString());
                    cmd.Parameters.AddWithValue("@Email", Emailtxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@PhoneNumber", Phonetxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@Username", UserTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", Passtxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@Balance", balance);
                    cmd.Parameters.AddWithValue("@isActive", active);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Registration Success");
                    this.Hide();
                }
            }
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