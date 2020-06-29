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
using System.Security.Policy;

namespace SFCS
{
    public partial class FoodItem : UserControl
    {
        SqlConnection cnn;
        cnnString con = new cnnString();
        public FoodItem()
        {
            InitializeComponent();
            btnAdd.Enabled = (this.quantity > 0);
            cnn = con.cnn;
        }
        private int _vendor;
        private string _fname;
        private string _price;
        private Image _image;
        private bool _avail;
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
        public int FVendor
        {
            get
            {
                return _vendor;
            }
            set
            { _vendor = value;  }
        }
        public Image img
        {
            get
            {
                return _image;
            }
            set
            { _image = value;pictureBox1.Image = value; }
        }
        private int quantity=0;
        public int Qty
        {
            get
            {
                return quantity;
            }
            set
            { quantity = value; }
        }
        public bool Avail
        {
            get
            {
                return _avail;
            }
            set
            {
                _avail = value;if (value == false) lbAvailable.Text = "Not available"; else lbAvailable.Text = "Avaialble";
            }
        }
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
           
            string sql = "INSERT INTO TempoOrder(Name,Quantity,SubPrice,VendorID) VALUES(@Name,@Quantity,@Subprice,@VendorID)";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cnn.Open();
           
                cmd.Parameters.AddWithValue("@Name", FName);
                cmd.Parameters.AddWithValue("@Quantity", this.quantity);
                int k = Convert.ToInt32(FPrice.Trim());
                int subprice = k * this.quantity;
                cmd.Parameters.AddWithValue("@Subprice", subprice);
                cmd.Parameters.AddWithValue("@VendorID", FVendor);
                cmd.ExecuteNonQuery();
            
            cnn.Close();
        }
        private void searchitem()
        {
            string sql= "select * from TempoOrder";
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
            string sql = "update TempoOrder set Quantity=@qty,Subprice=@sub where Name=@name";
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
