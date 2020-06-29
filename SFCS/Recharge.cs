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
    public partial class Recharge : UserControl
    {
        string OTP;
        string name = "";
        int balance = 0;
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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Desktop\SFCS\SFCS\AccountDB.mdf;Integrated Security=True;Connect Timeout=30");
            string sql = "select * from Acctbl;";
            int isActive;
            
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                isActive = Convert.ToInt32(dr["isActive"].ToString().Trim());
                balance = Convert.ToInt32(dr["balance"].ToString().Trim());
                name = dr["Name"].ToString();
                if (isActive == 1) break;
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
        public string getOTP() { return this.OTP; }
        private void Rechargebtn_Click(object sender, EventArgs e)
        {   if (selectbox.Text == "" || numbox.Text == "" || accnamebox.Text == "" || amountbox.Text == "") MessageBox.Show("Please fill in all information");
            else
            {
                this.OTPgenerator();
                MessageBox.Show("Your OTP is " + OTP + ". Please confirm your OTP");
                otPform1.setvalOTP(OTP);
                otPform1.setname(name);
                int amount = Convert.ToInt32(amountbox.Text.ToString().Trim());
                int newbalance = amount + balance;
                otPform1.setbalance(newbalance);
                otPform1.Show();
                this.refresh();
            }


        }
    }
}
