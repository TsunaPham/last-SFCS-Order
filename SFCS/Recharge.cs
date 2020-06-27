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
        int balance = 0;
        string email = "";
        public Recharge()
        {
            InitializeComponent();
            selectbox.Items.Add("Ocean Bank");
            selectbox.Items.Add("BIDV");
            selectbox.Items.Add("Vietcombank");
            selectbox.Items.Add("Dong A Bank");
            selectbox.Items.Add("OCB");
            otPform1.Hide();
        }
        public void refresh()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khoai.LAPTOP-SHJHO9TV\Desktop\SFCSDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            string sql = "select * from AccountDB;";
            bool isActive;
            
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                isActive = (bool)dr["isActive"];
                balance = Convert.ToInt32(dr["balance"].ToString().Trim());
                name = dr["Name"].ToString();
                email = dr["Email"].ToString().Trim();
                if (isActive == true) break;
            }
            hellolbl.Text = "Hello " + name;
            balancelbl.Text = balance.ToString()+" VND";
            con.Close();
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
        void mail(string OTPcode)
        {
            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("zhiendpham@gmail.com");
                msg.To.Add(email);
                msg.Subject = "Confirm OTP";
                string mail_body = "Your OTP is " + OTPcode;
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

                MessageBox.Show("Your OTP had been sent to your email. Please check email inbox and confirm your OTP");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Sent Email Failed. Please check your internet connection.");
            }
        }
        public string getOTP() { return this.OTP; }
        private void Rechargebtn_Click(object sender, EventArgs e)
        {   if (selectbox.Text == "" || numbox.Text == "" || accnamebox.Text == "" || amountbox.Text == "") MessageBox.Show("Please fill in all information");
            else
            {
                this.OTPgenerator();
                mail(OTP);
                
                otPform1.setvalOTP(OTP);
                otPform1.setname(name);
                int amount = Convert.ToInt32(amountbox.Text.ToString().Trim());
                int newbalance = amount + balance;
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
