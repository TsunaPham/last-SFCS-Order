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
using System.Collections.ObjectModel;
using System.Reflection;

namespace SFCS
{
    public partial class Cart : UserControl
    {
        SqlConnection cnn;
        cnnString cnnstr = new cnnString();
        public Cart()
        {
            InitializeComponent();
            cnn = cnnstr.cnn;
            deleteCart();//interface class
            btnCheckout.Enabled = false;
            payment1.Hide();
            
        }
        public void refresh()
        {
            cartlist.Clear();
            flowLayoutPanel1.Controls.Clear();
            viewCart();
        }
        private Int64 total = 0;
        
        private string _cusname = "";
        
        public void setCusname(string usname)
        {
            _cusname = usname;
        }
        private int isactive;
        public void setisActive(int active)
        {
            isactive = active;
        }
        
        public int orderID;
        private int accID;
        private bool isCheck;
        public bool getisCheck()
        { return isCheck; }
        public void setaccID(int id)
        {
            accID = id;
        }
        
        private void deleteCart()
        {
            string sql = "DELETE FROM TempoOrder";
            string sql1 = "DBCC CHECKIDENT (TempoOrder,RESEED,0)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlCommand cmd1 = new SqlCommand(sql1, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cnn.Close();
        }
        private int countCartItem()
        {
            string stmt = "SELECT COUNT(*) FROM TempoOrder";
            int count = 0;
            cnn.Open();
            SqlCommand cmdCount = new SqlCommand(stmt, cnn);
            count = (int)cmdCount.ExecuteScalar();
            cnn.Close();
            return count;
        }
        List<CartItem> cartlist = new List<CartItem>();
        private int amount = 0;
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private void viewCart()
        {
            
            total = 0;

            amount = 0;
            string foodname = "";
            
            int fqty = 0;
            Int64 sub;
            int vdor;
            string sql = "select * from TempoOrder";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                CartItem item = new CartItem();
                foodname = dr["Name"].ToString();
                fqty = (int)dr["Quantity"];

                sub = (Int64)dr["Subprice"];
                
                vdor = (int)dr["VendorID"];
                
                item.FName = foodname;
                item.Qty = fqty;
                item.Sub = sub;
                item.Vendor = vdor; item.btndel.Click += new System.EventHandler(this.deleteItem);
                cartlist.Add(item);
                flowLayoutPanel1.Controls.Add(item);
              

                i++;
                amount++;

            }
            calcTotal(cartlist);
            if (amount > 0) btnCheckout.Enabled = true;
            else btnCheckout.Enabled = false;
            lbTotal.Text = total.ToString();
            cnn.Close();



        }
        
        private void calcTotal(List<CartItem> cartlist)
        {
            
            for(int i=0;i<cartlist.Count();i++)
            {
                total += cartlist[i].Sub;
            }
           
        }
        

