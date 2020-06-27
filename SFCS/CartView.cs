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
        public CartView()
        {
            InitializeComponent();
            cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khoai.LAPTOP-SHJHO9TV\Desktop\SFCSDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            deletecart();
            btnPay.Enabled = false;
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Khoai.LAPTOP-SHJHO9TV\Desktop\SFCSDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        }
        public void Refresh()
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
        private void deletecart()
        {
            string sql = "DELETE FROM OrderDB";
            string sql1 = "DBCC CHECKIDENT (OrderDB,RESEED,0)";
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
            string vdor = "";
            string sql = "select * from Ordertbl";
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
                vdor = dr["Vendor"].ToString();
                cartlist[i] = new CartItem();
                cartlist[i].FName = foodname;
                cartlist[i].Qty = fqtystr;
                cartlist[i].Sub = sub;
                cartlist[i].Vendor = vdor;
                flowLayoutPanel1.Controls.Add(cartlist[i]);
                cartlist[i].btndel.Click += new System.EventHandler(this.btndel_Click);
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
                Refresh();

            }
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
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void btnPay_Click(object sender, EventArgs e)
        {   if (_cusname == "") MessageBox.Show("Please login before making payment");
            else
            {
                if (MessageBox.Show("Do you want to pay for this order", "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {



                    string orderid = RandomString(10);
                    int month = random.Next(1, 13);
                    int day = random.Next(1, 31);
                    Int32 balance = Checkbalance();

                    if (balance > -1)
                    {
                        MessageBox.Show("Payment successful - Your balance is now " + balance.ToString());
                        string sql = "INSERT INTO Salestbl(OrderID,AccID,TotalPrice,Vendor,Month,Day) VALUES(@OrderID,@AccID,@TotalPrice,@Vendor,@Month,@Day)";
                        SqlCommand cmd = new SqlCommand(sql, cnn);

                        cnn.Open();

                        cmd.Parameters.AddWithValue("@OrderID", orderid);
                        cmd.Parameters.AddWithValue("AccID", 101);

                        cmd.Parameters.AddWithValue("@TotalPrice", total);
                        cmd.Parameters.AddWithValue("@Vendor", cartlist[0].Vendor);
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@Day", day);
                        cmd.ExecuteNonQuery();

                        cnn.Close();

                        Updatebalance(balance);
                        deletecart();
                        Refresh();
                    }
                    else MessageBox.Show("Payment failed - Your balance isn't enough, please recharge your account");


                }
            }
        }
    }
}
