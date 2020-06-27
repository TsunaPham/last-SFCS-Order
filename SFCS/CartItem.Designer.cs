namespace SFCS
{
    partial class CartItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartItem));
            this.lbName = new System.Windows.Forms.Label();
            this.lbQty = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSub = new System.Windows.Forms.Label();
            this.btndel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbName.Location = new System.Drawing.Point(26, 17);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(66, 22);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            this.lbName.Click += new System.EventHandler(this.Label1_Click);
            // 
            // lbQty
            // 
            this.lbQty.AutoSize = true;
            this.lbQty.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbQty.Location = new System.Drawing.Point(417, 17);
            this.lbQty.Name = "lbQty";
            this.lbQty.Size = new System.Drawing.Size(45, 22);
            this.lbQty.TabIndex = 1;
            this.lbQty.Text = "Qty";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 1);
            this.panel1.TabIndex = 2;
            // 
            // lbSub
            // 
            this.lbSub.AutoSize = true;
            this.lbSub.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbSub.Location = new System.Drawing.Point(584, 17);
            this.lbSub.Name = "lbSub";
            this.lbSub.Size = new System.Drawing.Size(90, 22);
            this.lbSub.TabIndex = 3;
            this.lbSub.Text = "Subprice";
            // 
            // btndel
            // 
            this.btndel.FlatAppearance.BorderSize = 0;
            this.btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndel.Image = ((System.Drawing.Image)(resources.GetObject("btndel.Image")));
            this.btndel.Location = new System.Drawing.Point(714, 8);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(75, 42);
            this.btndel.TabIndex = 4;
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.Btndel_Click);
            // 
            // CartItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.lbSub);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbQty);
            this.Controls.Add(this.lbName);
            this.Name = "CartItem";
            this.Size = new System.Drawing.Size(804, 62);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbQty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbSub;
        public System.Windows.Forms.Button btndel;
    }
}
