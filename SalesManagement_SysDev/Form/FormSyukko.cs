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
    public partial class FormSyukko : Form
    {
        public FormSyukko()
        {
            InitializeComponent();
        }

        private void FormSyukko_Load(object sender, EventArgs e)
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

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if (labelSyukko.Text == "出庫管理")
            {
                labelSyukko.Text = "出庫詳細管理";
                buttonDetail.Text = "出庫管理";
                userControlSyukkoDetail1.Visible = true;
                panelSyukko.Visible = false;
                return;
            }
            if (labelSyukko.Text == "出庫詳細管理")
            {
                labelSyukko.Text = "出庫管理";
                buttonDetail.Text = "出庫詳細管理";
                panelSyukko.Visible = true;
                userControlSyukkoDetail1.Visible = false;
                return;
            }
        }
    }
}
