using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace SFCS
{   
    public partial class Menu : UserControl
    {
        cnnString con = new cnnString();
        SqlConnection cnn;
        public Menu()
        {
            InitializeComponent();
            cnn = con.cnn;
           
        }
        private int vid;
        public void setvid(int id)
        {
            this.vid= id;
        }
        
        private void Menu_Load(object sender, EventArgs e)
        {
           
        }
        public void viewMenu()
        {
            flowLayoutPanel1.Controls.Clear();
            int count = countItem();
            FoodItem[] flist = new FoodItem[count];


            string foodname = "";
            Int64 fprice;
            int vendor;
            bool avail;
            string des;
            byte[] img;
            string sql = "select * from ItemDB";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                foodname = dr["Name"].ToString();
                fprice = (Int64)dr["Price"];
                vendor = (int)dr["VendorID"];
                avail = (bool)dr["Available"];
                des = dr["Description"].ToString();
                //if(dr["Id"].ToString()=="1") 
                flist[i] = new FoodItem();
                flist[i].FName = foodname;
                flist[i].FPrice = fprice;
                flist[i].FVendor = vendor;
                flist[i].Avail = avail;
                flist[i].Description = des;
                if (avail == false) flist[i].Enabled = false;
                var data = (byte[])dr["Image"]; var stream = new MemoryStream(data); flist[i].img = Image.FromStream(stream);
                if (vendor == this.vid)
                    flowLayoutPanel1.Controls.Add(flist[i]);

                i++;

            }
            cnn.Close();
        }
        public int countItem()
        {
            string stmt = "SELECT COUNT(*) FROM ItemDB";
            int count = 0;
            cnn.Open();
            SqlCommand cmdCount = new SqlCommand(stmt, cnn);
            count = (int)cmdCount.ExecuteScalar();
            cnn.Close();

            return count;
        }
        
    }
}
