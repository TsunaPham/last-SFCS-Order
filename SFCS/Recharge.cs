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
using System.Net.Mail;
using System.Net;

namespace SFCS
{
    public partial class Recharge : UserControl
    {
        string OTP;
        string name = "";
        string username = "";
        int newbalance = 0;
        string email = "";
        cnnString cnnstr = new cnnString();
        SqlConnection cnn;
        public Recharge()
        {
            InitializeComponent();
            cnn = cnnstr.cnn;
            selectbox.Items.Add("Ocean Bank");
            selectbox.Items.Add("BIDV");
            selectbox.Items.Add("Vietcombank");
            selectbox.Items.Add("Dong A Bank");
            selectbox.Items.Add("OCB");
            otPform1.Hide();
        }
        public void refresh()
        {
           
            string sql = "select * from AccountDB;";
            bool isActive;
            
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                isActive = (bool)dr["isActive"];
                newbalance = Convert.ToInt32(dr["balance"].ToString().Trim());
                name = dr["Name"].ToString();
                username = dr["Username"].ToString().Trim();
                email = dr["Email"].ToString().Trim();
                if (isActive == true) break;
            }
            hellolbl.Text = "Xin chào " + name;
            balancelbl.Text = newbalance.ToString()+" VND";
            cnn.Close();
        }
        public void OTPgenerator()
        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            OTP = "";
            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < 5; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                OTP += sTempChars;

            }

            
        }
        void sendOTPViaMail(string Email, string OTPcode)
        {
            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("zhiendpham@gmail.com");
                msg.To.Add(Email);
                msg.Subject = "Xác thực OTP";
                string mail_body = "Mã OTP của bạn là " + OTPcode;
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

                MessageBox.Show("Mã OTP đã được gửi đến hộp thư của bạn. Sử dụng OTP đó để xác thực trong form sau");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Gửi mail thất bại. Hãy kiểm tra lại kết nối Internet của bạn");
            }
        }
        public void calculateBalance(int amount)
        {
            
            newbalance = amount + newbalance;
        }

        private void Rechargebtn_Click(object sender, EventArgs e)
        {   if (selectbox.Text == "" || numbox.Text == "" || accnamebox.Text == "" || amountbox.Text == "") MessageBox.Show("Bạn phải nhập đầy đủ các thông tin");
            else
            {
                this.OTPgenerator();
                sendOTPViaMail(email, OTP);
                
                otPform1.setvalOTP(OTP);
                otPform1.setusername(username);
                int amount = Convert.ToInt32(amountbox.Text.ToString().Trim());
                calculateBalance(amount);
                otPform1.setbalance(newbalance);
                otPform1.Show();
                otPform1.confirmbtn.Click += new System.EventHandler(this.confirmbtn_Click);
                this.refresh();
            }


        }
        private void confirmbtn_Click(object Sender, EventArgs e)
        {
            refresh();
        }
    }
}
