using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.UserControlMain
{
    public partial class UserControlSales : UserControl
    {
        public UserControlSales()
        {
            InitializeComponent();
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            FormOrder formOrder = new FormOrder();
            formOrder.Show();
        }
    }
}
