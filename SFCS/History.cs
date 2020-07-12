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
using System.Runtime.InteropServices;

namespace SFCS
{
    public partial class History : UserControl
    { cnnString cnnstr = new cnnString();
        SqlConnection cnn;
        string name="Nobody";
        string usname = "";
        public int accid { set; get; }
        public History()
        {
            InitializeComponent();
            cnn = cnnstr.cnn;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Hide();
            lbHis.Hide();
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
            flowLayoutPanel1.Controls.Clear();
            label1.Text = "Hello " + name;
            viewHistory();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private int countorder()
        {
            int checkid = 0;
            int count = 0;
            string sql = "select * from OrderDB";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                checkid = (int)dr["AccountID"];
                if (checkid == accid) count++;
            }
            cnn.Close();
            return count;

        }
        historyline[] line;
        private void viewHistory()
        {
            line = new historyline[countorder()];
            
            int checkid = 0;
            int vendorid;
            Int64 total;
            DateTime date;
            string sql = "select * from OrderDB";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                checkid = (int)dr["AccountID"];
                total = (Int64)dr["Total"];
                vendorid = (int)dr["VendorID"];
                date = (DateTime)dr["Datetime"];
                if (checkid == accid)
                {
                    line[i] = new historyline();
                    line[i].Total = total;
                    line[i].Date = date;
                    
                    line[i].Vendor = vendorid;

                    flowLayoutPanel1.Controls.Add(line[i]);
                    i++;
                }
                
            }
            cnn.Close();

        }
        private void Signinbtn_Click(object sender, EventArgs e)
        {
            setActive();

        }
        private void setActive()
        {
            
            int active = 0;
            cnn.Open();
            SqlCommand cmd2 = new SqlCommand("Update AccountDB set isActive = @isActive where ID = @ID", cnn);
            cmd2.Parameters.AddWithValue("@isActive", active);
            cmd2.Parameters.AddWithValue("@ID", accid);
            cmd2.ExecuteNonQuery();
            cnn.Close();
            this.Hide();
        }
        bool isView;
        private void button1_Click(object sender, EventArgs e)
        {
            if (isView == false)
            {
                flowLayoutPanel1.Show();lbHis.Show();
                isView = true;
            }
            else
            {
                flowLayoutPanel1.Hide();lbHis.Hide();
                isView = false;
            }
        }
    }
}
