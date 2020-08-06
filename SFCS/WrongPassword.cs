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
        cnnString cnnstr = new cnnString();
        SqlConnection cnn;
        public WrongPassword()
        {
            InitializeComponent();
            cnn = cnnstr.cnn;
        }
        public string findPassword(string Email)
        {
            string sql = "select * from AccountDB;";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            string Password = "";
            string email = "";
            while (dr.Read())
            {
                Password = dr["Password"].ToString();
                email = dr["Email"].ToString();
                if (email.Trim() == Email) break;
                Password = "";
            }
            cnn.Close();
            return Password;
        }
        public void mail(string Email, string Password)
        {
            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("zhiendpham@gmail.com");
                msg.To.Add(Email);
                msg.Subject = "Lấy lại mật khẩu";
                string mail_body = "Mật khẩu của bạn là " + Password;
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

                MessageBox.Show("Mật khẩu đã được gửi đến hộp thư của bạn.");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Gửi mail thất bại. Hãy kiểm tra lại kết nối Internet của bạn");
            }
        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {


            if (Emailtxt.Text == "") MessageBox.Show("Bạn phải nhập đầy đủ các thông tin cần thiết");
            else
            {
                string password = findPassword(Emailtxt.Text.Trim());
                if (password != "")
                {
                    mail(Emailtxt.Text.Trim(),password);
                    this.Hide();
                }
                else { MessageBox.Show("Email này chưa được đăng kí."); }
            } }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
