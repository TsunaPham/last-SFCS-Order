using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFCS
{
    public partial class VendorList : UserControl
    {
        public VendorList()
        {
            InitializeComponent();
        }
        #region Properties
        private string _vname;
        private Image _icon;
        [Category("Vendor Props")]
        public string VName
        {
            get
            {
                return _vname;
            }
            set
            { _vname = value; lbName.Text = value; }
        }
        [Category("Vendor Props")]
        public Image Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;pictureBox1.Image = value;
            }
        }
        #endregion
        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void VendorList_Load(object sender, EventArgs e)
        {

        }

        private void VendorList_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void VendorList_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void VendorList_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void VendorList_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
           
        }
    }
}
