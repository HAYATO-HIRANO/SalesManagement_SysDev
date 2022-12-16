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
    public partial class FormHattyu : Form
    {
        public FormHattyu()
        {
            InitializeComponent();
        }

        private void FormHattyu_Load(object sender, EventArgs e)
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

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if (labelHattyu.Text == "発注管理")
            {
                labelHattyu.Text = "発注詳細管理";
                buttonDetail.Text = "発注管理";
                userControlHattyuDetail1.Visible = true;
                panelHattyu.Visible = false;
                return;
            }
            if (labelHattyu.Text == "発注詳細管理")
            {
                labelHattyu.Text = "発注管理";
                buttonDetail.Text = "発注詳細";
                panelHattyu.Visible = true;
                userControlHattyuDetail1.Visible = false;
            }
        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
