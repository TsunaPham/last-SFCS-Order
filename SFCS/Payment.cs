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
using MoMo;
using Newtonsoft.Json.Linq;

namespace SFCS
{
    public partial class Payment : UserControl
    {
        SqlConnection cnn;
        cnnString cnnstr = new cnnString();
        public Payment()
        {
            InitializeComponent();
            cnn = cnnstr.cnn;
        }
        private Int64 total;
        private string _cusname;
        private int accID;
        private int Vendor;
        public void setVID(int id)
        {
            Vendor = id;
        }
        private string Name;
        public void setCID(int id)
        {
            accID = id;
        }
        
        public void setTotal(Int64 Total)
        {
            this.total = Total;
            lbtotal.Text = Total.ToString();
        }

        private int orderID;
       
        private int isactive;
        public void setActive(int active)
        {
            isactive = active;
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
                id = (int)dr["ID"];
            }
            cnn.Close();
            return ++id;

        }
        List<CartItem> cartlist = new List<CartItem>();
        public void setlist(List<CartItem> list)
        {
            int n = list.Count();
            
            cartlist = list;
        }
        private int amount;
       
        private Int64 checkBalance()
        {
            string sql = "select * from AccountDB;";
            int id;
            Int64 balance = 0;
           
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = (int)dr["ID"];
                balance = Convert.ToInt64(dr["Balance"].ToString().Trim());
                Name = dr["Name"].ToString();
                if (id == accID) break;
            }
            cnn.Close();

            if (balance < total) return -1;
            else return balance - total;


        }
        private void updateBalance(Int64 balance)
        {

            cnn.Open();
            SqlCommand cmd2 = new SqlCommand("Update AccountDB set Balance = @Balance where ID = @ID", cnn);
            cmd2.Parameters.AddWithValue("@Balance", balance);
            cmd2.Parameters.AddWithValue("@ID", accID);
            cmd2.ExecuteNonQuery();
            cnn.Close();
        }

        private static Random random = new Random();
        public DateTime RandomDay()
        {
            DateTime start = new DateTime(2019, 6, 28);
            DateTime end = new DateTime(2020, 6, 28);
            int range = (end - start).Days;
            return start.AddDays(random.Next(range));
        }
        public void Alert(string msg, Notice.enmType type)
        {
            Notice frm = new Notice();
            frm.showAlert(msg, type);
        }
        private void updateOrderLine()
        {

            orderID = orderid();
            cnn.Open();
            for (int i = 0; i < amount; i++)
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
        private void doAccPayment()
        {

            if (MessageBox.Show("Bạn có muốn thanh toán cho đơn hàng này", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Int64 balance = checkBalance();
                if (balance > -1)
                {

                    updateOrderLine();
                    DateTime datetime = RandomDay();

                    MessageBox.Show("Thanh toán thành công - số tiền còn lại trong tài khoản là " + balance.ToString());
                    string sql = "INSERT INTO OrderDB(AccountID,Total,VendorID,Datetime,Done) VALUES(@AccountID,@Total,@VendorID,@Datetime,@Done)";
                    SqlCommand cmd = new SqlCommand(sql, cnn);

                    cnn.Open();


                    cmd.Parameters.AddWithValue("AccountID", accID);

                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@VendorID", Vendor);
                    cmd.Parameters.AddWithValue("@Datetime", datetime);
                    cmd.Parameters.AddWithValue("Done", false);

                    cmd.ExecuteNonQuery();

                    cnn.Close();

                    updateBalance(balance);


                    this.Alert("Đơn hàng của bạn đang được chuẩn bị", Notice.enmType.Waiting);
                }
                else MessageBox.Show("Thanh toán thất bại, đề nghị nạp thêm tiền vào tài khoản");
            }

        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private void doMomoPayment()
        {
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string accessKey = "M8brj9K6E22vXoDB";
            string partnerCode = "MOMO5RGX20191128";
            string serectkey = "nqQiVSgDMy809JoPF6OzP5OdBUB550Y4";
            string orderInfo = "Payment by Momo for customer";
            string returnUrl = "https://momo.vn/return";
            string notifyurl = "https://momo.vn/notify";

            string amount = total.ToString();
            string orderId = Guid.NewGuid().ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderId + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            log.Debug("rawHash = " + rawHash);
            
            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);
            log.Debug("Signature = " + signature);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };
            log.Debug("Json request to MoMo: " + message.ToString());
            PaymentRequest pq = new PaymentRequest();
            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);
            log.Debug("Return from MoMo: " + jmessage.ToString());

            if (MessageBox.Show("Bạn có muốn thanh toán cho đơn hàng này", "Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                System.Diagnostics.Process.Start(jmessage.GetValue("payUrl").ToString());
                this.Alert("Đơn hàng của bạn đang được chuẩn bị", Notice.enmType.Waiting);
                updateOrderLine();
            }
            


        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            
            if (rdAccount.Checked == true) doAccPayment();
            if (rdMomo.Checked == true) doMomoPayment();
            this.Hide();
        }
    }
}
