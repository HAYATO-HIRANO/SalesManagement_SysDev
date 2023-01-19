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
            //発注更新
            //日時の表示
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            //panelHeaderに表示するログインデータ
            labelUserName.Text = "社員名：" + FormMain.loginName;
            labelPosition.Text = "役職：" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "社員ID：" + FormMain.loginEmID.ToString();
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
                //userControlHattyuDetail1.Visible = true;
                panelHattyu.Visible = false;
                return;
            }
            if (labelHattyu.Text == "発注詳細管理")
            {
                labelHattyu.Text = "発注管理";
                buttonDetail.Text = "発注詳細";
                panelHattyu.Visible = true;
                //userControlHattyuDetail1.Visible = false;
            }
        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ログアウトしてよろしいですか？", "ログアウト確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                //OK時の処理
                FormMain.loginName = "";
                Dispose();
            }
        }
    }
}
