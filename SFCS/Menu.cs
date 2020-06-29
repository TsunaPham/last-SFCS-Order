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
        public void Refresh()
        {
            flowLayoutPanel1.Controls.Clear();
            populate();
        }
        public int countrow()
        {
            string stmt = "SELECT COUNT(*) FROM ItemDB";
            int count = 0;
            cnn.Open();
            SqlCommand cmdCount = new SqlCommand(stmt, cnn);
            count = (int)cmdCount.ExecuteScalar();
            cnn.Close();

            return count;
        }
        private void populate()
        {
            int count = countrow();
            FoodItem[] flist = new FoodItem[count];
           
            
            string foodname = "";
            string fprice = "";
            int vendor;
            bool avail;
            byte[] img;
            string sql = "select * from ItemDB";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                foodname = dr["Name"].ToString();
                fprice = dr["Price"].ToString();
                vendor = (int)dr["VendorID"];
                avail = (bool)dr["Available"];
                //if(dr["Id"].ToString()=="1") 
                flist[i] = new FoodItem();
                flist[i].FName = foodname;
                flist[i].FPrice = fprice;
                flist[i].FVendor = vendor;
                flist[i].Avail = avail;
                if (avail == false) flist[i].Enabled = false;
                var data = (byte[])dr["Image"]; var stream = new MemoryStream(data); flist[i].img = Image.FromStream(stream); 
                if (vendor==this.vid)
                flowLayoutPanel1.Controls.Add(flist[i]);
                
                i++;
               
            }
            cnn.Close();
        
           
               
        }
    }
}
