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
    public partial class loginSuccess : UserControl
    {
        string name="Nobody";
        string usname = "";
        public loginSuccess()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setusName(string usname)
        {
            this.usname = usname;
        }
        public void refreshing()
        {
            label1.Text = "Hello " + name;
            label2.Text = "Welcome back to our Food Court";
            label3.Text = " Please enjoy your meal !";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Signinbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Desktop\SFCS\SFCS\AccountDB.mdf;Integrated Security=True;Connect Timeout=30");
            int active = 0;
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Update Acctbl set isActive = @isActive where Username = @Username", con);
            cmd2.Parameters.AddWithValue("@isActive", active);
            cmd2.Parameters.AddWithValue("@Username", usname);
            cmd2.ExecuteNonQuery();
            con.Close();
            this.Hide();

        }
    }
}
