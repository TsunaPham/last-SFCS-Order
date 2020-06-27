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
        SqlConnection cnn;
        public Vendor()
        {
            InitializeComponent();

            menu1.Hide();

            btnBack.Hide();
            cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Admin\Desktop\SFCS\SFCS\SFCS.mdf; Integrated Security = True");
        }
        
        private void VendorList1_Load(object sender, EventArgs e)
        {
            

        }

        private void BtnNQ_Click(object sender, EventArgs e)
        {
            menu1.setvname("Com tam Ngo Quyen");
            menu1.Refresh();
            menu1.Show();
            btnBack.Show();
            
        }

        private void BtnPY_Click(object sender, EventArgs e)
        {   
            menu1.setvname("Com ga Phu Yen");
            menu1.Refresh();
            menu1.Show();
            btnBack.Show();
            
        }

        private void BtnBB_Click(object sender, EventArgs e)
        {
            menu1.setvname("Bun bo Hue");
            menu1.Refresh();
            menu1.Show();
            btnBack.Show();
            
         
        }
        private void deletecart()
        {
            string sql = "DELETE FROM Ordertbl";
            string sql1 = "DBCC CHECKIDENT (Ordertbl,RESEED,0)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlCommand cmd1 = new SqlCommand(sql1, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cnn.Close();
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("If you leave this vendor, your selected food will be deleted. Are you sure ?", "Leave the vendor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deletecart();
                menu1.Hide();
                btnBack.Hide();
            }
        }
    }
        

       
}
