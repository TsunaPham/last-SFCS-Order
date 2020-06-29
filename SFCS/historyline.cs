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
    public partial class historyline : UserControl
    {
        public historyline()
        {
            InitializeComponent();
        }
        private DateTime date;
        private int vendor;
        private Int64 total;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            { date = value; lbDate.Text = value.ToString(); }
        }
        public Int64 Total
        {
            get
            {
                return total;
            }
            set
            { total = value; lbTotal.Text = value.ToString(); }
        }
        public int Vendor
        {
            get
            {
                return vendor;
            }
            set
            { vendor = value; if (value == 1) lbVendor.Text = "Com ga Phu Yen";
                if (value == 0) lbVendor.Text = "Com tam Ngo Quyen";
                if (value == 2) lbVendor.Text = "Bun bo Hue";
            }
        }
        private int quantity = 0;
        
    }
    
}
