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
using System.Xml.Serialization;

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
        private Int64 _price;
        private Image _image;
        private bool _avail;
        private string description;
        public string FName
        {
            get
            {
                return _fname;
            }
            set
            { _fname = value; lbName.Text = value; }
        }
        public Int64 FPrice
        {
            get
            {
                return _price;
            }
            set
            { _price = value; lbPrice.Text = value.ToString(); }
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
                _avail = value;if (value == false) lbAvailable.Text = "Hết"; else lbAvailable.Text = "Còn";
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value; lbDescrip.Text = value;
            }
        }
        private int addqty = 0;
        private void BtnPlus_Click(object sender, EventArgs e)
        {
            amountUp();
        }
        private void amountUp()
        {
            if (this.quantity < 10)
                this.quantity++;
            lbQty.Text = this.quantity.ToString();
            btnAdd.Enabled = true;
        }
        private void BtnMinus_Click(object sender, EventArgs e)
        {
            amountDown();
        }
        private void amountDown()
        {
            if (this.quantity > 0)
            { this.quantity--; btnAdd.Enabled = true; }

            lbQty.Text = this.quantity.ToString();
            btnAdd.Enabled = this.quantity > 0;

        }
        private void LbQty_Click(object sender, EventArgs e)
        {

        }
       private void addFoodItem()
        {
           
            string sql = "INSERT INTO TempoOrder(Name,Quantity,SubPrice,VendorID) VALUES(@Name,@Quantity,@Subprice,@VendorID)";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cnn.Open();
           
                cmd.Parameters.AddWithValue("@Name", FName);
                cmd.Parameters.AddWithValue("@Quantity", this.quantity);
                Int64 k = FPrice;
                Int64 subprice = k * this.quantity;
                cmd.Parameters.AddWithValue("@Subprice", subprice);
                cmd.Parameters.AddWithValue("@VendorID", FVendor);
                cmd.ExecuteNonQuery();
            
            cnn.Close();
        }
        private void searchItem()
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
        private void updateItem()
        {
            string sql = "update TempoOrder set Quantity=@qty,Subprice=@sub where Name=@name";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            int newqty = this.quantity + this.addqty;
            cnn.Open();
            cmd.Parameters.AddWithValue("@name", FName);
            cmd.Parameters.AddWithValue("@qty", newqty);
           
            Int64 subprice = newqty *FPrice;
            cmd.Parameters.AddWithValue("@sub", subprice);
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            addToCart();

            
        }
        private void addToCart()
        {
            addqty = 0;
            searchItem();
            if (addqty == 0) addFoodItem();
            else updateItem();
            quantity = 0; btnAdd.Enabled = false;
            lbQty.Text = "0";
        }
    }
}
