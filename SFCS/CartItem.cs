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
        SqlConnection cnn1;
        public CartItem()
        {
            InitializeComponent();
            cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Admin\Desktop\SFCS\SFCS\SFCS.mdf; Integrated Security = True");
            cnn1 = con.cnn;       
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private string _fname;
        private string _qty;
        private string _subprice;
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
        public string Qty
        {
            get
            {
                return _qty;
            }
            set
            { _qty = value; lbQty.Text = value; }
        }
        public string Sub
        {
            get
            {
                return _subprice;
            }
            set
            { _subprice = value; lbSub.Text = _subprice; }
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

            string sql = "DELETE FROM Ordertbl WHERE Name=@name";
            string sql1 = "DBCC CHECKIDENT (Ordertbl,RESEED,0)";
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
