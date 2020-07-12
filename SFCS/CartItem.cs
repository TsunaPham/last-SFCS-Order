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
    public partial class CartItem : UserControl
    {
        cnnString con = new cnnString();
        SqlConnection cnn;
        cnnString cnnstr = new cnnString();
        SqlConnection cnn1;
        public CartItem()
        {
            InitializeComponent();
            cnn = cnnstr.cnn;
            cnn1 = con.cnn;       
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private string _fname;
        private int _qty;
        private Int64 _subprice;
        private int _vendor;
        private bool _del = false;
        public string FName
        {
            get
            {
                return _fname;
            }
            set
            { _fname = value; lbName.Text = value; }
        }
        public int Qty
        {
            get
            {
                return _qty;
            }
            set
            { _qty = value; lbQty.Text = value.ToString(); }
        }
        public Int64 Sub
        {
            get
            {
                return _subprice;
            }
            set
            { _subprice = value; lbSub.Text = _subprice.ToString(); }
        }
        public int Vendor
        {
            get
            {
                return _vendor;
            }
            set
            { _vendor = value; }
        }
        public void Btndel_Click(object sender, EventArgs e)
        {

            deleteItem();


        }
        private void deleteItem()
        {
            string sql = "DELETE FROM TempoOrder WHERE Name=@name";
            string sql1 = "DBCC CHECKIDENT (TempoOrder,RESEED,0)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlCommand cmd1 = new SqlCommand(sql1, cnn);
            cnn.Open();
            cmd.Parameters.AddWithValue("@name", FName);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
