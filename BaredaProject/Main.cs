using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaredaProject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void barBtnSR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimeInput input = new TimeInput();
            input.ShowDialog();
        }
    }
}
