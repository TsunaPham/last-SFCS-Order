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

namespace SFCS
{
    public partial class CartView : UserControl
    {
        SqlConnection cnn;
        SqlConnection con;
        cnnString cnnstr = new cnnString();
        public CartView()
        {
            InitializeComponent();
            cnn = cnnstr.cnn;
            deletecart();
            btnPay.Enabled = false;
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Desktop\SFCS\SFCS\AccountDB.mdf;Integrated Security=True;Connect Timeout=30");
        }
        public void refresh()
        {
            flowLayoutPanel1.Controls.Clear();
            populate();
        }
        private Int32 total = 0;
        private string _cusname = "";
        
        public string Cusname
        {
            get { return _cusname; }
            set { _cusname = value; }
        }
        public int isactive { get; set; }
        
        public int orderID;
        public int accID
        {get;set;
        }
        public bool success { get; set; }
        private void deletecart()
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
        CartItem[] cartlist = new CartItem[5];
        private int amount = 0;
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private void populate()
        {
            total = 0;

            amount = 0;
            string foodname = "";
            string fqtystr = "";
            int fqty = 0;
            string sub = "";
            int vdor;
            string sql = "select * from TempoOrder";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            { 
                foodname = dr["Name"].ToString();
                fqtystr = dr["Quantity"].ToString();
                fqty = Convert.ToInt32(fqtystr.Trim());
                sub = dr["Subprice"].ToString();
                total += Convert.ToInt32(sub.Trim());
                vdor = (int)dr["VendorID"];
                cartlist[i] = new CartItem();
                cartlist[i].FName = foodname;
                cartlist[i].Qty = fqtystr;
                cartlist[i].Sub = sub;
                cartlist[i].Vendor = vdor; cartlist[i].btndel.Click += new System.EventHandler(this.btndel_Click);
                flowLayoutPanel1.Controls.Add(cartlist[i]);
              

                i++;
                amount++;

            }
            if (amount > 0) btnPay.Enabled = true;
            else btnPay.Enabled = false;
            lbTotal.Text = total.ToString();
            cnn.Close();



        }
        
        

        private void btndel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this item from cart", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                refresh();

            }
            
        }
       private int orderid()
        {
            string sql = "select * from OrderDB";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            
            int id = 0;
            while (dr.Read())
            {
                id = (int)dr["OrderID"];
            }
            cnn.Close();
            return ++id;
            
        }
        private void updateOrderLine()
        {
           
           orderID = orderid();
            cnn.Open();
            for (int i=0;i<amount;i++)
            {
                string sql = "INSERT INTO OrderLineDB(OrderID,Name,Quantity,SubPrice,VendorID) VALUES(@OrderID,@Name,@Quantity,@SubPrice,@VendorID)";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                cmd.Parameters.AddWithValue("@Name", cartlist[i].FName);

                cmd.Parameters.AddWithValue("@Quantity", cartlist[i].Qty);
                cmd.Parameters.AddWithValue("@VendorID", cartlist[i].Vendor);
                cmd.Parameters.AddWithValue("@SubPrice", cartlist[i].Sub);
                
                cmd.ExecuteNonQuery();
            }
            cnn.Close();
        }
        private void CartView_Load(object sender, EventArgs e)
        {

        }
        private Int32 Checkbalance()
        {
            string sql = "select * from Acctbl;";
            int isActive;
            Int32 balance=0;
            string name = "";
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
            con.Close();

            if (balance < total) return -1;
            else return balance-total;
            
            
        }
        private void Updatebalance(Int32 balance)
        {
            
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Update Acctbl set Balance = @Balance where Username = @Username", con);
            cmd2.Parameters.AddWithValue("@Balance", balance);
            cmd2.Parameters.AddWithValue("@Username", _cusname);
            cmd2.ExecuteNonQuery();
            con.Close();
        }

        private static Random random = new Random();
        public DateTime RandomDay()
        {
            DateTime start = new DateTime(2020, 6, 28);
            DateTime end = new DateTime(2021, 6, 28);
            int range = (end-start).Days;           
            return start.AddDays(random.Next(range));
        }
        public void Alert(string msg, Noti.enmType type)
        {
            Noti frm = new Noti();
            frm.showAlert(msg, type);
        }
        private void btnPay_Click(object sender, EventArgs e)
        {   if (isactive == 0) MessageBox.Show("Please login before making payment");
            else
            {
                if (MessageBox.Show("Do you want to pay for this order", "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    updateOrderLine();
                    
                    Int32 balance = Checkbalance();
                    success = false;

                    if (balance > -1)
                    {
                        
                        success = true;
                        DateTime datetime = RandomDay();
                       
                        MessageBox.Show("Payment successful - Your balance is now " + balance.ToString());
                        string sql = "INSERT INTO OrderDB(AccountID,Total,VendorID,Datetime,Done) VALUES(@AccountID,@Total,@VendorID,@Datetime,@Done)";
                        SqlCommand cmd = new SqlCommand(sql, cnn);

                        cnn.Open();

                       
                        cmd.Parameters.AddWithValue("AccountID", accID);

                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.Parameters.AddWithValue("@VendorID", cartlist[0].Vendor);
                        cmd.Parameters.AddWithValue("@Datetime", datetime);
                        cmd.Parameters.AddWithValue("Done", false);
                       
                        cmd.ExecuteNonQuery();

                        cnn.Close();

                        Updatebalance(balance);
                        deletecart();
                        refresh();
                        this.Alert("Your order is being prepared", Noti.enmType.Waiting);
                    }
                    else MessageBox.Show("Payment failed - Your balance isn't enough, please recharge your account");


                }
            }
        }

       
    }
}
