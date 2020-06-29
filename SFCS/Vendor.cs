using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
namespace SFCS
{
    public partial class Vendor : UserControl
    {
        cnnString cnnstr = new cnnString();
        SqlConnection cnn;
        public Vendor()
        {
            InitializeComponent();

            menu1.Hide();

            btnBack.Hide();
            cnn = cnnstr.cnn;
        }
        
        private void VendorList1_Load(object sender, EventArgs e)
        {
            

        }

        private void BtnNQ_Click(object sender, EventArgs e)
        {
            menu1.setvid(0);
            menu1.Refresh();
            menu1.Show();
            btnBack.Show();
            
        }

        private void BtnPY_Click(object sender, EventArgs e)
        {   
            menu1.setvid(1);
            menu1.Refresh();
            menu1.Show();
            btnBack.Show();
            
        }

        private void BtnBB_Click(object sender, EventArgs e)
        {
            menu1.setvid(2);
            menu1.Refresh();
            menu1.Show();
            btnBack.Show();
            
         
        }
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
        private void BtnBack_Click(object sender, EventArgs e)
        {
            string stmt = "SELECT COUNT(*) FROM TempoOrder";
            int count = 0;
            cnn.Open();
            SqlCommand cmdCount = new SqlCommand(stmt, cnn);
            count = (int)cmdCount.ExecuteScalar();
            cnn.Close();
            
            if (count > 0)
            {
                if (MessageBox.Show("If you leave this vendor, your selected food will be deleted. Are you sure ?", "Leave the vendor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    deletecart();
                    
                }
            }
            menu1.Hide();
            btnBack.Hide();
        }
    }
        

       
}
