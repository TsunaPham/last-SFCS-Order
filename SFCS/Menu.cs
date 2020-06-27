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

namespace SFCS
{   
    public partial class Menu : UserControl
    {   
        public Menu()
        {
            InitializeComponent();
           
        }
        private string vname="";
        public void setvname(string name)
        {
            this.vname = name;
        }
        
        private void Menu_Load(object sender, EventArgs e)
        {
           
        }
        public void Refresh()
        {
            flowLayoutPanel1.Controls.Clear();
            populate();
        }
        private void populate()
        {  FoodItem[] flist = new FoodItem[15];
           
            SqlConnection cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Admin\Desktop\SFCS\SFCS\SFCS.mdf; Integrated Security = True");
            string foodname = "";
            string fprice = "";
            string vendor = "";
            string sql = "select * from FoodItem";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                foodname = dr["Name"].ToString();
                fprice = dr["Price"].ToString();
                vendor = dr["Vendor"].ToString();
                flist[i] = new FoodItem();
                flist[i].FName = foodname;
                flist[i].FPrice = fprice;
                flist[i].FVendor = vendor;
                if(vendor.Trim()==this.vname.Trim())
                flowLayoutPanel1.Controls.Add(flist[i]);
                i++;
               
            }
            cnn.Close();
        
           
               
        }
    }
}
