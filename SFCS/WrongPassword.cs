using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;

namespace SFCS
{
    public partial class WrongPassword : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khoai.LAPTOP-SHJHO9TV\Desktop\SFCSDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        public WrongPassword()
        {
            InitializeComponent();
        }
        void mail(string password)
        {
            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("zhiendpham@gmail.com");
                msg.To.Add(Emailtxt.Text.Trim());
                msg.Subject = "Retrive Password";
                string mail_body = "Your password is " + password;
                msg.Body = mail_body;

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "zhiendpham@gmail.com";
                ntcd.Password = "zhiendpham_1999";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);

                MessageBox.Show("Your Password had been sent to your email. Please check your email inbox and sign in again");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Sent Email Failed. Please check your internet connection.");
            }
        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            string password = "";
            string email = "";
            string sql = "select * from AccountDB;";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                password = dr["Password"].ToString();
                email = dr["Email"].ToString();
                if (email.Trim() == Emailtxt.Text.Trim()) break;
                password = "";
            }
            con.Close();
            if (password != "") 
            {
                mail(password);
                this.Hide();
            }
            else { MessageBox.Show("You don't have SFCS account. Please register your new account"); }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
