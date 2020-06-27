namespace SFCS
{
    partial class OTPform
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
            this.label1 = new System.Windows.Forms.Label();
            this.confirmbtn = new System.Windows.Forms.Button();
            this.OTPtxt = new System.Windows.Forms.TextBox();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(281, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "Please confirm your OTP here";
            // 
            // confirmbtn
            // 
            this.confirmbtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.confirmbtn.FlatAppearance.BorderSize = 0;
            this.confirmbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmbtn.ForeColor = System.Drawing.Color.White;
            this.confirmbtn.Location = new System.Drawing.Point(246, 272);
            this.confirmbtn.Name = "confirmbtn";
            this.confirmbtn.Size = new System.Drawing.Size(132, 59);
            this.confirmbtn.TabIndex = 54;
            this.confirmbtn.Text = "Confirm";
            this.confirmbtn.UseVisualStyleBackColor = false;
            this.confirmbtn.Click += new System.EventHandler(this.confirmbtn_Click);
            // 
            // OTPtxt
            // 
            this.OTPtxt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.OTPtxt.Location = new System.Drawing.Point(329, 226);
            this.OTPtxt.Name = "OTPtxt";
            this.OTPtxt.Size = new System.Drawing.Size(132, 22);
            this.OTPtxt.TabIndex = 55;
            // 
            // cancelbtn
            // 
            this.cancelbtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.cancelbtn.FlatAppearance.BorderSize = 0;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbtn.ForeColor = System.Drawing.Color.White;
            this.cancelbtn.Location = new System.Drawing.Point(404, 272);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(132, 59);
            this.cancelbtn.TabIndex = 56;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(332, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 37);
            this.label2.TabIndex = 57;
            this.label2.Text = "VERIFY";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(194, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 269);
            this.panel1.TabIndex = 58;
            // 
            // OTPform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.OTPtxt);
            this.Controls.Add(this.confirmbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "OTPform";
            this.Size = new System.Drawing.Size(807, 446);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmbtn;
        private System.Windows.Forms.TextBox OTPtxt;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}
