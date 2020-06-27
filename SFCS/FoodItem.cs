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
    public partial class FoodItem : UserControl
    {
        SqlConnection cnn;
        public FoodItem()
        {
            InitializeComponent();
            btnAdd.Enabled = (this.quantity > 0);
            cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Admin\Desktop\SFCS\SFCS\SFCS.mdf; Integrated Security = True");
        }
        private string _vendor;
        private string _fname;
        private string _price;
        
        public string FName
        {
            get
            {
                return _fname;
            }
            set
            { _fname = value; lbName.Text = value; }
        }
        public string FPrice
        {
            get
            {
                return _price;
            }
            set
            { _price = value; lbPrice.Text = value; }
        }
        public string FVendor
        {
            get
            {
                return _vendor;
            }
            set
            { _vendor = value;  }
        }
        private int quantity=0;
        private int addqty = 0;
        private void BtnPlus_Click(object sender, EventArgs e)
        {   if (this.quantity<10)
            this.quantity++;
            lbQty.Text = this.quantity.ToString();
            btnAdd.Enabled = true;
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            if (this.quantity > 0)
            { this.quantity--; btnAdd.Enabled = true; }
            
            lbQty.Text = this.quantity.ToString();
            btnAdd.Enabled = this.quantity > 0;
        }

        private void LbQty_Click(object sender, EventArgs e)
        {

        }
       private void addfooditem()
        {
           
            string sql = "INSERT INTO Ordertbl(Name,Quantity,SubPrice,Vendor) VALUES(@Name,@Quantity,@Subprice,@Vendor)";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cnn.Open();
           
                cmd.Parameters.AddWithValue("@Name", FName);
                cmd.Parameters.AddWithValue("@Quantity", this.quantity);
                int k = Convert.ToInt32(FPrice.Trim());
                int subprice = k * this.quantity;
                cmd.Parameters.AddWithValue("@Subprice", subprice);
                cmd.Parameters.AddWithValue("@Vendor", FVendor);
                cmd.ExecuteNonQuery();
            
            cnn.Close();
        }
        private void searchitem()
        {
            string sql= "select * from Ordertbl";
            string name = "";
            string qtystr = "";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            
            cnn.Open();SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                name = dr["Name"].ToString();
                if (name.Trim() == FName.Trim())
                {
                    qtystr = dr["Quantity"].ToString();
                    addqty = Convert.ToInt32(qtystr.Trim());

                }
            }
            cnn.Close();
        }
        private void updateitem()
        {
            string sql = "update Ordertbl set Quantity=@qty,Subprice=@sub where Name=@name";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            int newqty = this.quantity + this.addqty;
            cnn.Open();
            cmd.Parameters.AddWithValue("@name", FName);
            cmd.Parameters.AddWithValue("@qty", newqty);
            int k = Convert.ToInt32(FPrice.Trim());
            int subprice = newqty * k;
            cmd.Parameters.AddWithValue("@sub", subprice);
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            addqty = 0;
            searchitem();
            if (addqty == 0) addfooditem();
            else updateitem();
            quantity = 0;btnAdd.Enabled = false;
            lbQty.Text = "0";

            
        }
    }
}
