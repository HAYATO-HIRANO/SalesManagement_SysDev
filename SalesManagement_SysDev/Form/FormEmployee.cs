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
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            panelSetting.Visible = false;
            userControlPosition1.Visible = false;
        }

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {

        }

        private void labelPageSize_Click(object sender, EventArgs e)
        {

        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {

        }

        private void labelPage_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPage_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {

        }

        private void buttonLastPage_Click(object sender, EventArgs e)
        {

        }

        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPageSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            panelSetting.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelSetting.Visible = false;
            userControlPosition1.Visible = false;
            labelManagement.Text = "社員管理";
        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPosition_Click(object sender, EventArgs e)
        {
            userControlPosition1.Visible = true;
            labelManagement.Text = "役職管理";
        }

        private void userControlPosition1_Load(object sender, EventArgs e)
        {

        }
    }
}
