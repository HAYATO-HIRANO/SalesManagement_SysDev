using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }

        private void textBoxClFAX_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            panelSetting.Visible = false;
            userControlMaker1.Visible = false;
            //userControlMajorClassification.Visible = false;
            //userControlSmallClassification.Visible = false;
        }

        private void panelSetting_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            panelSetting.Visible = true;
        }

        private void buttonMaker_Click(object sender, EventArgs e)
        {
            labelProduct.Text = "メーカー管理";
            userControlMaker1.Visible = true;
            //userControlMajorClassification.Visible = false;
            //userControlSmallClassification.Visible = false;
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            //商品管理ボタン
            labelProduct.Text = "商品管理";
            panelSetting.Visible = false;
            userControlMaker1.Visible = false;
            //userControlMajorClassification.Visible = false;
            //userControlSmallClassification.Visible = false;
        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
