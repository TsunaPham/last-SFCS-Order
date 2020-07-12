using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Data.SqlClient;
namespace SFCS
{
    public partial class Form1 : Form
    {
        cnnString cnnstr = new cnnString();
        SqlConnection cnn;
        int accid = 0;
        string usname = "";
        string cusname = "";
        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            mainPage1.BringToFront();
            cnn = cnnstr.cnn;
            btnRefresh.Hide();
            lbMaintenance.Hide();
            if (maintenance() == false)
            {
               
                btnCart.Enabled = false;
                btnHome.Enabled = false;
                btnMenu.Enabled = false;

                Rechargebtn.Enabled = false;
                btnCus.Enabled = false;
                lbMaintenance.Show();

            }
            else 
            {
                btnCart.Enabled = true;
                btnHome.Enabled = true;
                btnMenu.Enabled = true;

                Rechargebtn.Enabled = true;
                btnCus.Enabled = true;
            }

        }
        
        private bool maintenance()
        {
            string sql = "select * from Enable;";
            bool isMaintenance=false;
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                isMaintenance = (bool)dr["Enable"];
              
            }
            cnn.Close();
            return isMaintenance;

        }
        private void BtnHome_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            mainPage1.BringToFront();
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnMenu.Height;
            SidePanel.Top = btnMenu.Top;
            vendor1.BringToFront();
        }
        public void Alert(string msg, Notice.enmType type)
        {
            Notice frm = new Notice();
            frm.showAlert(msg, type);
        }

        private void BtnCart_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCart.Height;
            SidePanel.Top = btnCart.Top;
            
            cart1.setCusname(usname);
            cart1.setaccID(newLoginControl1.accID);
            cart1.setisActive(newLoginControl1.isActive);
            cart1.refresh();
            cart1.BringToFront();
            cart1.btnCheckout.Click += new System.EventHandler(this.btnPay_Click);
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cartView1.getisCheck() == true) btnRefresh.Show();
        }
        private void BtnCus_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCus.Height;
            SidePanel.Top = btnCus.Top;
            newLoginControl1.BringToFront();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
           
            int active = 0;
            cnn.Open();
            SqlCommand cmd2 = new SqlCommand("Update AccountDB set isActive = @isActive where Username = @Username", cnn);
            cmd2.Parameters.AddWithValue("@isActive", active);
            cmd2.Parameters.AddWithValue("@Username", usname);
            cmd2.ExecuteNonQuery();
            cnn.Close();
            Close();
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Recharge1_Load(object sender, EventArgs e)
        {

        }

        private void Rechargebtn_Click(object sender, EventArgs e)
        {
            string username = "";
            
            string sql = "select * from AccountDB;";
            bool isActive;
            int id = 0;
            bool islogged = false;
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                isActive = (bool)dr["isActive"];
                username = dr["Username"].ToString();
                cusname = dr["Name"].ToString();
                id = (int)dr["ID"];
                if (isActive == true) { islogged = true; break; }
            }
            cnn.Close();
            if (islogged == false) MessageBox.Show("Please sign in first");
            else
            {
                accid = id;
                usname = username;
                SidePanel.Height = btnCus.Height;
                SidePanel.Top = Rechargebtn.Top;
                recharge1.refresh();
                recharge1.BringToFront();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            int id = 0;
            bool done = false;
            string sql = "select * from OrderDB";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = (int)dr["ID"];
                done = (bool)dr["Done"];
                if (id == cartView1.orderID) break;
            }
            cnn.Close();
            
            if (done == true) this.Alert("Your order is finished", Notice.enmType.Success);
        }
    }
}
