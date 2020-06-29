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
using System.IO;
using SFCS;

namespace SFCS
{
    public partial class Form1 : Form
    {
        string usname = "";
        int accid;
        cnnString cnnstr = new cnnString();
        SqlConnection cnn;
        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            mainPage1.BringToFront();
            cnn = cnnstr.cnn;
            btnRefresh.Hide();
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
        public void Alert(string msg, Noti.enmType type)
        {
            Noti frm = new Noti();
            frm.showAlert(msg, type);
        }

        private void BtnCart_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCart.Height;
            SidePanel.Top = btnCart.Top;
            cartView1.Cusname = usname;
            cartView1.accID = newLoginControl1.accid;
            cartView1.isactive = newLoginControl1.isActive;
            cartView1.refresh();
            cartView1.BringToFront();
            cartView1.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cartView1.success == true) btnRefresh.Show();
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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Desktop\SFCS\SFCS\AccountDB.mdf;Integrated Security=True;Connect Timeout=30");
            int active = 0;
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Update Acctbl set isActive = @isActive where Username = @Username", con);
            cmd2.Parameters.AddWithValue("@isActive", active);
            cmd2.Parameters.AddWithValue("@Username", usname);
            cmd2.ExecuteNonQuery();
            con.Close();
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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Desktop\SFCS\SFCS\AccountDB.mdf;Integrated Security=True;Connect Timeout=30");
            string sql = "select * from Acctbl;";
            int isActive;
            int id = 0;
            bool islogged = false;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                isActive = Convert.ToInt32(dr["isActive"].ToString().Trim());
                username = dr["Username"].ToString();
                id = (int)dr["AccID"];
                if (isActive == 1) { islogged = true; break; }
            }
            con.Close();
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
                id = (int)dr["OrderID"];
                done = (bool)dr["Done"];
                if (id == cartView1.orderID) break;
            }
            cnn.Close();
            if (done == true) this.Alert("Your order is finished", Noti.enmType.Success);


        }
    }
}

