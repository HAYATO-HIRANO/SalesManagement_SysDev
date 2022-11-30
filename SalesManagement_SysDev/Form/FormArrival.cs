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
    public partial class FormArrival : Form
    {
        public FormArrival()
        {
            InitializeComponent();
        }

        private void FormArrival_Load(object sender, EventArgs e)
        {
            //日時の表示
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            //panelHeaderに表示するログインデータ
            labelUserName.Text = "ユーザー名：" + FormMain.loginName;
            labelPosition.Text = "権限:" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "ユーザーID：" + FormMain.loginEmID.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void labelOrID_Click(object sender, EventArgs e)
        {

        }

        private void labelExplamation_Click(object sender, EventArgs e)
        {

        }

        private void textBoxOrID_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSoID_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSoID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelEmID_Click(object sender, EventArgs e)
        {

        }
    }
}