        private void deleteItem(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this item from cart", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                refresh();

            }
            
        }
       //private int orderid()
       // {
       //     string sql = "select * from OrderDB";
       //     cnn.Open();
       //     SqlCommand cmd = new SqlCommand(sql, cnn);
       //     SqlDataReader dr = cmd.ExecuteReader();
            
       //     int id = 0;
       //     while (dr.Read())
       //     {
       //         id = (int)dr["ID"];
       //     }
       //     cnn.Close();
       //     return ++id;
            
       // }
        //private void updateOrderLine()
        //{
           
        //    orderID = orderid();
        //    cnn.Open();
        //    for (int i=0;i<amount;i++)
        //    {
        //        string sql = "INSERT INTO OrderLineDB(OrderID,Name,Quantity,SubPrice,VendorID) VALUES(@OrderID,@Name,@Quantity,@SubPrice,@VendorID)";
        //        SqlCommand cmd = new SqlCommand(sql, cnn);
        //        cmd.Parameters.AddWithValue("@OrderID", orderID);
        //        cmd.Parameters.AddWithValue("@Name", cartlist[i].FName);

        //        cmd.Parameters.AddWithValue("@Quantity", cartlist[i].Qty);
        //        cmd.Parameters.AddWithValue("@VendorID", cartlist[i].Vendor);
        //        cmd.Parameters.AddWithValue("@SubPrice", cartlist[i].Sub);
                
        //        cmd.ExecuteNonQuery();
        //    }
        //    cnn.Close();
        //}
        private void CartView_Load(object sender, EventArgs e)
        {

        }
        //private Int64 checkbalance()
        //{
        //    string sql = "select * from AccountDB;";
        //    bool isActive;
        //    Int64 balance=0;
        //    string name = "";
        //    cnn.Open();
        //    SqlCommand cmd = new SqlCommand(sql, cnn);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        isActive = (bool)dr["isActive"];
        //        balance = Convert.ToInt64(dr["Balance"].ToString().Trim());
        //        name = dr["Name"].ToString();
        //        if (isActive == true) break;
        //    }
        //    cnn.Close();

        //    if (balance < total) return -1;
        //    else return balance-total;
            
            
        //}
        //private void updatebalance(Int64 balance)
        //{
            
        //    cnn.Open();
        //    SqlCommand cmd2 = new SqlCommand("Update AccountDB set Balance = @Balance where Username = @Username", cnn);
        //    cmd2.Parameters.AddWithValue("@Balance", balance);
        //    cmd2.Parameters.AddWithValue("@Username", _cusname);
        //    cmd2.ExecuteNonQuery();
        //    cnn.Close();
        //}

        //private static Random random = new Random();
        //public DateTime RandomDay()
        //{
        //    DateTime start = new DateTime(2020, 6, 28);
        //    DateTime end = new DateTime(2021, 6, 28);
        //    int range = (end-start).Days;           
        //    return start.AddDays(random.Next(range));
        //}
        //public void Alert(string msg, Noti.enmType type)
        //{
        //    Noti frm = new Noti();
        //    frm.showAlert(msg, type);
        //}
        private void Checkout()
        {
            isCheck = false;
            if (isactive == 0) MessageBox.Show("Yêu cầu đăng nhập trước khi thanh toán");
            else
            {
                if (MessageBox.Show("Nếu bạn xác nhận đơn hàng, các món ăn được chọn sẽ mất", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    isCheck = true;
                    payment1.setlist(cartlist);
                    
                    payment1.setTotal(total);
                    
                    payment1.setCID(accID);
                    
                    payment1.setVID(cartlist[0].Vendor);
                    payment1.setActive(isactive);
                    
                    payment1.Show();
                    //Int64 balance = checkbalance();
                    //isCheck = false;

                    //if (balance > -1)
                    //{

                    //    isCheck = true;
                    //    DateTime datetime = RandomDay();

                    //    MessageBox.Show("Payment isCheckful - Your balance is now " + balance.ToString());
                    //    string sql = "INSERT INTO OrderDB(AccountID,Total,VendorID,Datetime,Done) VALUES(@AccountID,@Total,@VendorID,@Datetime,@Done)";
                    //    SqlCommand cmd = new SqlCommand(sql, cnn);

                    //    cnn.Open();


                    //    cmd.Parameters.AddWithValue("AccountID", accID);

                    //    cmd.Parameters.AddWithValue("@Total", total);
                    //    cmd.Parameters.AddWithValue("@VendorID", cartlist[0].Vendor);
                    //    cmd.Parameters.AddWithValue("@Datetime", datetime);
                    //    cmd.Parameters.AddWithValue("Done", false);

                    //    cmd.ExecuteNonQuery();

                    //    cnn.Close();

                    //    updatebalance(balance);
                    deleteCart();
                    refresh();
                    //    this.Alert("Your order is being prepared", Noti.enmType.Waiting);
                }
                    


                }
            
        }
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Checkout();
        }

       
    }
}
