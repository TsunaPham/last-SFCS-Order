using System;

namespace SFCS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Rechargebtn = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.btnCus = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.recharge1 = new SFCS.Recharge();
            this.newLoginControl1 = new SFCS.NewLoginControl();
            this.cartView1 = new SFCS.CartView();
            this.vendor1 = new SFCS.Vendor();
            this.mainPage1 = new SFCS.MainPage();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(210, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(102, 144);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(31, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "SFCS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.Rechargebtn);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.SidePanel);
            this.panel3.Controls.Add(this.btnCus);
            this.panel3.Controls.Add(this.btnHome);
            this.panel3.Controls.Add(this.btnCart);
            this.panel3.Controls.Add(this.btnMenu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 585);
            this.panel3.TabIndex = 2;
            // 
            // Rechargebtn
            // 
            this.Rechargebtn.FlatAppearance.BorderSize = 0;
            this.Rechargebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Rechargebtn.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rechargebtn.ForeColor = System.Drawing.Color.White;
            this.Rechargebtn.Image = ((System.Drawing.Image)(resources.GetObject("Rechargebtn.Image")));
            this.Rechargebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Rechargebtn.Location = new System.Drawing.Point(13, 436);
            this.Rechargebtn.Name = "Rechargebtn";
            this.Rechargebtn.Size = new System.Drawing.Size(179, 73);
            this.Rechargebtn.TabIndex = 8;
            this.Rechargebtn.Text = "Recharge";
            this.Rechargebtn.UseVisualStyleBackColor = true;
            this.Rechargebtn.Click += new System.EventHandler(this.Rechargebtn_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 33);
            this.btnClose.TabIndex = 5;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.SidePanel.Location = new System.Drawing.Point(3, 123);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(11, 70);
            this.SidePanel.TabIndex = 4;
            // 
            // btnCus
            // 
            this.btnCus.FlatAppearance.BorderSize = 0;
            this.btnCus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCus.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCus.ForeColor = System.Drawing.Color.White;
            this.btnCus.Image = ((System.Drawing.Image)(resources.GetObject("btnCus.Image")));
            this.btnCus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCus.Location = new System.Drawing.Point(19, 357);
            this.btnCus.Name = "btnCus";
            this.btnCus.Size = new System.Drawing.Size(179, 73);
            this.btnCus.TabIndex = 7;
            this.btnCus.Text = "Customer";
            this.btnCus.UseVisualStyleBackColor = true;
            this.btnCus.Click += new System.EventHandler(this.BtnCus_Click);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(14, 120);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(179, 73);
            this.btnHome.TabIndex = 6;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // btnCart
            // 
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCart.ForeColor = System.Drawing.Color.White;
            this.btnCart.Image = ((System.Drawing.Image)(resources.GetObject("btnCart.Image")));
            this.btnCart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCart.Location = new System.Drawing.Point(14, 278);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(179, 73);
            this.btnCart.TabIndex = 5;
            this.btnCart.Text = "View Cart";
            this.btnCart.UseVisualStyleBackColor = true;
            this.btnCart.Click += new System.EventHandler(this.BtnCart_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.Location = new System.Drawing.Point(12, 199);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(179, 73);
            this.btnMenu.TabIndex = 4;
            this.btnMenu.Text = "  View Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(198, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 42);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(327, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 47);
            this.label2.TabIndex = 4;
            this.label2.Text = "SMART FOOD COURT";
            // 
            // recharge1
            // 
            this.recharge1.Location = new System.Drawing.Point(198, 141);
            this.recharge1.Name = "recharge1";
            this.recharge1.Size = new System.Drawing.Size(805, 444);
            this.recharge1.TabIndex = 9;
            this.recharge1.Load += new System.EventHandler(this.Recharge1_Load);
            // 
            // newLoginControl1
            // 
            this.newLoginControl1.BackColor = System.Drawing.SystemColors.Control;
            this.newLoginControl1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.newLoginControl1.Location = new System.Drawing.Point(199, 141);
            this.newLoginControl1.Name = "newLoginControl1";
            this.newLoginControl1.Size = new System.Drawing.Size(802, 444);
            this.newLoginControl1.TabIndex = 8;
            // 
            // cartView1
            // 
            this.cartView1.Amount = 0;
            this.cartView1.Cusname = "";
            this.cartView1.Location = new System.Drawing.Point(197, 142);
            this.cartView1.Name = "cartView1";
            this.cartView1.Size = new System.Drawing.Size(804, 443);
            this.cartView1.TabIndex = 7;
            // 
            // vendor1
            // 
            this.vendor1.AutoScroll = true;
            this.vendor1.Location = new System.Drawing.Point(199, 142);
            this.vendor1.Name = "vendor1";
            this.vendor1.Size = new System.Drawing.Size(804, 445);
            this.vendor1.TabIndex = 6;
            // 
            // mainPage1
            // 
            this.mainPage1.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPage1.Location = new System.Drawing.Point(198, 142);
            this.mainPage1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.mainPage1.Name = "mainPage1";
            this.mainPage1.Size = new System.Drawing.Size(805, 443);
            this.mainPage1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1003, 585);
            this.Controls.Add(this.recharge1);
            this.Controls.Add(this.newLoginControl1);
            this.Controls.Add(this.cartView1);
            this.Controls.Add(this.vendor1);
            this.Controls.Add(this.mainPage1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Button btnCus;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private MainPage mainPage1;
        private Vendor vendor1;
        private CartView cartView1;
        private NewLoginControl newLoginControl1;
        private Recharge recharge1;
        private System.Windows.Forms.Button Rechargebtn;
    }
}

