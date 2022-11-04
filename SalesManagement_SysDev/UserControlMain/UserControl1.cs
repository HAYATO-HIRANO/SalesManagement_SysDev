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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            FormClient formclient = new FormClient();
            formclient.Show();
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {

        }

        private void buttonSale_Click(object sender, EventArgs e)
        {
            FormSale formSale = new FormSale();
            formSale.Show();
        }
    }
}
